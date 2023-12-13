using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Attributes;
using Portal.Common.Entity.Abstracts;
using Portal.Common.Entity.Interfaces;

namespace EDI.DataAccess.Entities
{
    /// <summary>
    /// BGM - Beginning of Message
    /// </summary>
    [AuditLog]
    public abstract class EdiMasterMessage<TType> : BaseEdiObject<TType>, IEdiMasterMessage, ISupplier, IDelivery where TType : BaseEdiObject<TType>
    {
        public abstract EdiMessage CreateEdiDocument();
        public EdiMasterMessage()
        {
        }

        /************************EdiMessageHeader***********************/
        /// <summary>
        /// 0000 2 UNB M 1 0 INTERCHANGE HEADER - S001 SYNTAX IDENTIFIER M 
        ///
        /// 0001 Syntax identifier M a4 - Used character set
        /// </summary>
        public string SyntaxIdentifier { get; set; }
        /// <summary>
        /// 0000 2 UNB M 1 0 INTERCHANGE HEADER - S001 SYNTAX IDENTIFIER M 
        ///
        /// 0002 Syntax version number M n1
        /// </summary>
        public string SyntaxVersionNumber { get; set; }
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
        public DateTime? DateOfPreparation { get; set; }

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
        public bool? IsTestMessage { get; set; }

        public MessageStatus? Status { get; set; }

        public string SendErrorMessage { get; set; }

        public int SendErrorCount { get; set; }

        public string SendValidationError { get; set; }
        /**********************************************/

        /*******************************Header*******************************/
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


        ///// <summary>
        ///// 0110 SG2 C 99 1 NAD-SG5
        ///// </summary>
        //public NameAndAddress Buyer { get; set; }

        ///// <summary>
        /////  0110 SG2 C 99 1 NAD
        ///// </summary>
        //public NameAndAddress Supplier { get; set; }
        ///// <summary>
        /////  0110 SG2 C 99 1 NAD-LOC
        ///// </summary>
        //public NameAndAddress DeliveryRecipient { get; set; }

        ///// <summary>
        ///// 0420 SG11 C 5 1 TOD-LOC
        ///// </summary>
        //public DeliveryOrTransportTerm DeliveryOrTransportTerm { get; set; }
        ///// <summary>
        ///// 0930 SG25 C 200000 1 LIN-PIA-IMD-QTY-FTX-SG28-SG49
        ///// </summary>
        //public List<LineItem> LineItems { get; set; }

        /*/*******************************Footer******************************#1#
        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0074 Number of segments in a message M n..6
        ///
        /// The total number of segments in the message is detailed here.
        /// </summary>
        public int? NumberOfSegment { get; set; }*/
        /// <summary>
        /// 2160 31 UNT M 1 0 MESSAGE TRAILER - 0062 Message reference number M an..14
        ///
        /// The message reference number detailed here should equal the one specified in the UNH segment.
        /// </summary>
        public string MessageReferenceNumber { get; set; }
        ///// <summary>
        ///// 0000 32 UNZ M 1 0 INTERCHANGE TRAILER - 0036 Interchange control count M n..6
        /////
        ///// 
        ///// </summary>
        //public int? InterchangeControlCount { get; set; }
        ///// <summary>
        ///// 0000 32 UNZ M 1 0 INTERCHANGE TRAILER - 0020 Interchange control reference M an..14
        /////
        ///// 
        ///// </summary>
        //public string UnzInterchangeControlReference { get; set; }


        #region Supplier
        public string Supplier_PartyQualifier { get; set; }
        public string Supplier_PartyId { get; set; }

        public string Supplier_ResponsibleAgency { get; set; }

        public string Supplier_CompanyName { get; set; }

        public string Supplier_Street { get; set; }

        public string Supplier_CityName { get; set; }

        public string Supplier_Postcode { get; set; }

        public string Supplier_CountryCode { get; set; }

        #endregion

        #region Delivery
        public string Delivery_PartyQualifier { get; set; }
        public string Delivery_PartyId { get; set; }

        public string Delivery_ResponsibleAgency { get; set; }

        public string Delivery_CompanyName { get; set; }

        //public string Delivery_PartyName1 { get; set; }

        //public string Delivery_PartyName2 { get; set; }

        public string Delivery_Street { get; set; }

        public string Delivery_CityName { get; set; }

        public string Delivery_Postcode { get; set; }

        public string Delivery_CountryCode { get; set; }


        #endregion

