using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using EDI.App.Entities;
using log4net;
using EdiFabric;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Framework.Readers;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App
{
    class Program
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();

            log.Info("Started Aigner.EDI.App");

            //  Supported versions/transactions are:
            //  EDIFACT D96A, all classes that begin with TS in namespace EdiFabric.Templates.EdifactD96A
            //  Custom CUSCAR and PAXLST version EDIFACT D03B for US Customs, the classes are TSCUSCAR and TSPAXLST in namespace EdiFabric.Templates.EdifactD03B
            //  Custom BAPLIE version EDIFACT D13B for SMDG, the class is TSBAPLIE in namespace EdiFabric.Templates.EdifactD13B
            //  INVOIC EANCOM D01B Syntax 3, the class is TSINVOIC in namespace EdiFabric.Templates.EancomD01B

            //  If you need a different EDIFACT/EANCOM version or transaction, please contact us at https://support.edifabric.com/hc/en-us/requests/new, EdiFabric supports all versions and transaction for EDIFACT/EANCOM.

            //SerialKey.Set("A6XO4-V7LOW-TLISG-VGMIF-KZGVD-FFF3U-GUMVT-75ODO-NBYXX-MHAQD-N7N2D-AXG");
            SerialKey.Set("42QRJ-ZXKIN-4KTOH-GWC3Y-WSJNE-D24WX-VNOTU-OUGQF-YYBYU-X6HF5-E3LE2-PNA");


            //  Change the path to point to your own file to test with
            //var path = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\PurchaseOrders.txt");
            var path = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\orders-d.96a-ktm_1_0.txt");
            var pathOrdchg = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\ordchg-d.96a-ktm_1_0.txt");
            var pathInvoice = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\invoic-d.96a-ktm_1_0.txt");
            var pathSchedule = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\delfor-d.96a-ktm_1_0.txt");
            var pathConfirm = File.OpenRead(Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\ordrsp-d.96a-ktm_1_0.txt");

            EdiOrder ediOrder = (EdiOrder)GenerateMessage(path, "order");
            EdiInvoice ediInvoice = (EdiInvoice)GenerateMessage(pathInvoice, "invoice");
            EdiOrderChange ediOrderChange = (EdiOrderChange)GenerateMessage(pathOrdchg, "orderchg");
            EdiScheduleAgreement ediScheduleAgreement = (EdiScheduleAgreement)GenerateMessage(pathSchedule, "schedule");
            EdiOrderConfirmation ediOrderConfirmation = (EdiOrderConfirmation)GenerateMessage(pathConfirm, "confirmation");

            //using (var db = new EdiDbContext())  //Save order to db
            //{
            //    foreach (var purchaseOrder in purchaseOrders)
            //    {
            //        purchaseOrder.ClearCache();
            //        db.TSORDERS.Add(purchaseOrder);
            //    }
            //    db.SaveChanges();
            //}
        }
        private static EdiMasterMessage GenerateMessage(FileStream path, string docType)
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
                    }
                    else
                    {
                        //  Message failed validation with the following validation issues:
                        var validationIssues = mec.Flatten();
                    }
                }
                else
                {
                    //  Message was partially parsed with errors
                }
            }
            //var unas = ediItems.OfType<UNA>();
            var unbs = ediItems.OfType<UNB>();
            var unzs = ediItems.OfType<UNZ>();
            if (unbs.Count() != 1) throw new EdiException("UNB Should be only one!");
            var unb = unbs.First();
            if (unzs.Count() != 1) throw new EdiException("UNZ Should be only one!");
            var unz = unzs.First();
            if (docType == "order")
            {
                var tsorders = ediItems.OfType<TSORDERS>();
                var target = new EdiOrder();
                foreach (var tsorder in tsorders)
                {
                    target.init(unb);
                    target.init(tsorder);
                    target.init(unz);
                }

                return target;
            }
            else if (docType == "invoice")
            {
                var tsinvoices = ediItems.OfType<TSINVOIC>();
                var target = new EdiInvoice();
                foreach (var tsinvoice in tsinvoices)
                {
                    target.init(unb);
                    target.init(tsinvoice);
                    target.init(unz);
                }
                return target;
            }
            else if (docType == "orderchg")
            {
                var tsordchgs = ediItems.OfType<TSORDCHG>();
                var target = new EdiOrderChange();
                foreach (var tsordchg in tsordchgs)
                {
                    target.init(unb);
                    target.init(tsordchg);
                    target.init(unz);
                }
                return target;
            }
            else if (docType == "schedule")
            {
                var tsschedules = ediItems.OfType<TSDELFOR>();
                var target = new EdiScheduleAgreement();
                foreach (var tsschedule in tsschedules)
                {
                    target.init(unb);
                    target.init(tsschedule);
                    target.init(unz);
                }
                return target;
            }
            else if (docType == "confirmation")
            {
                var tsConfirmations = ediItems.OfType<TSORDRSP>();
                var target = new EdiOrderConfirmation();
                foreach (var tsConfirmation in tsConfirmations)
                {
                    target.init(unb);
                    target.init(tsConfirmation);
                    target.init(unz);
                }
                return target;
            }
            else
            {
                throw new EdiException("Document type not support.");
            }


        }
    }   //  Add a breakpoint here, run in debug mode and inspect ediItems


    public class EdiException : Exception
    {
        public EdiException()
        {
        }

        protected EdiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EdiException(string? message) : base(message)
        {
        }

        public EdiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
