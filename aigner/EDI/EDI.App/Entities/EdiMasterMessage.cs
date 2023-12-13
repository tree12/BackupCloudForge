using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
	/// <summary>
	/// BGM - Beginning of Message
	/// </summary>
	public class EdiMasterMessage: EdiUnbHeader
    {
        /*******************************Header*******************************/
        /// <summary>
        /// C002 Document/message name C -1001 Document/message name,
        /// </summary>
        public string DocumentName { get; set; }

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
        public DateTime DocumentDate { get; set; }
        /******UNH********/
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
        /******UNH********/

        /// <summary>
        /// 0080 25 FTX C 99 1 Free text
        /// 4451 Text subject qualifier M an..3 M an..3 AAI General information
        ///
        /// </summary>
        public string TextSubjectqualifier { get; set; }
        /// <summary>
        /// 0070 6 FTX C 99 1 Free text
        /// 4453 Text function, coded C an..3 C an..3 1 Text for subsequent use
        /// 
        /// </summary>
        public string TextFunctionCode { get; set; }
        /// <summary>
        /// 0070 6 FTX C 10 1 Free text
        /// C107 Text reference C
        ///
        /// 4441 Free text, coded M an..3
        /// </summary>
        public string FreeTextCode { get; set; }
        /// <summary>
        /// 0070 6 FTX C 10 1 Free text
        /// C108 Text literal C
        ///
        /// 4440 Free text M an..70
        /// </summary>
        public string TaxFreeTextCode { get; set; }
        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1153 Reference qualifier M an..3 
        ///
        /// ON Order number (purchase)
        /// </summary>
        public string ReferenceQualifier { get; set; }

        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// 0080 SG1 C 10 1 RFF-DTM
        /// 0100 8 DTM C 5 2 Date/time/period
        ///
        /// 
        /// </summary>
        public DateTime ReferenceDate { get; set; }

        /*******************************Footer*******************************/
        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0074 Number of segments in a message M n..6
        ///
        /// The total number of segments in the message is detailed here.
        /// </summary>
        public string NumberOfSegment { get; set; }
        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0062 Message reference number M an..14
        ///
        /// The message reference number detailed here should equal the one specified in the UNH segment.
        /// </summary>
        public string MessageReferenceNumber { get; set; }
        /// <summary>
        /// 0000 32 UNZ M 1 0 INTERCHANGE TRAILER - 0036 Interchange control count M n..6
        ///
        /// 
        /// </summary>
        public string InterchangeControlCount { get; set; }
        /// <summary>
        /// 0000 32 UNZ M 1 0 INTERCHANGE TRAILER - 0020 Interchange control reference M an..14
        ///
        /// 
        /// </summary>
        public string UnzInterchangeControlReference { get; set; }

        public void init(BGM bgm)
        {
            if (bgm != null)
            {
                MessageFunction = bgm.Messagefunctioncoded_03;
                DocumentNumber = bgm.Documentmessagenumber_02;
                DocumentName = bgm.DOCUMENTMESSAGENAME_01?.Documentmessagename_04;
            }

        }

        public void init(UNH unh)
        {
            if (unh != null)
            {
                UnhMessageReferenceNumber = unh.MessageReferenceNumber_01;
                TypeIdentifier = unh.MessageIdentifier_02?.MessageType_01;
                TypeVersionNumber = unh.MessageIdentifier_02?.MessageVersionNumber_02;
                TypeReleaseNumber = unh.MessageIdentifier_02?.MessageReleaseNumber_03;
                ControllingAgency = unh.MessageIdentifier_02?.ControllingAgencyCoded_04;
            }
 
        }

        public void init(FTX ftx)
        {
            if (ftx != null)
            {
                TextSubjectqualifier = ftx.Textsubjectqualifier_01;
                TextFunctionCode = ftx.Textfunctioncoded_02;
                FreeTextCode = ftx.TEXTREFERENCE_03?.Freetextcoded_01;
                TaxFreeTextCode = ftx.TEXTREFERENCE_03?.Codelistqualifier_02;
            }

        }
        public void init(UNT unt)
        {
            if (unt != null)
            {
                NumberOfSegment = unt.NumberofSegmentsinaMessage_01;
                MessageReferenceNumber = unt.MessageReferenceNumber_02;
            }

        }
        public void init(UNZ unz)
        {
            if (unz != null)
            {
                InterchangeControlCount = unz.InterchangeControlCount_1;
                UnzInterchangeControlReference = unz.InterchangeControlReference_2;
            }

        }
    }
}
