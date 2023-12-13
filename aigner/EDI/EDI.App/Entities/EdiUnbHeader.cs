using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Core.Model.Edi.Edifact;
using Mapster;

namespace EDI.App.Entities
{
    /// <summary>
    /// UNB - NTERCHANGE HEADER
    /// </summary>
    public class EdiUnbHeader : BaseEntity
    {
        /// <summary>
        /// S002 INTERCHANGE SENDER M - 0004 Sender identification M an..35
        ///
        /// Unique ID of the sender. Is always KTMAG.
        /// </summary>
        public string SenderUniqueId { get; set; }

        /// <summary>
        /// S002 INTERCHANGE SENDER M - Partner identification codequalifier C an..4
        ///
        /// ZZZ Mutually defined
        /// </summary>
        public string SenderCode { get; set; }

        /// <summary>
        /// S003 INTERCHANGE RECIPIENT M - 0010 Recipient identification M an..35
        ///
        /// ZZZ Mutually
        /// </summary>
        public string RecipientUniqueId { get; set; }

        /// <summary>
        /// 0007 Partner identification code qualifier C an..4
        /// 
        /// 1 DUNS (Dun &amp; Bradstreet)
        /// 14 EAN (European Article Numbering Association)
        /// ZZZ Mutually defined
        /// </summary>
        public string RecipientCode { get; set; }

        /// <summary>
        /// 0017 Date of preparation M n6 + 0019 Time of preparation M n4
        /// </summary>
        public DateTime DateOfPreparation { get; set; }

        /// <summary>
        /// 0020 Interchange control reference M an..14
        /// 
        /// Unique reference identifying the interchange.Created by the interchange sender.
        /// </summary>
        public string InterchangeControlReference { get; set; }

        /// <summary>
        /// 0035 Test indicator C n1
        ///
        /// 1 Interchange is a test
        /// Test indicator. 1 = test message. Empty = production message.
        /// </summary>
        public bool IsTestMessage { get; set; }

        public MessageStatus MessageStatus { get; set; }

        public void init(UNB unb)
        {
            IsTestMessage = unb.TestIndicator_11?.Equals("1") ?? false;
            InterchangeControlReference = unb.InterchangeControlReference_5;
            DateOfPreparation = unb.DATEANDTIMEOFPREPARATION_4.asDateTime();
            SenderUniqueId = unb.INTERCHANGESENDER_2.InterchangeSenderIdentification_1;
            SenderCode = unb.INTERCHANGESENDER_2.IdentificationCodeQualifier_2;
            RecipientUniqueId = unb.INTERCHANGERECIPIENT_3.InterchangeRecipientIdentification_1;
            RecipientCode = unb.INTERCHANGERECIPIENT_3.IdentificationCodeQualifier_2;
        }
    }

    public enum MessageStatus
    {
        /// <summary>
        /// Every Message we get over the web-interface should have this value
        /// </summary>
        RECIVED=1,
        RECIVED_AND_PROCESSED=2,
        TO_SEND=3,
        SENDT=4
    }
}