        public void init(UNB unb)
        {
            IsTestMessage = unb.TestIndicator_11?.Equals("1") ?? false;
            SyntaxIdentifier = unb.SYNTAXIDENTIFIER_1.SyntaxIdentifier_1;
            SyntaxVersionNumber = unb.SYNTAXIDENTIFIER_1.SyntaxVersionNumber_2;
            InterchangeControlReference = unb.InterchangeControlReference_5;
            DateOfPreparation = unb.DATEANDTIMEOFPREPARATION_4.asDateTime();
            SenderUniqueId = unb.INTERCHANGESENDER_2.InterchangeSenderIdentification_1;
            SenderCode = unb.INTERCHANGESENDER_2.IdentificationCodeQualifier_2;
            RecipientUniqueId = unb.INTERCHANGERECIPIENT_3.InterchangeRecipientIdentification_1;
            RecipientCode = unb.INTERCHANGERECIPIENT_3.IdentificationCodeQualifier_2;
        }
        public void init(BGM bgm)
        {
            if (bgm != null)
            {
                MessageFunction = bgm.Messagefunctioncoded_03;
                DocumentNumber = bgm.Documentmessagenumber_02;
                DocumentNameCode = bgm.DOCUMENTMESSAGENAME_01?.Documentmessagenamecoded_01;
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

        public void init(UNT unt)
        {
            if (unt != null)
            {
                MessageReferenceNumber = unt.MessageReferenceNumber_02;
            }

        }

        public void initDocDate(DTM dtm)
        {
            if (dtm != null)
                DocumentDate = dtm.DATETIMEPERIOD_01.asDateTime();
        }
        //#region InitBuyer
        //public void initNADBY(NAD nad)
        //{
        //    Buyer_PartyQualifier = nad?.Partyqualifier_01;
        //    Buyer_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
        //    Buyer_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;

        //}
        //#endregion
        #region InitSupplier

        public void initNADSU(NAD nad)
        {
            Supplier_PartyQualifier = nad?.Partyqualifier_01;
            Supplier_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            Supplier_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;
            //Buyer_PartyQualifier = partyBuyer.NAD?.Partyqualifier_01;
            Supplier_CompanyName = nad?.PARTYNAME_04?.GenStringFromC080();
            //Supplier_CompanyName = nad?.PARTYNAME_04?.Partyname_01;
            //if (!string.IsNullOrEmpty(nad?.PARTYNAME_04?.Partyname_02))
            //{
            //    Supplier_CompanyName += nad.PARTYNAME_04?.Partyname_02;
            //}
            Supplier_Street = nad?.STREET_05?.Streetandnumberpobox_01;
            Supplier_CityName = nad?.Cityname_06;
            Supplier_Postcode = nad?.Postcodeidentification_08;
            Supplier_CountryCode = nad?.Countrycoded_09;

        }


        #endregion

        #region InitNADDP

        public void initNADDP(NAD nad)
        {
            Delivery_PartyQualifier = nad?.Partyqualifier_01;
            Delivery_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            Delivery_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;
            Delivery_CompanyName = nad?.PARTYNAME_04?.GenStringFromC080();// nad?.NAMEANDADDRESS_03?.GenStringFromC058();
            //Delivery_CompanyName = nad?.NAMEANDADDRESS_03?.Nameandaddressline_01;
            //if (!string.IsNullOrEmpty(nad?.NAMEANDADDRESS_03?.Nameandaddressline_02))
            //{
            //    Delivery_CompanyName += nad.NAMEANDADDRESS_03.Nameandaddressline_02;
            //}
            ////TODO:: I think Delivery_PartyName2 should not use because we can concat to Delivery_PartyName1 instead (we should reuse GenStringFromC080 extension)
            //Delivery_PartyName1 = nad?.PARTYNAME_04?.Partyname_01;
            //Delivery_PartyName2 = nad?.PARTYNAME_04?.Partyname_02;
            Delivery_Street = nad?.STREET_05?.Streetandnumberpobox_01;
            Delivery_CityName = nad?.Cityname_06;
            Delivery_Postcode = nad?.Postcodeidentification_08;
            Delivery_CountryCode = nad?.Countrycoded_09;

        }


        #endregion
        public override void Configure(EntityTypeBuilder<TType> b)
        {
            base.Configure(b);
            //b.Property(e => e.Id).ValueGeneratedOnAdd();
            string tableName = this.GetType().Name;
            if (tableName.StartsWith("Edi", true, null))
                tableName = tableName.Substring(3);
            tableName = "EDI_" + tableName;
            b.Property(x => x.Id).HasColumnType("int");
            b.ToTable(tableName)
                .HasKey(t => t.Id);
            b.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

        }

        #region Generate EDI document

        public UNH generateUNH()
        {
            var unh = new UNH();
            unh.MessageReferenceNumber_01 = string.IsNullOrEmpty(UnhMessageReferenceNumber)? Id.ToString(): UnhMessageReferenceNumber; //UnhMessageReferenceNumber;
            unh.MessageIdentifier_02 = new S009();
            unh.MessageIdentifier_02.MessageType_01 = TypeIdentifier;
            unh.MessageIdentifier_02.MessageVersionNumber_02 = TypeVersionNumber;
            unh.MessageIdentifier_02.MessageReleaseNumber_03 = TypeReleaseNumber;
            unh.MessageIdentifier_02.ControllingAgencyCoded_04 = ControllingAgency;
            return unh;
        }

        public BGM generateBGM()
        {
            BGM bgm = new BGM();
            bgm.DOCUMENTMESSAGENAME_01 = new C002();
            bgm.DOCUMENTMESSAGENAME_01.Documentmessagenamecoded_01 = DocumentNameCode;
            bgm.Documentmessagenumber_02 = DocumentNumber;
            bgm.Messagefunctioncoded_03 = MessageFunction;
            return bgm;
        }

        public DTM generateDocumentDTM()
        {
            DTM dtm = new DTM();
            dtm.DATETIMEPERIOD_01 = new C507();
            dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "137";
            if (DocumentDate != null)
            {
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = DocumentDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
            }

         
            return dtm;
        }



        //public NAD generateBuyer()
        //{
        //    NAD nad = new NAD();
        //    nad.Partyqualifier_01 = Buyer_PartyQualifier;
        //    nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
        //    nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Buyer_PartyId;
        //    nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Buyer_ResponsibleAgency;
        //    return nad;
        //}

        public NAD generateSupplier()
        {
            NAD nad= new NAD();
            nad.Partyqualifier_01 = Supplier_PartyQualifier;
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Supplier_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Supplier_ResponsibleAgency;
            nad.PARTYNAME_04 = new C080();
            nad.PARTYNAME_04.GenC080FromText(Supplier_CompanyName);
            nad.STREET_05 = new C059();
            nad.STREET_05.Streetandnumberpobox_01 = Supplier_Street;
            nad.Cityname_06 = Supplier_CityName;
            nad.Postcodeidentification_08 = Supplier_Postcode;
            nad.Countrycoded_09 = Supplier_CountryCode;
            return nad;
        }

        public NAD generateDelivery()
        {
            NAD nad = new NAD();
            nad.Partyqualifier_01 = Delivery_PartyQualifier; 
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Delivery_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Delivery_ResponsibleAgency;
            //TODO::Because NAMEANDADDRESS_03 does not use anymore in new specification
            //nad.NAMEANDADDRESS_03 = new C058();
            //nad.NAMEANDADDRESS_03.GenC058FromText(Delivery_CompanyName);
            nad.PARTYNAME_04 = new C080();
            //TODO:: Company name should be Delivery_PartyName1 but KTM specification document specify at "3124 Name and address line" but if we validate with edifact library it need Delivery_PartyName1. 
            //nad.PARTYNAME_04.Partyname_01 = string.IsNullOrEmpty(Delivery_PartyName1)? Delivery_CompanyName: Delivery_PartyName1;
            //nad.PARTYNAME_04.Partyname_02 = Delivery_PartyName2;
            nad.PARTYNAME_04.GenC080FromText(Delivery_CompanyName/*+(!string.IsNullOrEmpty(Delivery_PartyName1) ? Delivery_PartyName1 : "") + (!string.IsNullOrEmpty(Delivery_PartyName2) ? Delivery_PartyName2 : "")*/);
            nad.STREET_05 = new C059();
            nad.STREET_05.Streetandnumberpobox_01 = Delivery_Street;
            nad.Cityname_06 = Delivery_CityName;
            nad.Postcodeidentification_08 = Delivery_Postcode;
            nad.Countrycoded_09 = Delivery_CountryCode;
            return nad;
        }

        //public CUX generateCurrency()
        //{
        //    CUX cux = new CUX();
        //    cux.CURRENCYDETAILS_01 = new C504();
        //    cux.CURRENCYDETAILS_01.Currencydetailsqualifier_01 = CurrencyDetailsQualifier;
        //    cux.CURRENCYDETAILS_01.Currencycoded_02 = Currency;
        //    cux.CURRENCYDETAILS_01.Currencyqualifier_03 = CurrencyQualifier;
        //    return cux;
        //}

        public UNS generateUNS()
        {
            UNS uns = new UNS();
            uns.Sectionidentification_01 = "S";
            return uns;
        }
        //public UNT generateUNT()
        //{
        //    UNT unt = new UNT();
        //    //result.UNT.NumberofSegmentsinaMessage_01 = ediOrder.NumberOfSegment?.ToString();
        //    unt.MessageReferenceNumber_02 = string.IsNullOrEmpty(MessageReferenceNumber)? Id.ToString(): MessageReferenceNumber; //MessageReferenceNumber;
        //    return unt;
        //}
        #endregion

    }
    public enum MessageStatus
    {
        /// <summary>
        /// Every Message we get over the web-interface should have this value
        /// </summary>
        RECEIVED = 1,
        RECEIVED_AND_PROCESSED = 2,
        TO_SEND = 3,
        SENDT = 4,
    }
}
