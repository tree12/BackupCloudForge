using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SendGrid.Helpers.Mail;

namespace EDI.DataAccess.Entities
{
    public class EdiInvoice : EdiMessage<EdiInvoice>, ISupplierContact, IFinancialInstitution, IDocumentReference, IFreeText
    {
        public EdiInvoice()
        {
        }

        //public string GeneralRemark { get; set; }

        //public string UidSender { get; set; }
        //public string CompanyBookNumberSender { get; set; }
        //public string AraSystemSender { get; set; }
        //public string AignerFairness { get; set; }

        public string ReferenceQualifier { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
        //////-------------------------------------------------------------------------------------------------------
        ///// <summary>
        ///// 080 SG1 C 10 1 RFF-DTM
        ///// 0090 7 RFF M 1 1 Reference
        ///// 1153 Reference qualifier M an..3 
        /////
        ///// ON Order number (purchase)
        ///// </summary>
        //public string DeliveryReferenceQualifier { get; set; }

        ///// <summary>
        ///// 080 SG1 C 10 1 RFF-DTM
        ///// 0090 7 RFF M 1 1 Reference
        ///// 1154 Reference number C an..35
        /////
        ///// Reference Number
        ///// </summary>
        //public string DeliveryReferenceNumber { get; set; }

        ///// <summary>
        ///// 0080 SG1 C 10 1 RFF-DTM
        ///// 0100 8 DTM C 5 2 Date/time/period
        /////
        ///// 
        ///// </summary>
        //public DateTime DeliveryReferenceDate { get; set; }

        /// <summary>
        /// 0240 SG6 C 5 1 TAX - 0250 21 TAX M 1 1 Duty/tax/fee details
        ///
        /// 5283 Duty/tax/fee function qualifier M an..3
        /// </summary>
        public string DutyTaxFeeQualifier { get; set; }
        /// <summary>
        /// 0240 SG6 C 5 1 TAX - 0250 21 TAX M 1 1 Duty/tax/fee details
        /// C241 Duty/tax/fee type C
        /// 5153 Duty/tax/fee type, coded C an..3
        /// </summary>
        public string DutyTaxFeeCode { get; set; }
        /// <summary>
        /// 0240 SG6 C 5 1 TAX - 0250 21 TAX M 1 1 Duty/tax/fee details
        /// C243 Duty/tax/fee detail C
        /// 5278 Duty/tax/fee rate C an..17
        /// </summary>
        public decimal? DutyTaxFeeRate { get; set; }
        /// <summary>
        /// 0240 SG6 C 5 1 TAX - 0250 21 TAX M 1 1 Duty/tax/fee details
        ///
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string DutyTaxFeeCategoryCode { get; set; }

        #region Payment term

        #endregion

        #region Terms of delivery


        #endregion

        /// <summary>
        /// 0570 SG15 C 9999 1 ALC-SG18-SG19-SG21 - 0580 27 ALC M 1 1 Allowance or charge
        /// 5463 Allowance or charge qualifier M an..3
        /// </summary>
        public string AllowanceChargeQualifier { get; set; }
        /// <summary>
        /// 0570 SG15 C 9999 1 ALC-SG18-SG19-SG21 - 0580 27 ALC M 1 1 Allowance or charge
        /// 7161 Special services, coded C an..3
        /// </summary>
        public string SpecialServicesCode { get; set; }
        /// <summary>
        /// 0570 SG15 C 9999 1 ALC-SG18-SG19-SG21 - 0580 27 ALC M 1 1 Allowance or charge
        /// 7160 Special service C an..35
        /// </summary>
        public string SpecialService { get; set; }
        /// <summary>
        /// 0660 SG18 D 1 2 PCD - 0670 28 PCD M 1 2 Percentage details
        /// C501 Percentage details M
        /// 5245 Percentage qualifier M an..3
        /// </summary>
        public string PercentageQualifier { get; set; }
        /// <summary>
        /// 0660 SG18 D 1 2 PCD - 0670 28 PCD M 1 2 Percentage details
        /// C501 Percentage details M
        /// 5482 Percentage C n..10
        /// </summary>
        public decimal? Percentage { get; set; }
        /// <summary>
        /// 0690 SG19 D 2 2 MOA 0700 29 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M
        /// 5025 Monetary amount type qualifier M an..3
        /// </summary>
        public string MonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 0690 SG19 D 2 2 MOA 0700 - 29 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? MonetaryAmount { get; set; }
        /// <summary>
        /// 0690 SG19 D 2 2 MOA - 0700 29 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string MonetaryCurrencyCode { get; set; }
        /// <summary>
        /// 0750 SG21 C 5 2 TAX - 0760 30 TAX M 1 2 Duty/tax/fee details
        /// 
        /// 5283 Duty/tax/fee function qualifier M an..3
        /// </summary>
        public string AllowanceDutyTaxFeeQualifier { get; set; }
        /// <summary>
        /// 0750 SG21 C 5 2 TAX - 0760 30 TAX M 1 2 Duty/tax/fee details
        /// C241 Duty/tax/fee type C
        /// 5153 Duty/tax/fee type, coded C an..3
        /// </summary>
        public string AllowanceDutyTaxFeeCode { get; set; }
        /// <summary>
        /// 0750 SG21 C 5 2 TAX - 0760 30 TAX M 1 2 Duty/tax/fee details
        /// C243 Duty/tax/fee detail C
        /// 5278 Duty/tax/fee rate C an..17
        /// </summary>
        public decimal? AllowanceDutyTaxFeeRate { get; set; }
        /// <summary>
        /// 0750 SG21 C 5 2 TAX - 0760 30 TAX M 1 2 Duty/tax/fee details
        ///
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string AllowanceDutyTaxFeeCategoryCode { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 45 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3 Invoice amount
        /// </summary>
        public string InvoiceMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 45 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? InvoiceMonetaryAmount { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 45 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string InvoiceMonetaryCurrency { get; set; }

        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 46 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3  Taxable amount
        /// </summary>
        public string TaxableMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 46 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? TaxableMonetaryAmount { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 46 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string TaxableMonetaryCurrency { get; set; }

        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 47 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3  Total line items amount
        /// </summary>
        public string TotalMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 47 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? TotalMonetaryAmount { get; set; }
        /// <summary>
        /// 1810 SG48 M 1 1 MOA - 1820 47 MOA M 1 1 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string TotalMonetaryCurrency { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1870 48 TAX M 1 1 Duty/tax/fee details
        /// 
        /// 5283 Duty/tax/fee function qualifier M an..3
        /// </summary>
        public string AmountDutyTaxFeeQualifier { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1870 48 TAX M 1 1 Duty/tax/fee details
        /// C241 Duty/tax/fee type C
        /// 5153 Duty/tax/fee type, coded C an..3
        /// </summary>
        public string AmountDutyTaxFeeCode { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1870 48 TAX M 1 1 Duty/tax/fee details
        /// C243 Duty/tax/fee detail C
        /// 5278 Duty/tax/fee rate C an..17
        /// </summary>
        public decimal? AmountDutyTaxFeeRate { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1870 48 TAX M 1 1 Duty/tax/fee details
        ///
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string AmountDutyTaxFeeCategoryCode { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 49 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3  Total line items amount
        /// </summary>
        public string SumTaxMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 49 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? SumTaxMonetaryAmount { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 49 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string SumTaxMonetaryCurrency { get; set; }

        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 50 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3  Total line items amount
        /// </summary>
        public string SumTaxableMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 50 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? SumTaxableMonetaryAmount { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 50 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string SumTaxableMonetaryCurrency { get; set; }

        // public NameAndAddress Invoicee { get; set; }

        #region Supplier
        #region Financial institution information

        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3035 Party qualifier M an..3 M an..3 RB Receiving financial institution
        /// </summary>
        public string Bank1PartyQualifier { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank1Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank1Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank1InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank1InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank1InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank1Country { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3035 Party qualifier M an..3 M an..3 RB Receiving financial institution
        /// </summary>
        public string Bank2PartyQualifier { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank2Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank2Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank2InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank2InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank2InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank2Country { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3035 Party qualifier M an..3 M an..3 RB Receiving financial institution
        /// </summary>
        public string Bank3PartyQualifier { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank3Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank3Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank3InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank3InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank3InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank3Country { get; set; }

        #endregion
        public string Supplier_VATReferenceQualifier { get; set; }
        public string Supplier_VATRegistrationNumber { get; set; }

        public string Supplier_ContactCode { get; set; }

        public string Supplier_Name { get; set; }

        public string Supplier_Email { get; set; }

        public string Supplier_Phone { get; set; }

        #endregion
        #region Invoicee
        public string Invoicee_PartyQualifier { get; set; }
        public string Invoicee_PartyId { get; set; }

        public string Invoicee_ResponsibleAgency { get; set; }

        public string Invoicee_CompanyName { get; set; }

        public string Invoicee_Street { get; set; }

        public string Invoicee_CityName { get; set; }

        public string Invoicee_Postcode { get; set; }

        public string Invoicee_CountryCode { get; set; }
        public string Invoicee_VATReferenceQualifier { get; set; }
        public string Invoicee_VATRegistrationNumber { get; set; }

        #endregion

        public int? RechnungsID { get; set; }
        public List<LineItemInvoice> LineItems { get; set; }

        public void init(TSINVOIC tsInvoice)
        {
            base.init(tsInvoice.BGM);
            base.init(tsInvoice.UNH);
            if (tsInvoice.FTX != null)
            {
                //base.init(tsInvoice.FTX.FirstOrDefault(x => x.Textsubjectqualifier_01 == "REG"));
                base.init(tsInvoice.FTX.FirstOrDefault(x => x.Textsubjectqualifier_01 == "REG"));
                //GeneralRemark = tsInvoice.FTX.FirstOrDefault(x => x.Textsubjectqualifier_01 == "AAI" && x.Textfunctioncoded_02 == "1")?.TEXTLITERAL_04?.Freetext_01;
                //AignerFairness = tsInvoice.FTX.FirstOrDefault(x => x.Textsubjectqualifier_01 == "ABS" && x.Textfunctioncoded_02 == "1")?.TEXTLITERAL_04?.Freetext_01;
            }


            base.init(tsInvoice.UNT);

            var docDate = tsInvoice.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137");
            if (docDate != null)
                base.initDocDate(docDate);

            if (tsInvoice.RFFLoop != null)
            {
                //Invoice  Reference

                var invoiceQualifier = tsInvoice.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "IV");
                if (invoiceQualifier != null)
                {
                    initRFF(invoiceQualifier.RFF);
                    var refDate = invoiceQualifier.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "171");
                    if (refDate != null && refDate.DATETIMEPERIOD_01 != null)
                        initRefDate(refDate);
                }

                //var deliveryQualifier = tsInvoice.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "DQ");
                //if (deliveryQualifier != null)
                //{
                //    DeliveryReferenceQualifier = deliveryQualifier.RFF.REFERENCE_01.Referencequalifier_01;
                //    DeliveryReferenceNumber = deliveryQualifier.RFF.REFERENCE_01.Referencenumber_02;
                //    DeliveryReferenceDate = deliveryQualifier.DTM[0].DATETIMEPERIOD_01.asDateTime();
                //}

            }

            if (tsInvoice.NADLoop != null)
            {
                var Buyer = tsInvoice.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "BY");
                var Supplier = tsInvoice.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "SU");
                var Invoicee = tsInvoice.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "IV");
                var Delivery = tsInvoice.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "DP");
                if (Buyer != null)
                {
                    base.initNADBY(Buyer.NAD);
                    if (Buyer.CTALoop != null && Buyer.CTALoop.Count > 1) AddEdiConvertError("We found more than one Contact for the Buyer!");
                }

                if (Supplier != null)
                {
                    base.initNADSU(Supplier.NAD);

                    this.initFinancial(Supplier.FII);

                    var SupplierVat = Supplier?.RFFLoop.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "VA");
                    Supplier_VATReferenceQualifier = SupplierVat?.RFF.REFERENCE_01?.Referencequalifier_01;
                    Supplier_VATRegistrationNumber = SupplierVat?.RFF.REFERENCE_01?.Referencenumber_02;

                    if (Supplier.CTALoop != null && Supplier.CTALoop.Any())
                    {
                        if (Supplier.CTALoop.Count > 1) AddEdiConvertError("Only expedted 1 contact");
                        this.initCTASU(Supplier.CTALoop?.First()?.CTA);
                        this.initContactSU(Supplier.CTALoop[0].COM);
                    }
                }

                if (Invoicee != null)
                {
                    Invoicee_PartyQualifier = Invoicee.NAD?.Partyqualifier_01;
                    Invoicee_PartyId = Invoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
                    Invoicee_ResponsibleAgency = Invoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;

                    Invoicee_CompanyName = Invoicee.NAD?.PARTYNAME_04?.Partyname_01;

                    Invoicee_Street = Invoicee.NAD?.STREET_05?.Streetandnumberpobox_01;
                    Invoicee_CityName = Invoicee.NAD?.Cityname_06;
                    Invoicee_Postcode = Invoicee.NAD?.Postcodeidentification_08;
                    Invoicee_CountryCode = Invoicee.NAD?.Countrycoded_09;

                    var invoiceeVat = Invoicee?.RFFLoop.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "VA");
                    Invoicee_VATReferenceQualifier = invoiceeVat.RFF.REFERENCE_01.Referencequalifier_01;
                    Invoicee_VATRegistrationNumber = invoiceeVat?.RFF.REFERENCE_01?.Referencenumber_02;
                }

                if (Delivery != null)
                {
                    base.initNADDP(Delivery.NAD);
                }

            }

            var tax = tsInvoice.TAXLoop.FirstOrDefault(x => x.TAX.Dutytaxfeefunctionqualifier_01 == "7");
            if (tax != null)
            {
                DutyTaxFeeQualifier = tax.TAX.Dutytaxfeefunctionqualifier_01;
                DutyTaxFeeCode = tax.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
                if (!string.IsNullOrEmpty(tax.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04))
                    DutyTaxFeeRate = decimal.Parse(tax.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04);

                DutyTaxFeeCategoryCode = tax.TAX.Dutytaxfeecategorycoded_06;
            }
            if (tsInvoice.CUXLoop.Count > 1) AddEdiConvertError("More than one Currency found!");
            if (tsInvoice.CUXLoop != null)
            {
                base.initCurrency(tsInvoice.CUXLoop[0]?.CUX);
            }

            #region Assign Term And Payment

            if (tsInvoice.PATLoop != null && tsInvoice.PATLoop.Count > 0 && tsInvoice.PATLoop[0] != null)
            {
                base.initPat1(tsInvoice.PATLoop[0].PAT);
                base.initPcd1(tsInvoice.PATLoop[0].PCD);
                //PaymentTerm1_TermsOfPaymentIdentification = tsInvoice.PATLoop[0].PAT?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
                //PaymentTerm1_TermsOfpayment = tsInvoice.PATLoop[0].PAT?.PAYMENTTERMS_02?.Termsofpayment_04;
                //if (!string.IsNullOrEmpty(tsInvoice.PATLoop[0].PAT?.PAYMENTTERMS_02?.Termsofpayment_05))
                //{
                //    PaymentTerm1_TermsOfpayment += tsInvoice.PATLoop[0].PAT?.PAYMENTTERMS_02?.Termsofpayment_05;
                //}
            }
            if (tsInvoice.PATLoop != null && tsInvoice.PATLoop.Count > 1 && tsInvoice.PATLoop[1] != null)
            {
                base.initPat2(tsInvoice.PATLoop[1].PAT);
                base.initPcd2(tsInvoice.PATLoop[1].PCD);
                //PaymentTerm2_TermsOfPaymentIdentification = tsInvoice.PATLoop[1].PAT?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
                //PaymentTerm2_TermsOfpayment = tsInvoice.PATLoop[1].PAT?.PAYMENTTERMS_02?.Termsofpayment_04;
                //if (!string.IsNullOrEmpty(tsInvoice.PATLoop[1].PAT?.PAYMENTTERMS_02?.Termsofpayment_05))
                //{
                //    PaymentTerm2_TermsOfpayment += tsInvoice.PATLoop[1].PAT?.PAYMENTTERMS_02?.Termsofpayment_05;
                //}
            }
            if (tsInvoice.PATLoop != null && tsInvoice.PATLoop.Count > 2 && tsInvoice.PATLoop[2] != null)
            {
                base.initPat3(tsInvoice.PATLoop[2].PAT);
                base.initPcd3(tsInvoice.PATLoop[2].PCD);
                //PaymentTerm3_TermsOfPaymentIdentification = tsInvoice.PATLoop[2].PAT?.PAYMENTTERMS_02?.Termsofpaymentidentification_01;
                //PaymentTerm3_TermsOfpayment = tsInvoice.PATLoop[2].PAT?.PAYMENTTERMS_02?.Termsofpayment_04;
                //if (!string.IsNullOrEmpty(tsInvoice.PATLoop[2].PAT?.PAYMENTTERMS_02?.Termsofpayment_05))
                //{
                //    PaymentTerm3_TermsOfpayment += tsInvoice.PATLoop[2].PAT?.PAYMENTTERMS_02?.Termsofpayment_05;
                //}
            }
            if (tsInvoice.PATLoop != null && tsInvoice.PATLoop.Count > 3)
                AddEdiConvertError("Payment Term more than 3");
            if (tsInvoice.TODLoop != null && tsInvoice.TODLoop.Count > 0 && tsInvoice.TODLoop[0] != null)
            {
                base.initTOD1(tsInvoice.TODLoop[0].TOD);
                if (tsInvoice.TODLoop[0].LOC != null)
                {
                    if (tsInvoice.TODLoop[0].LOC.Any())
                    {
                        base.initConditionLOC1(tsInvoice.TODLoop[0].LOC?.FirstOrDefault());
                    }
                }
            }


            if (tsInvoice.TODLoop != null && tsInvoice.TODLoop.Count > 1)
                AddEdiConvertError("Delivery Term more than one");
            #endregion


            if (tsInvoice.ALCLoop != null)
            {
                var alc = tsInvoice.ALCLoop.FirstOrDefault(x => x.ALC.Allowanceorchargequalifier_01 == "C");

                AllowanceChargeQualifier = alc?.ALC.Allowanceorchargequalifier_01;
                SpecialServicesCode = alc?.ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservicescoded_01;
                SpecialService = alc?.ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservice_04;
                PercentageQualifier = alc?.PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentagequalifier_01;
                if (!string.IsNullOrEmpty(alc?.PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentage_02))
                    Percentage = decimal.Parse(alc?.PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentage_02);
                var chargeAmount = alc?.MOALoop.FirstOrDefault(x => x.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "8");
                if (chargeAmount != null)
                {
                    MonetaryTypeQualifier = chargeAmount.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                    if (!string.IsNullOrEmpty(chargeAmount.MOA.MONETARYAMOUNT_01.Monetaryamount_02))
                        MonetaryAmount = int.Parse(chargeAmount.MOA.MONETARYAMOUNT_01.Monetaryamount_02);

                    MonetaryCurrencyCode = chargeAmount.MOA.MONETARYAMOUNT_01.Currencycoded_03;
                }

                var allowanceTax = alc?.TAXLoop.FirstOrDefault(x => x.TAX.Dutytaxfeefunctionqualifier_01 == "7");
                if (allowanceTax != null)
                {
                    AllowanceDutyTaxFeeQualifier = allowanceTax.TAX.Dutytaxfeefunctionqualifier_01;
                    AllowanceDutyTaxFeeCode = allowanceTax.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
                    if (!string.IsNullOrEmpty(allowanceTax.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04))
                        AllowanceDutyTaxFeeRate = decimal.Parse(allowanceTax.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04);
                    AllowanceDutyTaxFeeCategoryCode = allowanceTax.TAX.Dutytaxfeecategorycoded_06;
                }


            }

            if (tsInvoice.LINLoop != null)
            {
                LineItems = GenerateLineItems(tsInvoice.LINLoop);
                //List<IMD> imds = tsInvoice.LINLoop.Select(x => x.IMD.FirstOrDefault()).ToList();
                //initIMDs(imds);
            }
            else
            {
                AddEdiConvertError("Line items for Invoice is empty.");
            }

            if (tsInvoice.MOALoop != null)
            {
                var invoiceMonetary = tsInvoice.MOALoop.FirstOrDefault(x => x.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "77");
                var taxableMonetary = tsInvoice.MOALoop.FirstOrDefault(x => x.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "125");
                var totalMonetary = tsInvoice.MOALoop.FirstOrDefault(x => x.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "79");

                if (invoiceMonetary != null)
                {
                    InvoiceMonetaryTypeQualifier = invoiceMonetary.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                    if (!string.IsNullOrEmpty(invoiceMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02))
                        InvoiceMonetaryAmount = int.Parse(invoiceMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02);
                    InvoiceMonetaryCurrency = invoiceMonetary.MOA.MONETARYAMOUNT_01.Currencycoded_03;
                }

                if (taxableMonetary != null)
                {
                    TaxableMonetaryTypeQualifier = taxableMonetary.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                    if (!string.IsNullOrEmpty(taxableMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02))
                        TaxableMonetaryAmount = int.Parse(taxableMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02);
                    TaxableMonetaryCurrency = taxableMonetary.MOA.MONETARYAMOUNT_01.Currencycoded_03;
                }

                if (totalMonetary != null)
                {
                    TotalMonetaryTypeQualifier = totalMonetary.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                    if (!string.IsNullOrEmpty(totalMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02))
                        TotalMonetaryAmount = int.Parse(totalMonetary.MOA.MONETARYAMOUNT_01.Monetaryamount_02);
                    TotalMonetaryCurrency = totalMonetary.MOA.MONETARYAMOUNT_01.Currencycoded_03;
                }


            }

            if (tsInvoice.TAXLoop2 != null)
            {
                var taxAmount = tsInvoice.TAXLoop2.FirstOrDefault(x => x.TAX.Dutytaxfeefunctionqualifier_01 == "7");
                if (taxAmount != null)
                {
                    AmountDutyTaxFeeQualifier = taxAmount.TAX.Dutytaxfeefunctionqualifier_01;
                    AmountDutyTaxFeeCode = taxAmount.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
                    if (!string.IsNullOrEmpty(taxAmount.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04))
                        AmountDutyTaxFeeRate = decimal.Parse(taxAmount.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04);
                    AmountDutyTaxFeeCategoryCode = taxAmount.TAX.Dutytaxfeecategorycoded_06;
                    var taxMonetary = taxAmount.MOA.FirstOrDefault(x => x.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "124");
                    var taxableMonetary = taxAmount.MOA.FirstOrDefault(x => x.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 == "125");
                    if (taxMonetary != null)
                    {
                        SumTaxMonetaryTypeQualifier = taxMonetary.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                        if (!string.IsNullOrEmpty(taxMonetary.MONETARYAMOUNT_01.Monetaryamount_02))
                            SumTaxMonetaryAmount = int.Parse(taxMonetary.MONETARYAMOUNT_01.Monetaryamount_02);
                        SumTaxMonetaryCurrency = taxMonetary.MONETARYAMOUNT_01.Currencycoded_03;
                    }

                    if (taxableMonetary != null)
                    {
                        SumTaxableMonetaryTypeQualifier = taxableMonetary.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                        if (!string.IsNullOrEmpty(taxableMonetary.MONETARYAMOUNT_01.Monetaryamount_02))
                            SumTaxableMonetaryAmount = int.Parse(taxableMonetary.MONETARYAMOUNT_01.Monetaryamount_02);
                        SumTaxableMonetaryCurrency = taxableMonetary.MONETARYAMOUNT_01.Currencycoded_03;
                    }



                }


            }

        }

        private List<LineItemInvoice> GenerateLineItems(List<Loop_LIN_INVOIC> linOrders)
        {
            List<LineItemInvoice> lineItems = new List<LineItemInvoice>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemInvoice();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }


        public void initCTASU(CTA cta)
        {
            Supplier_ContactCode = cta?.Contactfunctioncoded_01;
            Supplier_Name = cta?.DEPARTMENTOREMPLOYEEDETAILS_02?.Departmentoremployee_02;
        }

        public void initContactSU(List<COM> coms)
        {
            Supplier_Email = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
            Supplier_Phone = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
        }

        public void initFinancial(List<FII> fii)
        {
            if (fii != null && fii.Count > 3) AddEdiConvertError("We found more than 3 Banks for the Supplier!");
            if (fii != null && fii[0] != null)
            {
                if (fii[0].Partyqualifier_01 == "RB")
                {
                    Bank1PartyQualifier = fii[0].Partyqualifier_01;
                    Bank1Iban = fii[0].ACCOUNTIDENTIFICATION_02.Accountholdernumber_01;
                    Bank1Name = fii[0].ACCOUNTIDENTIFICATION_02.Accountholdername_02;
                    Bank1InstitutionNameId = fii[0].INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01;
                    Bank1InstitutionBranchNumber = fii[0].INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04;
                    Bank1InstitutionName = fii[0].INSTITUTIONIDENTIFICATION_03.Institutionname_07;
                    Bank1Country = fii[0].Countrycoded_04;
                }
                else
                {
                    AddEdiConvertError("We found Partyqualifier of bank is not RB!");
                }

            }
            if (fii != null && fii.Count > 1 && fii[1] != null)
            {
                if (fii[1].Partyqualifier_01 == "RB")
                {
                    Bank2PartyQualifier = fii[1].Partyqualifier_01;
                    Bank2Iban = fii[1].ACCOUNTIDENTIFICATION_02.Accountholdernumber_01;
                    Bank2Name = fii[1].ACCOUNTIDENTIFICATION_02.Accountholdername_02;
                    Bank2InstitutionNameId = fii[1].INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01;
                    Bank2InstitutionBranchNumber = fii[1].INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04;
                    Bank2InstitutionName = fii[1].INSTITUTIONIDENTIFICATION_03.Institutionname_07;
                    Bank2Country = fii[1].Countrycoded_04;
                }
                else
                {
                    AddEdiConvertError("We found Partyqualifier of bank is not RB!");
                }

            }
            if (fii != null && fii.Count > 2 && fii[2] != null)
            {
                if (fii[2].Partyqualifier_01 == "RB")
                {
                    Bank3PartyQualifier = fii[2].Partyqualifier_01;
                    Bank3Iban = fii[2].ACCOUNTIDENTIFICATION_02.Accountholdernumber_01;
                    Bank3Name = fii[2].ACCOUNTIDENTIFICATION_02.Accountholdername_02;
                    Bank3InstitutionNameId = fii[2].INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01;
                    Bank3InstitutionBranchNumber = fii[2].INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04;
                    Bank3InstitutionName = fii[2].INSTITUTIONIDENTIFICATION_03.Institutionname_07;
                    Bank3Country = fii[2].Countrycoded_04;
                }
                else
                {
                    AddEdiConvertError("We found Partyqualifier of bank is not RB!");
                }

            }
        }
        public CTA generateSupplierCTA()
        {
            CTA cta = new CTA();
            cta.Contactfunctioncoded_01 = Supplier_ContactCode;
            cta.DEPARTMENTOREMPLOYEEDETAILS_02 = new C056();
            cta.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02 = Supplier_Name;
            return cta;
        }

        public COM generateSupplierPhone()
        {
            var comPhone = new COM();
            comPhone.COMMUNICATIONCONTACT_01 = new C076();
            comPhone.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Supplier_Phone;
            comPhone.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "TE";
            return comPhone;
        }

        public COM generateSupplierEmail()
        {
            var comEmail = new COM();
            comEmail.COMMUNICATIONCONTACT_01 = new C076();
            comEmail.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Supplier_Email;
            comEmail.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "EM";
            return comEmail;
        }

        public override EdiMessage CreateEdiDocument()
        {
            var result = new TSINVOIC();
            result.UNH = base.generateUNH();
            result.BGM = base.generateBGM();

            result.DTM = new List<DTM>();
            result.DTM.Add(base.generateDocumentDTM());

            var ftx = base.generateFTX();
            if (ftx != null)
            {
                result.FTX = new List<FTX>();
                result.FTX.Add(ftx);
            }

            var reffDoc = generateRFF();
            if (reffDoc != null)
            {
                result.RFFLoop = new List<Loop_RFF_INVOIC>();
                var rffLoop = new Loop_RFF_INVOIC();
                rffLoop.RFF = reffDoc;
                var dtmDoc = generateReferenceDTM();
                if (dtmDoc != null)
                {
                    rffLoop.DTM = new List<DTM>();
                    rffLoop.DTM.Add(dtmDoc);
                }

                result.RFFLoop.Add(rffLoop);
            }

            //TODO:: In new specification does not use Delivery Reference anymore
            //var rffDiliveryLoop = new Loop_RFF_INVOIC();
            //rffDiliveryLoop.RFF = generateDeliveryRff();
            //rffDiliveryLoop.DTM = new List<DTM>();
            //rffDiliveryLoop.DTM.Add(generateDeliveryDTM());
            //result.RFFLoop.Add(rffDiliveryLoop);

            result.NADLoop = new List<Loop_NAD_INVOIC>();

            #region Buyer
            var nadLoopBY = new Loop_NAD_INVOIC();
            nadLoopBY.NAD = base.generateBuyer();
            result.NADLoop.Add(nadLoopBY);
            #endregion

            #region Supplier
            var nadLoopSU = new Loop_NAD_INVOIC();
            nadLoopSU.NAD = base.generateSupplier();
            nadLoopSU.RFFLoop = new List<Loop_RFF_INVOIC>();

            nadLoopSU.CTALoop = new List<Loop_CTA_INVOIC>();
            var ctaLoopSU = new Loop_CTA_INVOIC();
            ctaLoopSU.CTA = generateSupplierCTA();
            ctaLoopSU.COM = new List<COM>();
            ctaLoopSU.COM.Add(generateSupplierEmail());
            ctaLoopSU.COM.Add(generateSupplierPhone());
            nadLoopSU.CTALoop.Add(ctaLoopSU);


            Loop_RFF_INVOIC supplierLoopRff = new Loop_RFF_INVOIC();
            supplierLoopRff.RFF = new RFF();
            supplierLoopRff.RFF.REFERENCE_01 = new C506();
            supplierLoopRff.RFF.REFERENCE_01.Referencequalifier_01 = Supplier_VATReferenceQualifier;
            supplierLoopRff.RFF.REFERENCE_01.Referencenumber_02 = Supplier_VATRegistrationNumber;
            nadLoopSU.RFFLoop.Add(supplierLoopRff);
            nadLoopSU.FII = generateFII();

            result.NADLoop.Add(nadLoopSU);
            #endregion

            #region Invoicee
            var nadLoopInvoicee = new Loop_NAD_INVOIC();
            nadLoopInvoicee.NAD = generateInvoicee();
            nadLoopInvoicee.RFFLoop = new List<Loop_RFF_INVOIC>();
            Loop_RFF_INVOIC invoiceeLoopRff = new Loop_RFF_INVOIC();
            invoiceeLoopRff.RFF = new RFF();
            invoiceeLoopRff.RFF.REFERENCE_01 = new C506();
            invoiceeLoopRff.RFF.REFERENCE_01.Referencequalifier_01 = Invoicee_VATReferenceQualifier;
            invoiceeLoopRff.RFF.REFERENCE_01.Referencenumber_02 = Invoicee_VATRegistrationNumber;
            nadLoopInvoicee.RFFLoop.Add(invoiceeLoopRff);
            result.NADLoop.Add(nadLoopInvoicee);

            #endregion

            #region Delivery
            var nadLoopDP = new Loop_NAD_INVOIC();
            nadLoopDP.NAD = base.generateDelivery();
            result.NADLoop.Add(nadLoopDP);

            #endregion

            result.TAXLoop = new List<Loop_TAX_INVOIC>();
            Loop_TAX_INVOIC taxLoop = new Loop_TAX_INVOIC();
            taxLoop.TAX = generateTAX();
            result.TAXLoop.Add(taxLoop);

            result.CUXLoop = new List<Loop_CUX_INVOIC>();
            var cuxLoop = new Loop_CUX_INVOIC();
            cuxLoop.CUX = base.generateCurrency();
            result.CUXLoop.Add(cuxLoop);

            #region Payment Term

            result.PATLoop = new List<Loop_PAT_INVOIC>();

            if (!string.IsNullOrEmpty(PaymentTerm1_TypeQualifier))
            {
                var patLoop = new Loop_PAT_INVOIC();
                PAT pat1 = base.generatePayment1();
                //pat1.PAYMENTTERMS_02 = new C110();
                //pat1.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm1_TermsOfPaymentIdentification;
                //pat1.PAYMENTTERMS_02.GenC110FromText(PaymentTerm1_TermsOfpayment);
                patLoop.PAT = pat1;
                patLoop.PCD = base.generatePercentage1();
                result.PATLoop.Add(patLoop);
            }

            if (!string.IsNullOrEmpty(PaymentTerm2_TypeQualifier))
            {
                var patLoop2 = new Loop_PAT_INVOIC();
                PAT pat2 = base.generatePayment2();
                //pat2.PAYMENTTERMS_02 = new C110();
                //pat2.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm2_TermsOfPaymentIdentification;
                //pat2.PAYMENTTERMS_02.GenC110FromText(PaymentTerm2_TermsOfpayment);
                patLoop2.PAT = pat2;
                patLoop2.PCD = base.generatePercentage2();
                result.PATLoop.Add(patLoop2);
            }

            if (!string.IsNullOrEmpty(PaymentTerm3_TypeQualifier))
            {
                var patLoop3 = new Loop_PAT_INVOIC();
                PAT pat3 = base.generatePayment3();
                //pat3.PAYMENTTERMS_02 = new C110();
                //pat3.PAYMENTTERMS_02.Termsofpaymentidentification_01 = PaymentTerm3_TermsOfPaymentIdentification;
                //pat3.PAYMENTTERMS_02.GenC110FromText(PaymentTerm3_TermsOfpayment);
                patLoop3.PAT = pat3;
                patLoop3.PCD = base.generatePercentage3();
                result.PATLoop.Add(patLoop3);
            }


            #endregion

            #region DeliveryOrTransport Term
            result.TODLoop = new List<Loop_TOD_INVOIC>();
            var todLoop = new Loop_TOD_INVOIC();
            todLoop.TOD = base.generateDeliveryCondition1();
            LOC loc = base.generateDeliveryConditionLocation1();
            if (loc != null)
            {
                todLoop.LOC = new List<LOC>();
                todLoop.LOC.Add(loc);
            }
            result.TODLoop.Add(todLoop);
            #endregion

            result.ALCLoop = generateALC_INVOIC();

            #region Line Item
            result.LINLoop = new List<Loop_LIN_INVOIC>();
           
            //List<IMD> imds = generateIMD();
            //int index = 0;
            foreach (var lineItem in LineItems)
            {
                var linLoop1 = new Loop_LIN_INVOIC();
                linLoop1.LIN = lineItem.generateLIN();
                var pia = lineItem.generatePIA();
                if (pia != null)
                {
                    linLoop1.PIA = new List<PIA>();
                    linLoop1.PIA.Add(pia);
                }
                //linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                ////linLoop1.IMD.Add(lineItem.generateIMD());
                //if (index < imds.Count)
                //    linLoop1.IMD.Add(imds[index]);
                //++index;
                var imd = lineItem.generateIMD();
                if (imd != null)
                {
                    linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                    linLoop1.IMD.Add(imd);
                }
                var qty = lineItem.generateQTY();
                if (qty != null)
                {
                    linLoop1.QTY = new List<QTY>();
                    linLoop1.QTY.Add(qty);
                }

                if (!string.IsNullOrEmpty(lineItem.TextSubjectQualifier))
                {
                    linLoop1.FTX = new List<FTX>();
                    var lineFtx = new FTX();
                    lineFtx.Textsubjectqualifier_01 = lineItem.TextSubjectQualifier;
                    lineFtx.TEXTLITERAL_04 = new C108();
                    lineFtx.TEXTLITERAL_04.Freetext_01 = lineItem.FreeTextLineItem;
                    linLoop1.FTX.Add(lineFtx);
                }

                //  Repeating MOA Groups
                linLoop1.MOALoop = new List<Loop_MOA_INVOIC_2>();
                if (!string.IsNullOrEmpty(lineItem.MonetaryTypeQualifier))
                {
                    //  Begin MOA Group
                    var moaLinLoop1 = new Loop_MOA_INVOIC_2();
                    //  Line item amount 2.160 EUR
                    moaLinLoop1.MOA = new MOA();
                    moaLinLoop1.MOA.MONETARYAMOUNT_01 = new C516();
                    moaLinLoop1.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = lineItem.MonetaryTypeQualifier;
                    moaLinLoop1.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = lineItem.MonetaryAmount?.ToString("G29");
                    moaLinLoop1.MOA.MONETARYAMOUNT_01.Currencycoded_03 = lineItem.MonetaryCurrency;

                    //  End MOA Group
                    linLoop1.MOALoop.Add(moaLinLoop1);
                }

                //  Repeating PRI Groups
                linLoop1.PRILoop = new List<Loop_PRI_INVOIC>();

                if (!string.IsNullOrEmpty(lineItem.PriceQualifier))
                {
                    //  Begin PRI Group
                    var priLinLoop1 = new Loop_PRI_INVOIC();

                    //  Gross calculation price of 60 which does not include any allowance or charges, from the catalogue.
                    priLinLoop1.PRI = new PRI();
                    priLinLoop1.PRI.PRICEINFORMATION_01 = new C509();
                    priLinLoop1.PRI.PRICEINFORMATION_01.Pricequalifier_01 = lineItem.PriceQualifier;
                    priLinLoop1.PRI.PRICEINFORMATION_01.Price_02 = lineItem.Price?.ToString("G29");
                    priLinLoop1.PRI.PRICEINFORMATION_01.Unitpricebasis_05 = lineItem.UnitPriceBasis;
                    priLinLoop1.PRI.PRICEINFORMATION_01.Measureunitqualifier_06 = lineItem.PriceMeasureUnitQualifier;

                    //  End PRI Group
                    linLoop1.PRILoop.Add(priLinLoop1);
                }

                linLoop1.RFFLoop = new List<Loop_RFF_INVOIC>();
                /************Purchase RFF***********/
                var lineRff = new Loop_RFF_INVOIC();
                if (!string.IsNullOrEmpty(lineItem.PurchaseReferenceQualifier))
                {
                    lineRff.RFF = new RFF();
                    lineRff.RFF.REFERENCE_01 = new C506();
                    lineRff.RFF.REFERENCE_01.Referencequalifier_01 = lineItem.PurchaseReferenceQualifier;
                    lineRff.RFF.REFERENCE_01.Referencenumber_02 = lineItem.PurchaseReferenceNumber;
                    lineRff.RFF.REFERENCE_01.Linenumber_03 = lineItem.PurchaseLineNumber;
                }

                if (!string.IsNullOrEmpty(lineItem.PurchaseDateQualifier))
                {
                    lineRff.DTM = new List<DTM>();
                    var lineDtm = new DTM();
                    lineDtm.DATETIMEPERIOD_01 = new C507();
                    lineDtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = lineItem.PurchaseDateQualifier;
                    lineDtm.DATETIMEPERIOD_01.Datetimeperiod_02 = lineItem.PurchaseDate.ToString("yyyyMMdd");
                    lineDtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = lineItem.PurchaseDateFormat;
                    lineRff.DTM.Add(lineDtm);
                    linLoop1.RFFLoop.Add(lineRff);
                }

                /************ Delivery RFF **********/
                var lineRff2 = new Loop_RFF_INVOIC();
                if (!string.IsNullOrEmpty(lineItem.DeliveryReferenceQualifier))
                {
                    lineRff2.RFF = new RFF();
                    lineRff2.RFF.REFERENCE_01 = new C506();
                    lineRff2.RFF.REFERENCE_01.Referencequalifier_01 = lineItem.DeliveryReferenceQualifier;
                    lineRff2.RFF.REFERENCE_01.Referencenumber_02 = lineItem.DeliveryReferenceNumber;
                    lineRff2.RFF.REFERENCE_01.Linenumber_03 = lineItem.DeliveryLineNumber;
                }
                
                lineRff2.DTM = new List<DTM>();
                lineRff2.DTM.Add(lineItem.generateDeliveryDTM());
                linLoop1.RFFLoop.Add(lineRff2);


                //  Repeating TAX Groups
                linLoop1.TAXLoop = new List<Loop_TAX_INVOIC>();

                //  Begin TAX Group
                var taxLinLoop1 = new Loop_TAX_INVOIC();

                //  Type of tax for the line item is value added tax 21%
                if (!string.IsNullOrEmpty(lineItem.InvoiceDutyTaxFeeQualifier))
                {
                    taxLinLoop1.TAX = new TAX();
                    taxLinLoop1.TAX.Dutytaxfeefunctionqualifier_01 = lineItem.InvoiceDutyTaxFeeQualifier;
                    taxLinLoop1.TAX.DUTYTAXFEETYPE_02 = new C241();
                    taxLinLoop1.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01 = lineItem.InvoiceTax;
                    taxLinLoop1.TAX.DUTYTAXFEEDETAIL_05 = new C243();
                    taxLinLoop1.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04 = lineItem.InvoiceDutyTaxFeeRate;
                    taxLinLoop1.TAX.Dutytaxfeecategorycoded_06 = lineItem.TaxCategoryCode;
                }

                if (!string.IsNullOrEmpty(lineItem.TaxMonetaryTypeQualifier))
                {
                    //  Tax monetary amount 453.60 EUR 
                    taxLinLoop1.MOA = new MOA();
                    taxLinLoop1.MOA.MONETARYAMOUNT_01 = new C516();
                    taxLinLoop1.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = lineItem.TaxMonetaryTypeQualifier;
                    taxLinLoop1.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = lineItem.TaxMonetaryAmount?.ToString("G29");
                    taxLinLoop1.MOA.MONETARYAMOUNT_01.Currencycoded_03 = lineItem.TaxMonetaryCurrency;
                }

                //  End TAX Group
                linLoop1.TAXLoop.Add(taxLinLoop1);

                //  End LIN Group 1
                result.LINLoop.Add(linLoop1);
            }


            #endregion
            result.UNS = base.generateUNS();

            //  Repeating MOA Groups
            result.MOALoop = new List<Loop_MOA_INVOIC_3>();

            //  Begin MOA Group 1
           
            if (!string.IsNullOrEmpty(InvoiceMonetaryTypeQualifier))
            {
                var moaLoop1 = new Loop_MOA_INVOIC_3();
                //  Message total monetary amount 5.767,10 EUR
                moaLoop1.MOA = new MOA();
                moaLoop1.MOA.MONETARYAMOUNT_01 = new C516();
                moaLoop1.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = InvoiceMonetaryTypeQualifier;
                moaLoop1.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = InvoiceMonetaryAmount?.ToString("G29");
                moaLoop1.MOA.MONETARYAMOUNT_01.Currencycoded_03 = InvoiceMonetaryCurrency;

                //  End MOA Group 1
                result.MOALoop.Add(moaLoop1);
            }

            if (!string.IsNullOrEmpty(TaxableMonetaryTypeQualifier))
            {
                //  Begin MOA Group 2
                var moaLoop2 = new Loop_MOA_INVOIC_3();

                //  Message total line items amount 4.690 EUR
                moaLoop2.MOA = new MOA();
                moaLoop2.MOA.MONETARYAMOUNT_01 = new C516();
                moaLoop2.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = TaxableMonetaryTypeQualifier;
                moaLoop2.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = TaxableMonetaryAmount?.ToString("G29");
                moaLoop2.MOA.MONETARYAMOUNT_01.Currencycoded_03 = TaxableMonetaryCurrency;

                //  End MOA Group 2
                result.MOALoop.Add(moaLoop2);
            }

            if (!string.IsNullOrEmpty(TotalMonetaryTypeQualifier))
            {
                //  Begin MOA Group 3
                var moaLoop3 = new Loop_MOA_INVOIC_3();

                //  Total amount subject to payment discount 5.767.10 EUR
                moaLoop3.MOA = new MOA();
                moaLoop3.MOA.MONETARYAMOUNT_01 = new C516();
                moaLoop3.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = TotalMonetaryTypeQualifier;
                moaLoop3.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = TotalMonetaryAmount?.ToString("G29");
                moaLoop3.MOA.MONETARYAMOUNT_01.Currencycoded_03 = TotalMonetaryCurrency;

                //  End MOA Group 3
                result.MOALoop.Add(moaLoop3);
            }

            //  Repeating TAX Groups
            result.TAXLoop2 = new List<Loop_TAX_INVOIC_3>();

            //  Begin TAX Group 1
            var taxLoop1 = new Loop_TAX_INVOIC_3();
            if (!string.IsNullOrEmpty(DutyTaxFeeQualifier))
            {
                //  Type of tax for the total message is value added tax 19 %
                taxLoop1.TAX = new TAX();
                taxLoop1.TAX.Dutytaxfeefunctionqualifier_01 = DutyTaxFeeQualifier;
                taxLoop1.TAX.DUTYTAXFEETYPE_02 = new C241();
                taxLoop1.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01 = DutyTaxFeeCode;
                taxLoop1.TAX.DUTYTAXFEEDETAIL_05 = new C243();
                taxLoop1.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04 = DutyTaxFeeRate?.ToString("G29");
                taxLoop1.TAX.Dutytaxfeecategorycoded_06 = DutyTaxFeeCategoryCode;
            }

            //  Repeating MOA
            taxLoop1.MOA = new List<MOA>();

            if (!string.IsNullOrEmpty(SumTaxMonetaryTypeQualifier))
            {
                //  Tax monetary amount 503.50 EUR
                var moaTax1 = new MOA();
                moaTax1.MONETARYAMOUNT_01 = new C516();
                moaTax1.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = SumTaxMonetaryTypeQualifier;
                moaTax1.MONETARYAMOUNT_01.Monetaryamount_02 = SumTaxMonetaryAmount?.ToString("G29");
                moaTax1.MONETARYAMOUNT_01.Currencycoded_03 = SumTaxMonetaryCurrency;
                taxLoop1.MOA.Add(moaTax1);
            }

            if (!string.IsNullOrEmpty(SumTaxableMonetaryTypeQualifier))
            {
                var moaTax2 = new MOA();
                moaTax2.MONETARYAMOUNT_01 = new C516();
                moaTax2.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = SumTaxableMonetaryTypeQualifier;
                moaTax2.MONETARYAMOUNT_01.Monetaryamount_02 = SumTaxableMonetaryAmount?.ToString("G29");
                moaTax2.MONETARYAMOUNT_01.Currencycoded_03 = SumTaxableMonetaryCurrency;
                taxLoop1.MOA.Add(moaTax2);
            }

            //  End TAX Group 1
            result.TAXLoop2.Add(taxLoop1);

            //result.UNT = base.generateUNT();

            return result;
        }

        //protected RFF generateDeliveryRff()
        //{
        //    RFF rff = new RFF();
        //    rff.REFERENCE_01 = new C506();
        //    rff.REFERENCE_01.Referencequalifier_01 = DeliveryReferenceQualifier;
        //    rff.REFERENCE_01.Referencenumber_02 = DeliveryReferenceNumber;
        //    return rff;
        //}

        //protected DTM generateDeliveryDTM()
        //{
        //    DTM dtm = new DTM();
        //    dtm.DATETIMEPERIOD_01 = new C507();
        //    dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
        //    if (DeliveryReferenceDate != null)
        //        dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = DeliveryReferenceDate.ToString("yyyyMMdd");
        //    dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
        //    return dtm;
        //}

        protected NAD generateInvoicee()
        {
            if (!string.IsNullOrEmpty(Invoicee_PartyQualifier))
            {
                NAD nad = new NAD();
                nad.Partyqualifier_01 = Invoicee_PartyQualifier;
                nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
                nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Invoicee_PartyId;
                nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Invoicee_ResponsibleAgency;
                nad.PARTYNAME_04 = new C080();
                nad.PARTYNAME_04.Partyname_01 = Invoicee_CompanyName;
                nad.STREET_05 = new C059();
                nad.STREET_05.Streetandnumberpobox_01 = Invoicee_Street;
                nad.Cityname_06 = Invoicee_CityName;
                nad.Postcodeidentification_08 = Invoicee_Postcode;
                nad.Countrycoded_09 = Invoicee_CountryCode;
                return nad;
            }

            return null;
        }

        protected List<Loop_ALC_INVOIC> generateALC_INVOIC()
        {
            List<Loop_ALC_INVOIC> alcLoopList = new List<Loop_ALC_INVOIC>();
            var alcLoop = new Loop_ALC_INVOIC();

            if (!string.IsNullOrEmpty(AllowanceChargeQualifier))
            {
                //  Charges to be paid by customer
                alcLoop.ALC = new ALC();
                alcLoop.ALC.Allowanceorchargequalifier_01 = AllowanceChargeQualifier;
                alcLoop.ALC.SPECIALSERVICESIDENTIFICATION_05 = new C214();
                alcLoop.ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservicescoded_01 = SpecialServicesCode;
                alcLoop.ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservice_04 = SpecialService;
            }

            if (!string.IsNullOrEmpty(PercentageQualifier))
            {
                alcLoop.PCDLoop = new Loop_PCD_INVOIC();
                alcLoop.PCDLoop.PCD = new PCD();
                alcLoop.PCDLoop.PCD.PERCENTAGEDETAILS_01 = new C501();
                alcLoop.PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentagequalifier_01 = PercentageQualifier;
                alcLoop.PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentage_02 = Percentage?.ToString("G29");
            }
            //  Repeating MOA Groups
            alcLoop.MOALoop = new List<Loop_MOA_INVOIC>();

            if (!string.IsNullOrEmpty(MonetaryTypeQualifier))
            {
                //  Begin MOA Group
                var moaAlcLoop = new Loop_MOA_INVOIC();
                //  Monetary amount for the charge 120 EUR to be added
                moaAlcLoop.MOA = new MOA();
                moaAlcLoop.MOA.MONETARYAMOUNT_01 = new C516();
                moaAlcLoop.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = MonetaryTypeQualifier;
                moaAlcLoop.MOA.MONETARYAMOUNT_01.Monetaryamount_02 = MonetaryAmount?.ToString("G29");
                moaAlcLoop.MOA.MONETARYAMOUNT_01.Currencycoded_03 = MonetaryCurrencyCode;
                //  End MOA Group
                alcLoop.MOALoop.Add(moaAlcLoop);
            }

            //  Repeating TAX Groups
            alcLoop.TAXLoop = new List<Loop_TAX_INVOIC_2>();

            if (!string.IsNullOrEmpty(AllowanceDutyTaxFeeQualifier))
            {
                //  Begin TAX Group
                var taxAlcLoop = new Loop_TAX_INVOIC_2();

                //  Type of tax is value added tax at 19 %
                taxAlcLoop.TAX = new TAX();
                taxAlcLoop.TAX.Dutytaxfeefunctionqualifier_01 = AllowanceDutyTaxFeeQualifier;
                taxAlcLoop.TAX.DUTYTAXFEETYPE_02 = new C241();
                taxAlcLoop.TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01 = AllowanceDutyTaxFeeCode;
                taxAlcLoop.TAX.DUTYTAXFEEDETAIL_05 = new C243();
                taxAlcLoop.TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04 = AllowanceDutyTaxFeeRate?.ToString("G29");
                taxAlcLoop.TAX.Dutytaxfeecategorycoded_06 = AllowanceDutyTaxFeeCategoryCode;

                //  End TAX Group
                alcLoop.TAXLoop.Add(taxAlcLoop);
            }
            alcLoopList.Add(alcLoop);
            return alcLoopList;
        }

        protected List<FII> generateFII()
        {
            List<FII> fiiList = new List<FII>();
            if (!string.IsNullOrEmpty(Bank1Iban))
            {
                FII fii1 = new FII();
                fii1.Partyqualifier_01 = Bank1PartyQualifier;
                fii1.ACCOUNTIDENTIFICATION_02 = new C078();
                fii1.ACCOUNTIDENTIFICATION_02.Accountholdernumber_01 = Bank1Iban;
                fii1.ACCOUNTIDENTIFICATION_02.Accountholdername_02 = Bank1Name;
                fii1.INSTITUTIONIDENTIFICATION_03 = new C088();
                fii1.INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01 = Bank1InstitutionNameId;
                fii1.INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04 = Bank1InstitutionBranchNumber;
                fii1.INSTITUTIONIDENTIFICATION_03.Institutionname_07 = Bank1InstitutionName;
                fii1.Countrycoded_04 = Bank1Country;
                fiiList.Add(fii1);
            }

            if (!string.IsNullOrEmpty(Bank2Iban))
            {
                FII fii2 = new FII();
                fii2.Partyqualifier_01 = Bank2PartyQualifier;
                fii2.ACCOUNTIDENTIFICATION_02 = new C078();
                fii2.ACCOUNTIDENTIFICATION_02.Accountholdernumber_01 = Bank2Iban;
                fii2.ACCOUNTIDENTIFICATION_02.Accountholdername_02 = Bank2Name;
                fii2.INSTITUTIONIDENTIFICATION_03 = new C088();
                fii2.INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01 = Bank2InstitutionNameId;
                fii2.INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04 = Bank2InstitutionBranchNumber;
                fii2.INSTITUTIONIDENTIFICATION_03.Institutionname_07 = Bank2InstitutionName;
                fii2.Countrycoded_04 = Bank2Country;

                fiiList.Add(fii2);
            }

            if (!string.IsNullOrEmpty(Bank3Iban))
            {
                FII fii3 = new FII();
                fii3.Partyqualifier_01 = Bank3PartyQualifier;
                fii3.ACCOUNTIDENTIFICATION_02 = new C078();
                fii3.ACCOUNTIDENTIFICATION_02.Accountholdernumber_01 = Bank3Iban;
                fii3.ACCOUNTIDENTIFICATION_02.Accountholdername_02 = Bank3Name;
                fii3.INSTITUTIONIDENTIFICATION_03 = new C088();
                fii3.INSTITUTIONIDENTIFICATION_03.Institutionnameidentification_01 = Bank3InstitutionNameId;
                fii3.INSTITUTIONIDENTIFICATION_03.Institutionbranchnumber_04 = Bank3InstitutionBranchNumber;
                fii3.INSTITUTIONIDENTIFICATION_03.Institutionname_07 = Bank3InstitutionName;
                fii3.Countrycoded_04 = Bank3Country;

                fiiList.Add(fii3);
            }


            return fiiList;
        }

        protected TAX generateTAX()
        {
            TAX tax = new TAX();
            tax.Dutytaxfeefunctionqualifier_01 = DutyTaxFeeQualifier;
            tax.DUTYTAXFEETYPE_02 = new C241();
            tax.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01 = DutyTaxFeeCode;
            tax.DUTYTAXFEEDETAIL_05 = new C243();
            if (DutyTaxFeeRate != null)
                tax.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04 = DutyTaxFeeRate?.ToString("G29");
            tax.Dutytaxfeecategorycoded_06 = DutyTaxFeeCategoryCode;
            return tax;

        }


        public void initRFF(RFF reff)
        {
            ReferenceQualifier = reff?.REFERENCE_01?.Referencequalifier_01;
            ReferenceNumber = reff?.REFERENCE_01?.Referencenumber_02;
        }
        public void initRefDate(DTM dtm)
        {
            if (dtm != null)
                ReferenceDate = dtm.DATETIMEPERIOD_01.asDateTime();
        }
        public RFF generateRFF()
        {
            if (!string.IsNullOrEmpty(ReferenceQualifier))
            {
                RFF rff = new RFF();
                rff.REFERENCE_01 = new C506();
                rff.REFERENCE_01.Referencequalifier_01 = ReferenceQualifier;
                rff.REFERENCE_01.Referencenumber_02 = ReferenceNumber;
                return rff;
            }

            return null;

        }

        public DTM generateReferenceDTM()
        {
            
            if (ReferenceDate != null)
            {
                var rffDtm1 = new DTM();
                rffDtm1.DATETIMEPERIOD_01 = new C507();
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiod_02 = ReferenceDate.Value.ToString("yyyyMMdd");
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return rffDtm1;
            }

            return null;

        }



    }
}
