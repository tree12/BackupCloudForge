using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using EDI.DataAccess;
using EDI.DataAccess.Entities;
using EDI.DataAccess.Entities.Interfaces;
using EDI.Web.Models;
using EDI.Web.Services;
using EDI.Web.Util;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Framework.Readers;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EDI.Web.BackgroundService
{
    public class AdjustEdiStatus : Microsoft.Extensions.Hosting.BackgroundService
    {
        //private ApplicationDbContext dbContext;

        private Task _executingTask;

        private readonly CancellationTokenSource _stoppingCts =
            new CancellationTokenSource();

        protected IServiceScopeFactory ScopeFactory { get; }

        private IServiceScope serviceScope;

        protected IServiceScope ServiceScope
        {
            get
            {
                serviceScope ??= ScopeFactory.CreateScope();
                return serviceScope;
            }
        }

        private IConfiguration _config;

        private static ILog log = LogManager.GetLogger(typeof(AdjustEdiStatus));

        private EdiService _ediService;
        private RequestLogService _requestLogService;

        private List<UserInfo> _userInfos;

        public AdjustEdiStatus(IServiceScopeFactory scopeFactory, IConfiguration config,
            IOptions<List<UserInfo>> userInfos)
        {
            ScopeFactory = scopeFactory;
            //dbContext = ScopeFactory.CreateScope().ServiceProvider.GetService<ApplicationDbContext>();
            _ediService = new EdiService(ScopeFactory.CreateScope().ServiceProvider);
            _config = config;
            _userInfos = userInfos.Value;
            _requestLogService = new RequestLogService(ScopeFactory.CreateScope().ServiceProvider);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string intervalInSeconds = _config["AdjustEdiStatus:IntervalInSeconds"];
            int interval = Convert.ToInt32(string.IsNullOrEmpty(intervalInSeconds) ? "0" : intervalInSeconds);

            if (interval > 0)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        List<EdiOrder> ediOrders = await _ediService.GetOrderList(MessageStatus.TO_SEND);
                        List<EdiScheduleAgreement> ediSchedules = await _ediService.GetOrderScheduleList(MessageStatus.TO_SEND);
                        List<EdiOrderConfirmation> ediComfirmations = await _ediService.GetOrderComfirmationList(MessageStatus.TO_SEND);
                        List<EdiInvoice> ediInvoices = await _ediService.GetInvoiceList(MessageStatus.TO_SEND);
                        List<EdiDeliveryNote> ediDeliveryNote = await _ediService.GetDeliveryNoteList(MessageStatus.TO_SEND);
                        ediOrders.ChangeGermanLetterEnumerable();
                        ediSchedules.ChangeGermanLetterEnumerable();
                        ediComfirmations.ChangeGermanLetterEnumerable();
                        ediInvoices.ChangeGermanLetterEnumerable();
                        ediDeliveryNote.ChangeGermanLetterEnumerable();
                        await EdiProcess(new List<EdiMasterMessage<EdiOrder>>(ediOrders));
                        await EdiProcess(new List<EdiMasterMessage<EdiScheduleAgreement>>(ediSchedules));
                        await EdiProcess(new List<EdiMasterMessage<EdiOrderConfirmation>>(ediComfirmations));
                        await EdiProcess(new List<EdiMasterMessage<EdiInvoice>>(ediInvoices));
                        await EdiProcess(new List<EdiMasterMessage<EdiDeliveryNote>>(ediDeliveryNote));
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message, e);
                    }
                    finally
                    {
                        await Task.Delay(1000 * interval, stoppingToken);
                    }

                    async Task HandleException<TEntity>(int id, Exception e) where TEntity : class, IEdiMasterMessage
                    {
                        Console.WriteLine(e);
                        log.Error(e.Message, e);
                        await _ediService.LogErrorEdiMessage<TEntity>(id, e);
                    }
                    async Task ClearErrorMessage<TEntity>(int id) where TEntity : class, IEdiMasterMessage
                    {
                        log.Info($"Clear error message :{typeof(TEntity).Name}");
                        await _ediService.ClearErrorEdiMessage<TEntity>(id);
                    }

                    async Task EdiProcess<TEntity>(List<EdiMasterMessage<TEntity>> ediMessages)
                        where TEntity : BaseEdiObject<TEntity>, IEdiMasterMessage
                    {
                        foreach (var ediMessage in ediMessages)
                        {
                            try
                            {
                                UserInfo userInfo = _userInfos.FirstOrDefault(x =>
                                    x.Identity.EqualsIgnoreCase(ediMessage.RecipientUniqueId));

                                if (string.IsNullOrEmpty(userInfo?.SendInfo?.Url))
                                {
                                    string errorMessage =
                                        $"Could not send {ediMessage.GetType().Name} because we not found any URL in the config for RecivierUniqueId '{ediMessage.RecipientUniqueId}'";
                                    log.Error(errorMessage);
                                    await HandleException<TEntity>(ediMessage.Id,new Exception(errorMessage));
                                    continue;
                                }

                                if (string.IsNullOrEmpty(userInfo?.SendInfo?.Username) ||
                                    string.IsNullOrEmpty(userInfo?.SendInfo?.Password))
                                {
                                    string errorMessage =
                                        $"Could not send {ediMessage.GetType().Name} because we not found any Username/Password in the config for RecivierUniqueId '{ediMessage.RecipientUniqueId}'";
                                    log.Error(errorMessage);
                                    await HandleException<TEntity>(ediMessage.Id, new Exception(errorMessage));
                                    continue;
                                }

                                EdiMessage edi = ediMessage.CreateEdiDocument(); //ConvertEdiFact.BuildPurchaseOrder(ediOrder);

                                using HttpClient client = new HttpClient();
                                //Maybe We use https://code-maze.com/using-streams-with-httpclient-to-improve-performance-and-memory-usage/

                                client.DefaultRequestHeaders.Add($"Authorization",
                                    $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userInfo?.SendInfo?.Username}:{userInfo?.SendInfo?.Password}"))}");
                                client.DefaultRequestHeaders.Accept.Add(
                                    new MediaTypeWithQualityHeaderValue("text/plain")
                                    {
                                        CharSet = "utf-8"
                                    });
                                byte[] data = ConvertEdiFact.GetEdiDataAsBytes(ediMessage, edi);
                                string dataStr = Encoding.UTF8.GetString(data);
                                //string dataStr = "UNA:+.? 'UNB+UNOC:3+303550768:1+KTMAG:ZZZ+230127:1350+13++++++1'UNH+13+INVOIC:D:96A:UN'BGM+380+202202114+9'DTM+137:20220913:102'FTX+REG++ZZZ+Steuerfall?: Standard            :Aigner Fairnessbedingungen wurden per Email an den Besteller gesendet:Gelieferte Ware bleibt bis zur vollstaendigen Bezahlung unser Eigentum:Verzugszinsen 8% ueber Basiszinsatz der EZB:Firmenbuch?: Fn 170426 b, KG Wels Dienstgeber?: 900942279 ARA?: 11929'NAD+BY+1000::92'NAD+SU+0001000023::92++Aigner GmbH+Dieselstrasse 13+Gunskirchen++4623+AT'FII+RB+AT30 2032 0100 0002 4041:Aigner GmbH+ASPKAT2L:::20320:::Allgem. Sparkasse OOe+AT'RFF+VA:ATU 44500508'CTA+IC+:Aigner Heinz'COM+heinz.aigner@aigner.at:EM'COM+0043 699 1820 2000:TE'NAD+IV+1000::92++KTM AG +Stallhofnerstrasse 3+Mattighofen++5230+AT'RFF+VA:ATU23481505'NAD+DP+0940::92++KTM Components GmbH Division?: Exhau:st+Gewerbegebiet Nord 8+Munderfing++5222+AT'TAX+7+VAT+++:::20+S'CUX+2:EUR:4'PAT+22+6:::21  Tage mit 3 % Skonto+5:3:D:21'PCD+12:3'PAT+22+6:::30  Tage mit 2 % Skonto+5:3:D:30'PCD+12:2'PAT+22+6:::60  Tage netto+5:3:D:60'PCD+12:0'TOD+5++DDU'LOC+1+0940'LIN+10++:'IMD+F++:::1 Set Filterpatronen Set'QTY+47:1:PCE'MOA+203:603:EUR'PRI+AAA:603:::603:PCE'RFF+ON:9700011109:10'DTM+171:20220314:102'RFF+DQ:9700011109:10'DTM+171:20220917:102'TAX+7+VAT+++:::20+S'MOA+124:120.6:EUR'LIN+20++:'IMD+F++:::1 Stk. Partikelfilter H14 fr XL'QTY+47:1:PCE'MOA+203:544:EUR'PRI+AAA:544:::544:PCE'RFF+ON:9700011109:20'DTM+171:20220314:102'RFF+DQ:9700011109:20'DTM+171:20220917:102'TAX+7+VAT+++:::20+S'MOA+124:108.8:EUR'LIN+30++:'IMD+F++:::Lieferpauschale'QTY+47:1:PCE'MOA+203:33:EUR'PRI+AAA:33:::33:PCE'RFF+ON:9700011109:30'DTM+171:20220314:102'RFF+DQ:9700011109:30'DTM+171:20220917:102'TAX+7+VAT+++:::20+S'MOA+124:6.6:EUR'LIN+11'IMD+F++:::antistatisch'QTY+47:1:PCE'MOA+203:0:EUR'PRI+AAA:0:::0:PCE'RFF+ON:9700011109:'DTM+171:20220314:102'RFF+DQ:9700011109:'DTM+171:20220917:102'UNS+S'MOA+77:1416:EUR'MOA+125:1180:EUR'MOA+79:1180:EUR'TAX+7+VAT+++:::20+S'MOA+124:236:EUR'MOA+125:1180:EUR'UNT+74+13'UNZ+1+13'";

                                /*After convert to bytes UNT is generated. we can validate here.(You can uncomment below if you want to validate again.)*/
                                //try
                                //{
                                //    string resultMessage = string.Empty;
                                //    if (!ValidateMessage(data, out resultMessage))
                                //    {
                                //        log.Warn(resultMessage);
                                //        await HandleException<TEntity>(ediMessage.Id, new ValidateException(resultMessage));
                                //        continue;
                                //    }
                                //    else
                                //    {
                                //        await _ediService.ClearValidateEdiMessage<TEntity>(ediMessage.Id);
                                //    }
                                //}
                                //catch (Exception ex)
                                //{
                                //    log.Error("Validated error processing!", ex);
                                //    await HandleException<TEntity>(ediMessage.Id, new ValidateException($"Validated error processing!: {ex.Message}"));
                                //    continue;
                                //}

                                await _requestLogService.LogRequestAsync(null, Encoding.UTF8.GetString(data), userInfo?.SendInfo?.Url);
                                using (var requestContent = new ByteArrayContent(data))
                                {
                                    HttpResponseMessage response = await client.PostAsync(userInfo.SendInfo.Url, requestContent);
                                    string responseString = await response.Content.ReadAsStringAsync();

                                    if (response.StatusCode == HttpStatusCode.OK)
                                    {
                                        log.Info(
                                            $"Successfully sendt :{response.StatusCode} {response.ReasonPhrase}\n{responseString}");
                                        await _ediService.ChangeEdiStatus<TEntity>(ediMessage.Id, MessageStatus.TO_SEND,
                                            MessageStatus.SENDT);
                                        await ClearErrorMessage<TEntity>(ediMessage.Id);
                                    }
                                    else
                                    {
                                        string errorMessage =
                                            $"Cannot post message:{response.StatusCode} {response.ReasonPhrase}\n{responseString}";
                                        log.Error(errorMessage);
                                        await HandleException<TEntity>(ediMessage.Id, new Exception(errorMessage));
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                await HandleException<TEntity>(ediMessage.Id, e);
                            }
                        }
                    }
                }
            }
        }

        private bool ValidateMessage(byte[] data, out string resultMessage)
        {
            using (MemoryStream memStream = new MemoryStream(data))
            {
                List<IEdiItem> ediItems;
                using (var reader = new EdifactReader(memStream, "EdiFabric.Templates.Edifact",
                    new EdifactReaderSettings {ContinueOnError = true}))
                    ediItems = reader.ReadToEnd().ToList();

                foreach (var message in ediItems.OfType<EdiMessage>())
                {
                    if (!message.HasErrors)
                    {
                        //  Message was successfully parsed
                        MessageErrorContext mec;
                        if (message.IsValid(out mec))
                        {
                            //  Message was successfully validated
                            resultMessage = null;
                            return true;
                        }
                        else
                        {
                            //  Message failed validation with the following validation issues:
                            var validationIssues = mec.Flatten();
                            resultMessage = "EDI-Message could not be validated correct because: " +
                                            String.Join("\n", validationIssues);
                            return false;
                        }
                    }
                    else
                    {
                        string errorMessage = string.Join("\n", message.ErrorContext.Errors.Select(x => x.AsString()));
                        //  Message was partially parsed with errors
                        resultMessage = $"Could not parse EDI-Message!\n {errorMessage}";
                        var ex = new ValidateException(resultMessage);
                        throw ex;
                    }
                }
            }
            resultMessage = "Data not found or document type is wrong.";
            return false;

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // Store the task we're executing
            _executingTask = ExecuteAsync(_stoppingCts.Token);

            // If the task is completed then return it,
            // this will bubble cancellation and failure to the caller
            if (_executingTask.IsCompleted)
            {
                return _executingTask;
            }

            // Otherwise it's running
            return Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop called without start
            if (_executingTask == null)
            {
                return;
            }

            try
            {
                // Signal cancellation to the executing method
                _stoppingCts.Cancel();
            }
            finally
            {
                // Wait until the task completes or the stop token triggers
                await Task.WhenAny(
                    _executingTask,
                    Task.Delay(
                        Timeout.Infinite,
                        cancellationToken));
            }
        }
    }
}