using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities
{
    public abstract class EdiMessage<TType> : EdiMasterMessage<TType>, IEdiPayment, IEdiDeliveryCondition, IBuyer, ICurrency, IFreeText where TType : BaseEdiObject<TType>
    {
        //    [NotMapped]
        //    protected abstract List<string> AllowedRFFQualifiers { get; }
        public string PaymentTerm1_TypeQualifier { get; set; }
        public string PaymentTerm1_TermsOfPaymentIdentification { get; set; }
        public string PaymentTerm1_CodeListQualifier { get; set; }
        public string PaymentTerm1_TermsOfPayment { get; set; }

        public string PaymentTerm1_TimeReferenceCode { get; set; }

        public string PaymentTerm1_TimeRelationCode { get; set; }

        public string PaymentTerm1_TypeOfPeriod { get; set; }

        public int? PaymentTerm1_NumberOfPeriod { get; set; }

        public string PaymentTerm1_PercentageQualifier { get; set; }

        public decimal? PaymentTerm1_Percentage { get; set; }

        public string PaymentTerm2_TypeQualifier { get; set; }
        public string PaymentTerm2_TermsOfPaymentIdentification { get; set; }
        public string PaymentTerm2_CodeListQualifier { get; set; }
        public string PaymentTerm2_TermsOfPayment { get; set; }

        public string PaymentTerm2_TimeReferenceCode { get; set; }

        public string PaymentTerm2_TimeRelationCode { get; set; }

        public string PaymentTerm2_TypeOfPeriod { get; set; }

        public int? PaymentTerm2_NumberOfPeriod { get; set; }

        public string PaymentTerm2_PercentageQualifier { get; set; }

        public decimal? PaymentTerm2_Percentage { get; set; }

        public string PaymentTerm3_TypeQualifier { get; set; }
        public string PaymentTerm3_TermsOfPaymentIdentification { get; set; }
        public string PaymentTerm3_CodeListQualifier { get; set; }
        public string PaymentTerm3_TermsOfPayment { get; set; }

        public string PaymentTerm3_TimeReferenceCode { get; set; }

        public string PaymentTerm3_TimeRelationCode { get; set; }

        public string PaymentTerm3_TypeOfPeriod { get; set; }

        public int? PaymentTerm3_NumberOfPeriod { get; set; }

        public string PaymentTerm3_PercentageQualifier { get; set; }

        public decimal? PaymentTerm3_Percentage { get; set; }

        public string TermsOfDeliveryFunctionCode { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(5)]
        public string TermsOfDeliveryIncoterms { get; set; }

        public string TermsOfDeliveryPlaceLocationQualifier { get; set; }

        public string TermsOfDeliveryPlaceLocationIdentification { get; set; }

        #region Buyer
        public string Buyer_PartyQualifier { get; set; }
        public string Buyer_PartyId { get; set; }

        public string Buyer_ResponsibleAgency { get; set; }
        #endregion

        #region Currency
        public string CurrencyDetailsQualifier { get; set; }
        public string Currency { get; set; }
        public string CurrencyQualifier { get; set; }


        #endregion

        #region FreeText
        public string FreeTextTextSubjectQualifier { get; set; }
        public string FreeTextFreeTextCoded { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }



        #endregion


        public void initPat1(PAT pat)
        {

            PaymentTerm1_TypeQualifier = pat?.Paymenttermstypequalifier_01;
            PaymentTerm1_TermsOfPaymentIdentification = pat?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
            PaymentTerm1_CodeListQualifier = pat?.PAYMENTTERMS_02?.Codelistqualifier_02;
            PaymentTerm1_TermsOfPayment = pat?.PAYMENTTERMS_02?.Termsofpayment_04;
            PaymentTerm1_TimeReferenceCode = pat?.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            PaymentTerm1_TimeRelationCode = pat?.TERMSTIMEINFORMATION_03?.Timerelationcoded_02;
            PaymentTerm1_TypeOfPeriod = pat?.TERMSTIMEINFORMATION_03?.Typeofperiodcoded_03;
            if (!string.IsNullOrEmpty(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04))
                PaymentTerm1_NumberOfPeriod = int.Parse(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04);
        }

        public void initPcd1(PCD pcd)
        {
            PaymentTerm1_PercentageQualifier = pcd?.PERCENTAGEDETAILS_01?.Percentagequalifier_01;
            if (!string.IsNullOrEmpty(pcd?.PERCENTAGEDETAILS_01?.Percentage_02))
                PaymentTerm1_Percentage = decimal.Parse(pcd?.PERCENTAGEDETAILS_01?.Percentage_02);
        }

        public void initPat2(PAT pat)
        {

            PaymentTerm2_TypeQualifier = pat?.Paymenttermstypequalifier_01;
            PaymentTerm2_TermsOfPaymentIdentification = pat?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
            PaymentTerm2_CodeListQualifier = pat?.PAYMENTTERMS_02?.Codelistqualifier_02;
            PaymentTerm2_TermsOfPayment = pat?.PAYMENTTERMS_02?.Termsofpayment_04;
            PaymentTerm2_TimeReferenceCode = pat?.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            PaymentTerm2_TimeRelationCode = pat?.TERMSTIMEINFORMATION_03?.Timerelationcoded_02;
            PaymentTerm2_TypeOfPeriod = pat?.TERMSTIMEINFORMATION_03?.Typeofperiodcoded_03;
            if (!string.IsNullOrEmpty(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04))
                PaymentTerm2_NumberOfPeriod = int.Parse(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04);
        }
        public void initPcd2(PCD pcd)
        {
            PaymentTerm2_PercentageQualifier = pcd?.PERCENTAGEDETAILS_01?.Percentagequalifier_01;
            if (!string.IsNullOrEmpty(pcd?.PERCENTAGEDETAILS_01?.Percentage_02))
                PaymentTerm2_Percentage = decimal.Parse(pcd?.PERCENTAGEDETAILS_01?.Percentage_02);
        }
        public void initPat3(PAT pat)
        {

            PaymentTerm3_TypeQualifier = pat?.Paymenttermstypequalifier_01;
            PaymentTerm3_TermsOfPaymentIdentification = pat?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
            PaymentTerm3_CodeListQualifier = pat?.PAYMENTTERMS_02?.Codelistqualifier_02;
            PaymentTerm3_TermsOfPayment = pat?.PAYMENTTERMS_02?.Termsofpayment_04;
            PaymentTerm3_TimeReferenceCode = pat?.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01;
            PaymentTerm3_TimeRelationCode = pat?.TERMSTIMEINFORMATION_03?.Timerelationcoded_02;
            PaymentTerm3_TypeOfPeriod = pat?.TERMSTIMEINFORMATION_03?.Typeofperiodcoded_03;
            if (!string.IsNullOrEmpty(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04))
                PaymentTerm3_NumberOfPeriod = int.Parse(pat?.TERMSTIMEINFORMATION_03?.Numberofperiods_04);
        }
        public void initPcd3(PCD pcd)
        {
            PaymentTerm3_PercentageQualifier = pcd?.PERCENTAGEDETAILS_01?.Percentagequalifier_01;
            if (!string.IsNullOrEmpty(pcd?.PERCENTAGEDETAILS_01?.Percentage_02))
                PaymentTerm3_Percentage = decimal.Parse(pcd?.PERCENTAGEDETAILS_01?.Percentage_02);
        }
        public void initTOD1(TOD tod)
        {

            TermsOfDeliveryFunctionCode = tod?.Termsofdeliveryortransportfunctioncoded_01;
            TermsOfDeliveryIncoterms = tod?.TERMSOFDELIVERYORTRANSPORT_03?.Termsofdeliveryortransportcoded_01;


        }

        public void initConditionLOC1(LOC loc)
        {
            TermsOfDeliveryPlaceLocationQualifier = loc?.Placelocationqualifier_01;
            TermsOfDeliveryPlaceLocationIdentification = loc?.LOCATIONIDENTIFICATION_02?.Placelocationidentification_01;

        }

        #region InitBuyer
        public void initNADBY(NAD nad)
        {
            Buyer_PartyQualifier = nad?.Partyqualifier_01;
            Buyer_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            Buyer_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;

        }
        #endregion

        public void initCurrency(CUX cux)
        {
            CurrencyDetailsQualifier = cux?.CURRENCYDETAILS_01?.Currencydetailsqualifier_01;
            Currency = cux?.CURRENCYDETAILS_01?.Currencycoded_02;
            CurrencyQualifier = cux?.CURRENCYDETAILS_01?.Currencyqualifier_03;
        }

        public PAT generatePayment1()
        {
            PAT pat = new PAT();
            pat.Paymenttermstypequalifier_01 = PaymentTerm1_TypeQualifier;
            pat.PAYMENTTERMS_02 = new C110();
            pat.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm1_TermsOfPaymentIdentification;
            pat.PAYMENTTERMS_02.Codelistqualifier_02 = PaymentTerm1_CodeListQualifier;
            pat.PAYMENTTERMS_02.GenC110FromText(PaymentTerm1_TermsOfPayment);//Termsofpayment_04 = PaymentTerm1_TermsOfPayment;
            pat.TERMSTIMEINFORMATION_03 = new C112();
            pat.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01 = PaymentTerm1_TimeReferenceCode;
            pat.TERMSTIMEINFORMATION_03.Timerelationcoded_02 = PaymentTerm1_TimeRelationCode;
            pat.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03 = PaymentTerm1_TypeOfPeriod;
            pat.TERMSTIMEINFORMATION_03.Numberofperiods_04 = PaymentTerm1_NumberOfPeriod?.ToString();
            return pat;
        }

        public PCD generatePercentage1()
        {
            PCD pcd = new PCD();
            pcd.PERCENTAGEDETAILS_01 = new C501();
            pcd.PERCENTAGEDETAILS_01.Percentagequalifier_01 = PaymentTerm1_PercentageQualifier;
            pcd.PERCENTAGEDETAILS_01.Percentage_02 = PaymentTerm1_Percentage?.ToString("G29");
            return pcd;
        }

        public PAT generatePayment2()
        {
            PAT pat = new PAT();
            pat.Paymenttermstypequalifier_01 = PaymentTerm2_TypeQualifier;
            pat.PAYMENTTERMS_02 = new C110();
            pat.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm2_TermsOfPaymentIdentification;
            pat.PAYMENTTERMS_02.Codelistqualifier_02 = PaymentTerm2_CodeListQualifier;
            pat.PAYMENTTERMS_02.GenC110FromText(PaymentTerm2_TermsOfPayment);
            pat.TERMSTIMEINFORMATION_03 = new C112();
            pat.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01 = PaymentTerm2_TimeReferenceCode;
            pat.TERMSTIMEINFORMATION_03.Timerelationcoded_02 = PaymentTerm2_TimeRelationCode;
            pat.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03 = PaymentTerm2_TypeOfPeriod;
            pat.TERMSTIMEINFORMATION_03.Numberofperiods_04 = PaymentTerm2_NumberOfPeriod?.ToString();
            return pat;
        }

        public PCD generatePercentage2()
        {
            PCD pcd = new PCD();
            pcd.PERCENTAGEDETAILS_01 = new C501();
            pcd.PERCENTAGEDETAILS_01.Percentagequalifier_01 = PaymentTerm2_PercentageQualifier;
            pcd.PERCENTAGEDETAILS_01.Percentage_02 = PaymentTerm2_Percentage?.ToString("G29");
            return pcd;
        }

        public PAT generatePayment3()
        {
            PAT pat = new PAT();
            pat.Paymenttermstypequalifier_01 = PaymentTerm3_TypeQualifier;
            pat.PAYMENTTERMS_02 = new C110();
            pat.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm3_TermsOfPaymentIdentification;
            pat.PAYMENTTERMS_02.Codelistqualifier_02 = PaymentTerm3_CodeListQualifier;
            pat.PAYMENTTERMS_02.GenC110FromText(PaymentTerm3_TermsOfPayment);
            pat.TERMSTIMEINFORMATION_03 = new C112();
            pat.TERMSTIMEINFORMATION_03.Paymenttimereferencecoded_01 = PaymentTerm3_TimeReferenceCode;
            pat.TERMSTIMEINFORMATION_03.Timerelationcoded_02 = PaymentTerm3_TimeRelationCode;
            pat.TERMSTIMEINFORMATION_03.Typeofperiodcoded_03 = PaymentTerm3_TypeOfPeriod;
            pat.TERMSTIMEINFORMATION_03.Numberofperiods_04 = PaymentTerm3_NumberOfPeriod?.ToString();
            return pat;
        }

        public PCD generatePercentage3()
        {
            PCD pcd = new PCD();
            pcd.PERCENTAGEDETAILS_01 = new C501();
            pcd.PERCENTAGEDETAILS_01.Percentagequalifier_01 = PaymentTerm3_PercentageQualifier;
            pcd.PERCENTAGEDETAILS_01.Percentage_02 = PaymentTerm3_Percentage?.ToString("G29");
            return pcd;
        }

        public TOD generateDeliveryCondition1()
        {
            if (!string.IsNullOrEmpty(TermsOfDeliveryFunctionCode))
            {
                TOD tod = new TOD();
                tod.Termsofdeliveryortransportfunctioncoded_01 = TermsOfDeliveryFunctionCode;
                tod.TERMSOFDELIVERYORTRANSPORT_03 = new C100();
                tod.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01 = TermsOfDeliveryIncoterms;
                return tod;
            }

            return null;
        }

        public LOC generateDeliveryConditionLocation1()
        {
            if (!string.IsNullOrEmpty(TermsOfDeliveryPlaceLocationQualifier))
            {
                var loc = new LOC();
                loc.Placelocationqualifier_01 = TermsOfDeliveryPlaceLocationQualifier;
                loc.LOCATIONIDENTIFICATION_02 = new C517();
                loc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01 = TermsOfDeliveryPlaceLocationIdentification;
                return loc;
            }

            return null;
        }
        public NAD generateBuyer()
        {
            NAD nad = new NAD();
            nad.Partyqualifier_01 = Buyer_PartyQualifier;
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Buyer_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Buyer_ResponsibleAgency;
            return nad;
        }
        public CUX generateCurrency()
        {
            CUX cux = new CUX();
            cux.CURRENCYDETAILS_01 = new C504();
            cux.CURRENCYDETAILS_01.Currencydetailsqualifier_01 = CurrencyDetailsQualifier;
            cux.CURRENCYDETAILS_01.Currencycoded_02 = Currency;
            cux.CURRENCYDETAILS_01.Currencyqualifier_03 = CurrencyQualifier;
            return cux;
        }

        public void init(List<FTX> ftxs)
        {
          for(int index = 0; index < ftxs.Count; index++)
            {
                var ftx = ftxs[index];
                if (ftx != null)
                {
                    FreeTextTextSubjectQualifier = ftx.Textsubjectqualifier_01;
                    FreeTextFreeTextCoded = ftx.TEXTREFERENCE_03?.Freetextcoded_01;
                    //CodeListQualifier = ftx.TEXTREFERENCE_03?.Codelistqualifier_02;
                    //FreeText1 = ftx.TEXTLITERAL_04?.Freetext_01;
                    //FreeText2 = ftx.TEXTLITERAL_04?.Freetext_02;
                    //FreeText3 = ftx.TEXTLITERAL_04?.Freetext_03;
                    //FreeText4 = ftx.TEXTLITERAL_04?.Freetext_04;
                    //FreeText5 = ftx.TEXTLITERAL_04?.Freetext_05;

                    //        if (ftx != null)
                    //        {
                    //            ++index;
                   
                    PropertyInfo text = this.GetType().GetProperty($"FreeText{index+1}");
                    if (text != null)
                        text.SetValue(this, ftx.TEXTLITERAL_04.GenStringFromC108());

                    //        }
                }
            }
          

        }

        public List<FTX> generateFTX()
        {
            List<FTX> ftxs = new List <FTX>();
            //if (!string.IsNullOrEmpty(FreeTextTextSubjectQualifier))
            //{
            //    var ftx = new FTX();
            //    ftx.Textsubjectqualifier_01 = FreeTextTextSubjectQualifier;
            //    //ftx.Textfunctioncoded_02 = "1";//Comment because it use in order change and order.
            //    ftx.TEXTREFERENCE_03 = new C107();
            //    ftx.TEXTREFERENCE_03.Freetextcoded_01 = FreeTextFreeTextCoded;
            //    ftx.TEXTLITERAL_04 = new C108();
            //    ftx.TEXTLITERAL_04.Freetext_01 = FreeText1;
            //    ftx.TEXTLITERAL_04.Freetext_02 = FreeText2;
            //    ftx.TEXTLITERAL_04.Freetext_03 = FreeText3;
            //    ftx.TEXTLITERAL_04.Freetext_04 = FreeText4;
            //    ftx.TEXTLITERAL_04.Freetext_05 = FreeText5;
            //    return ftx;
            //}
            for (int index = 0; index < 5; index++) {
                if (!string.IsNullOrEmpty(FreeTextTextSubjectQualifier))
                {
                    var ftx = new FTX();
                    ftx.Textsubjectqualifier_01 = FreeTextTextSubjectQualifier;
                    //ftx.Textfunctioncoded_02 = "1";//Comment because it use in order change and order.
                    ftx.TEXTREFERENCE_03 = new C107();
                    ftx.TEXTREFERENCE_03.Freetextcoded_01 = FreeTextFreeTextCoded;
                    PropertyInfo text = this.GetType().GetProperty($"FreeText{index + 1}"); 
                    if (text != null && text.GetValue(this) !=null) {
                        ftx.TEXTLITERAL_04 = new C108();
                        ftx.TEXTLITERAL_04.GenC108FromText(text.GetValue(this).ToString());
                        ftxs.Add(ftx);
                    }


                    
                }

            }
              

            return ftxs;
        }
    }
}
