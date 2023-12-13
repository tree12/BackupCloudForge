using System;
using System.Collections.Generic;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Templates.EdifactD96A;
using Portal.Common.Entity.Abstracts;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IEdiMasterMessage
    {
        /// <summary>
        /// C002 Document/message name C -1001 Document/message name,
        /// </summary>
        public string DocumentNameCode { get; set; }

        /// <summary>
        /// 1004 Document/message number C an..35
        ///
        /// Unique identifier of a document.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 1225 Message function, coded C an..3
        ///
        /// 9 Original
        /// The message function of the given document.
        /// </summary>
        public string MessageFunction { get; set; }

        ///----------------------------------------------------------
        /// <summary>
        /// 0030 5 DTM M 35 1 Date/time/period
        /// 
        /// </summary>
        public DateTime? DocumentDate { get; set; }

        /// <summary>
        /// 0062 Message reference number M an..14
        ///
        /// </summary>
        public string UnhMessageReferenceNumber { get; set; }

        /// <summary>
        /// 0065 Message reference number M an..6
        ///
        /// </summary>
        public string TypeIdentifier { get; set; }

        /// <summary>
        /// 0052 Message type version number M an..3
        ///
        /// </summary>
        public string TypeVersionNumber { get; set; }

        /// <summary>
        /// 0054 Message type release number M an..3
        ///
        /// </summary>
        public string TypeReleaseNumber { get; set; }

        /// <summary>
        /// 0051 Controlling agency M an..2
        ///
        /// </summary>
        public string ControllingAgency { get; set; }

        ///// <summary>
        ///// 0070 6 FTX C 99 1 Free text
        ///// 4453 Text function, coded C an..3 C an..3 1 Text for subsequent use
        /////
        ///// Free Text
        /////
        ///// only if this is true: 4451 Text subject qualifier M an..3 M an..3 AAI General information
        ///// </summary>
        //public string TextSubjectqualifier { get; set; }

        ///// <summary>
        ///// 0070 6 FTX C 10 1 Free text
        ///// C107 Text reference C
        /////
        ///// 4441 Free text, coded M an..3
        ///// </summary>
        //public string FreeTextCode { get; set; }

        /////// <summary>
        /////// 0070 6 FTX C 10 1 Free text
        /////// C107 Text reference C
        ///////
        /////// 1131 Code list qualifier C an..3
        /////// </summary>
        ////public string CodeListQualifier { get; set; }

        ///// <summary>
        ///// 0070 6 FTX C 10 1 Free text
        ///// C108 Text literal C
        /////
        ///// 4440 Free text M an..70
        ///// </summary>
        //public string TextLiteralFreeText { get; set; }

        /////<summary>
        ///// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        ///// 6347 Currency details qualifier M an..3 M an..3 2 Reference currency
        /////</summary>
        //public string CurrencyDetailsQualifier { get; set; }

        ///// <summary>
        ///// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        ///// 6345 Currency, coded C an..3 M an..3 Is required in ISO 4217 three alpha standard, e.g. EUR.
        ///// </summary>
        //public string Currency { get; set; }
        /////<summary>
        ///// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        ///// 6343 Currency qualifier C an..3 M an..3 4 Invoicing currency
        /////</summary>
        //public string CurrencyQualifier { get; set; }


        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0074 Number of segments in a message M n..6
        ///
        /// The total number of segments in the message is detailed here.
        /// </summary>
        //public int? NumberOfSegment { get; set; }

        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0062 Message reference number M an..14
        ///
        /// The message reference number detailed here should equal the one specified in the UNH segment.
        /// </summary>
        public string MessageReferenceNumber { get; set; }


        /// <summary>
        /// 0000 2 UNB M 1 0 INTERCHANGE HEADER - S001 SYNTAX IDENTIFIER M 
        ///
        /// 0001 Syntax identifier M a4 - Used character set
        /// </summary>
        string SyntaxIdentifier { get; set; }

        /// <summary>
        /// 0000 2 UNB M 1 0 INTERCHANGE HEADER - S001 SYNTAX IDENTIFIER M 
        ///
        /// 0002 Syntax version number M n1
        /// </summary>
        string SyntaxVersionNumber { get; set; }

        /// <summary>
        /// S002 INTERCHANGE SENDER M - 0004 Sender identification M an..35
        ///
        /// Unique ID of the sender. Is always KTMAG.
        /// </summary>
        string SenderUniqueId { get; set; }

        /// <summary>
        /// S002 INTERCHANGE SENDER M - Partner identification codequalifier C an..4
        ///
        /// ZZZ Mutually defined
        /// </summary>
        string SenderCode { get; set; }

        /// <summary>
        /// S003 INTERCHANGE RECIPIENT M - 0010 Recipient identification M an..35
        ///
        /// ZZZ Mutually
        /// </summary>
        string RecipientUniqueId { get; set; }

        /// <summary>
        /// 0007 Partner identification code qualifier C an..4
        /// 
        /// 1 DUNS (Dun &amp; Bradstreet)
        /// 14 EAN (European Article Numbering Association)
        /// ZZZ Mutually defined
        /// </summary>
        string RecipientCode { get; set; }

        /// <summary>
        /// 0017 Date of preparation M n6 + 0019 Time of preparation M n4
        /// </summary>
        DateTime? DateOfPreparation { get; set; }

        /// <summary>
        /// 0020 Interchange control reference M an..14
        /// 
        /// Unique reference identifying the interchange.Created by the interchange sender.
        /// </summary>
        string InterchangeControlReference { get; set; }

        /// <summary>
        /// 0035 Test indicator C n1
        ///
        /// 1 Interchange is a test
        /// Test indicator. 1 = test message. Empty = production message.
        /// </summary>
        bool? IsTestMessage { get; set; }

        MessageStatus? Status { get; set; }
        public string SendErrorMessage { get; set; }

        public int SendErrorCount { get; set; }

        public string SendValidationError  { get; set; }

        int Id { get; set; }

        //DateTime? CreatedDate { get; set; }

        //DateTime? ModifiedDate { get; set; }

        //string CreatedUserId { get; set; }

        //string CreatedUserName { get; set; }

        //string ModifiedUserId { get; set; }

        //string ModifiedUserName { get; set; }

        //object IdAsObject { get; }

        public void init(BGM bgm);

        public void init(UNH unh);

        public void init(UNT unt);

       // public void init(UNZ unz);

        void init(UNB unb);

        #region Generate EDI object

        public UNH generateUNH();

        public BGM generateBGM();

        public DTM generateDocumentDTM();

 



        public UNS generateUNS();

        //public UNT generateUNT();

      

        #endregion

    }
}