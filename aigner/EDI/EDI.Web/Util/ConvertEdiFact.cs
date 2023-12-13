using System;
using System.IO;
using System.Reflection;
using System.Text;
using EDI.DataAccess.Entities;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Framework;
using EdiFabric.Framework.Writers;


namespace EDI.Web.Util
{
    public class ConvertEdiFact
    {
        ///
        /// Build UNB.
        /// 
        public static UNB BuildUnb(IEdiMasterMessage ediMasterMessage)
        {
            //I use EdiInvoice because EdiMasterMessage need one TType. It doesn't matter because I just want CreatedDate field.
            PropertyInfo info = ediMasterMessage.GetType().GetProperty(nameof(EdiMasterMessage<EdiInvoice>.CreatedDate));
            DateTime? createDateTime = info != null ? (DateTime)info.GetValue(ediMasterMessage)! : null;
            return new UNB
            {
                SYNTAXIDENTIFIER_1 = new S001
                {
                    //  Syntax Identifier
                    SyntaxIdentifier_1 = ediMasterMessage.SyntaxIdentifier,
                    //  Syntax Version Number
                    SyntaxVersionNumber_2 = ediMasterMessage.SyntaxVersionNumber
                },
                INTERCHANGESENDER_2 = new S002
                {
                    //  Interchange sender identification
                    InterchangeSenderIdentification_1 = ediMasterMessage.SenderUniqueId,
                    //  Identification code qualifier
                    IdentificationCodeQualifier_2 = ediMasterMessage.SenderCode,
                    //  Interchange sender internal identification
                    //InterchangeSenderInternalIdentification_3 = "ZZZ"
                },
                INTERCHANGERECIPIENT_3 = new S003
                {
                    //  Interchange recipient identification
                    InterchangeRecipientIdentification_1 = ediMasterMessage.RecipientUniqueId,
                    //  Identification code qualifier
                    IdentificationCodeQualifier_2 = ediMasterMessage.RecipientCode,
                    //  Interchange recipient internal identification
                    //InterchangeRecipientInternalIdentification_3 = "ZZZ"
                },
                DATEANDTIMEOFPREPARATION_4 = new S004
                {
                    //  Date
                    Date_1 = ediMasterMessage.DateOfPreparation != null ? ediMasterMessage.DateOfPreparation?.ToString("yyMMdd") : createDateTime?.ToString("yyMMdd"),
                    //  Time
                    Time_2 = ediMasterMessage.DateOfPreparation != null ? ediMasterMessage.DateOfPreparation?.TimeOfDay.ToString("hhmm") : createDateTime?.TimeOfDay.ToString("hhmm")
                },
                //  Interchange control reference (Use Id instead InterchangeControlReference because it's unique.)
                InterchangeControlReference_5 = ediMasterMessage.Id.ToString(),
                TestIndicator_11 = ediMasterMessage.IsTestMessage != null ? (ediMasterMessage.IsTestMessage.Value ? "1" : "0") : null,

            };
        }
        //public static UNZ BuildUnz(IEdiMasterMessage ediMasterMessage)
        //{
        //    return new UNZ
        //    {
        //        //  Interchange control reference
        //        InterchangeControlCount_1 = ediMasterMessage.InterchangeControlCount?.ToString(),
        //        InterchangeControlReference_2 = ediMasterMessage.UnzInterchangeControlReference
        //    };
        //}

        public static void WriteFile(IEdiMasterMessage ediMasterMessage, EdiMessage ediMessage, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, System.IO.FileAccess.Write))
            {
                EdifactWriterSettings settings = new EdifactWriterSettings();
                settings.AutoTrailers = true;
                settings.Encoding = new UTF8Encoding(false);
                //settings.Postfix = Environment.NewLine;
                settings.PreserveWhitespace = true;
                settings.Separators = Separators.Edifact;
                using (var writer = new EdifactWriter(stream, settings))
                {
                    //  Write custom UNA
                    writer.Write(Separators.Edifact.ToUna());
                    writer.Write(BuildUnb(ediMasterMessage), Separators.Edifact);

                    //  1.  Write the first order
                    writer.Write(ediMessage);
                    //  2.  Write the second invoice
                    //writer.Write(SegmentBuilders.BuildInvoice("2"));

                }

            }

        }
        public static byte[] GetEdiDataAsBytes(IEdiMasterMessage ediMasterMessage, EdiMessage ediMessage)
        {

            var settings = new EdifactWriterSettings() { Separators = Separators.Edifact };
            //using (var stream = new MemoryStream())
            //{
            var stream = new MemoryStream();
            settings.AutoTrailers = true;
            settings.Encoding = new UTF8Encoding(false);
            //settings.Postfix = Environment.NewLine;
            settings.PreserveWhitespace = true;
            settings.Separators = Separators.Edifact;
            using (var writer = new EdifactWriter(stream, settings))
            {
                //  Write custom UNA
                writer.Write(Separators.Edifact.ToUna());
                writer.Write(BuildUnb(ediMasterMessage), Separators.Edifact);

                //  1.  Write the first order
                writer.Write(ediMessage);
                //  2.  Write the second invoice
                //writer.Write(SegmentBuilders.BuildInvoice("2"));
            }

            stream.Flush();
            //Cannot use stream.GetBuffer() because it will grow to twice its previous size each time(We have problem if convert byte array to string. it's not equal to compare(There are byte value 0 at the end of string))
            return stream.ToArray();

        }


    }
}
