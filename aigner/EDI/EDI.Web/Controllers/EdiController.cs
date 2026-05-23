using EDI.Web.Models;
using EDI.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities;
using EDI.DataAccess.Entities.Interfaces;
using EDI.Web.Filters;
using EDI.Web.Util;
using EdiFabric;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Framework.Readers;
using EdiFabric.Templates.EdifactD96A;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace EDI.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EdiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RequestLogService _requestLogService;
        private readonly List<UserInfo> _userInfos;
        private readonly EdiService _ediService;

        private readonly EdiConfig _ediConfig;
        private static ILog log = LogManager.GetLogger(typeof(EdiController));

        public EdiController(IUserService userService, RequestLogService requestLogService, IOptions<List<UserInfo>> userInfos, IServiceProvider serviceProvider, IOptions<EdiConfig> ediConfig)
        {
            _userService = userService;
            _requestLogService = requestLogService;
            _userInfos = userInfos.Value;
            _ediService = new EdiService(serviceProvider);
            _ediConfig = ediConfig.Value;
            SerialKey.Set(_ediConfig.EdiSecretKey);

        }

        // POST api/Edi
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var ipAddress = HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);

                log.Info($"Receiving Request from {userName} [{ipAddress} ID: {userId}].");
                var body = await LogRequestToDb(false);
                body = body.ReplaceAndRemoveDiacritics();
                byte[] byteArray = Encoding.UTF8.GetBytes(body);
                MemoryStream stream = new MemoryStream(byteArray);

                var ediMasterMessage = GenerateMessage(stream);
                ediMasterMessage.Status = MessageStatus.RECEIVED;
                await _ediService.AddEdi(ediMasterMessage);

                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return BadRequest("Cannot convert data: " + ex.Message);
            }


        }


        private async Task<string> LogRequestToDb(bool outDirection)
        {
            HttpContext.Request.EnableBuffering();
            var reader = await Request.BodyReader.ReadAsync();
            Request.Body.Position = 0;
            var buffer = reader.Buffer;
            //var byteToWrite = buffer.ToArray();
            var body = Encoding.UTF8.GetString(buffer.FirstSpan);
            await _requestLogService.LogRequestAsync(User, body);
            Request.Body.Position = 0;

            return body;
        }

        // POST api/Edi/testAuthentication
        [AllowAnonymous]
        [HttpPost("testAuthentication")]
        public async Task<IActionResult> TestAuthentication([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
        }
        //[HttpGet("saveEdiToDB")]
        private async Task<IActionResult> SaveEdiToDB()
        {

            SerialKey.Set(_ediConfig.EdiSecretKey);
            var path = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\..\Data\orders-d.96a-ktm_1_0.txt");
            //var pathOrdchg = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\..\Data\ordchg-d.96a-ktm_1_0.txt");
            var pathInvoice = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\..\Data\invoic-d.96a-ktm_1_0.txt");
            var pathSchedule = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\..\Data\delfor-d.96a-ktm_1_0.txt");
            var pathConfirm = System.IO.File.OpenRead(Directory.GetCurrentDirectory() + @"\..\Data\ordrsp-d.96a-ktm_1_0.txt");

            EdiOrder ediOrder = (EdiOrder)GenerateMessage(path);
            EdiInvoice ediInvoice = (EdiInvoice)GenerateMessage(pathInvoice);
            //EdiOrderChange ediOrderChange = (EdiOrderChange)GenerateMessage(pathOrdchg);
            EdiScheduleAgreement ediScheduleAgreement = (EdiScheduleAgreement)GenerateMessage(pathSchedule);
            EdiOrderConfirmation ediOrderConfirmation = (EdiOrderConfirmation)GenerateMessage(pathConfirm);

            await _ediService.AddEdi(ediOrder);
            await _ediService.AddEdi(ediInvoice);
            //await _ediService.AddEdi(ediOrderChange);
            await _ediService.AddEdi(ediScheduleAgreement);
            await _ediService.AddEdi(ediOrderConfirmation);

            return Ok();
        }

        //[HttpGet("createEdiFile")]
        private async Task<IActionResult> CreateEdiFile()
        {
            string[] filePaths = Directory.GetFiles(@"DataFiles\");
            foreach (string filePath in filePaths)
            {
                System.IO.File.Delete(filePath);
            }


            var ediOrder = await _ediService.GetOrder();
            if (ediOrder != null)
            {
                var order = ediOrder.CreateEdiDocument();
                ConvertEdiFact.WriteFile(ediOrder, order, @"DataFiles\orderFile.txt");
            }

            //var ediOrderChange = await _ediService.GetOrderChange();
            //if (ediOrderChange != null)
            //{
            //    var orderChange = ConvertEdiFact.BuildPurchaseOrder(ediOrderChange);
            //    ConvertEdiFact.WriteFile(ediOrderChange, orderChange, @"DataFiles\orderChangeFile.txt");
            //}
            var ediOrderConfirmation = await _ediService.GetOrderComfirmation();
            if (ediOrderConfirmation != null)
            {
                var orderConfirmation = ediOrderConfirmation.CreateEdiDocument();
                ConvertEdiFact.WriteFile(ediOrderConfirmation, orderConfirmation, @"DataFiles\orderConfirmationFile.txt");
            }
            var ediInvoice = await _ediService.GetInvoice();
            if (ediInvoice != null)
            {
                var invoice = ediInvoice.CreateEdiDocument();
                ConvertEdiFact.WriteFile(ediInvoice, invoice, @"DataFiles\invoiceFile.txt");
            }

            return Ok();
        }

        [HttpGet("downloadEdiFile")]
        public async Task<ActionResult> downloadEdiFile()
        {

            try
            {
                var createFileResult = (OkResult)await CreateEdiFile();
                var (fileType, archiveData, archiveName) = DownloadFiles("DataFiles");

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        private (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now:yyyy_MM_dd-HH_mm_ss}.zip";

            var files = Directory.GetFiles(Path.Combine(subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        if (!file.Contains(".gitkeep"))
                        {
                            var theFile = archive.CreateEntry(file);
                            using (var streamWriter = new StreamWriter(theFile.Open()))
                            {
                                streamWriter.Write(System.IO.File.ReadAllText(file));
                            }
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }
        public static IEdiMasterMessage GenerateMessage(Stream path)
        {
            List<IEdiItem> ediItems;
            using (var reader = new EdifactReader(path, "EdiFabric.Templates.Edifact", new EdifactReaderSettings { ContinueOnError = true }))
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
                        return ProcessEdiMessage(ediItems);
                    }
                    else
                    {
                        //  Message failed validation with the following validation issues:
                        var validationIssues = mec.Flatten();
                        var ex = new Exception("EDI-Message could  not be validated correct because: " + String.Join("\n", validationIssues));
                        log.Warn(ex);
                        return ProcessEdiMessage(ediItems);
                    }
                }
                else
                {
                    string errorMessage = string.Join("\n", message.ErrorContext.Errors.Select(x => x.AsString()));
                    //  Message was partially parsed with errors
                    var ex = new Exception($"Could not parse EDI-Message!\n {errorMessage}");
                    log.Error(ex);
                    throw ex;
                }
            }
            var exception = new Exception("EDI-Message is empty!");
            log.Error(exception);
            throw exception;

        }

        private static IEdiMasterMessage ProcessEdiMessage(List<IEdiItem> ediItems)
        {
            //var unas = ediItems.OfType<UNA>();
            var unbs = ediItems.OfType<UNB>();
            var unzs = ediItems.OfType<UNZ>();
            if (unbs.Count() != 1) throw new EdiException("UNB Should be only one!");
            var unb = unbs.First();
            if (unzs.Count() != 1) throw new EdiException("UNZ Should be only one!");
            var unz = unzs.First();
            var ediMessages = ediItems.OfType<EdiMessage>();
            if (ediMessages.Any())
            {

                var ediMessage = ediMessages.FirstOrDefault();
                if (ediMessage == null)
                {
                    throw new EdiException("Document is empty.");
                }
                if (typeof(TSORDERS) == ediMessage.GetType() || typeof(TSORDCHG) == ediMessage.GetType())
                {
                    var target = new EdiOrder();
                    target.init(unb);
                    if (typeof(TSORDERS) == ediMessage.GetType()) 
                        target.init((TSORDERS)ediMessage); 
                    else 
                        target.init((TSORDCHG)ediMessage);
                    return target;
                }
                else if (typeof(TSINVOIC) == ediMessage.GetType())
                {
                    var target = new EdiInvoice();
                    target.init(unb);
                    target.init((TSINVOIC)ediMessage);
                    return target;
                }
                else if (typeof(TSDELFOR) == ediMessage.GetType())
                {
                    var target = new EdiScheduleAgreement();

                    target.init(unb);
                    target.init((TSDELFOR)ediMessage);
                    return target;
                }
                else if (typeof(TSORDRSP) == ediMessage.GetType())
                {
                    var target = new EdiOrderConfirmation();

                    target.init(unb);
                    target.init((TSORDRSP)ediMessage);
                    return target;
                }
                else if (typeof(TSDESADV) == ediMessage.GetType())
                {
                    var target = new EdiDeliveryNote();

                    target.init(unb);
                    target.init((TSDESADV)ediMessage);
                    return target;
                }
                else
                {
                    throw new EdiException("Document type not support.");
                }

            }
            else
            {
                throw new EdiException("Document not found.");
            }


        }

        [HttpPost("testTokenFromWeb")]
        [AllowAnonymous]
        public async Task<IActionResult> getTokenFromWeb()
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(_ediConfig.UserName + ":" + _ediConfig.Password);
            string user = Convert.ToBase64String(plainTextBytes);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Basic", user);
            client.BaseAddress = new Uri(_ediConfig.EcosioUrl);
            HttpResponseMessage response = await client.PostAsync(_ediConfig.EcosioUrl, null);
            var result = await response.Content.ReadAsStringAsync();
            return Content(result);
        }

    }
}