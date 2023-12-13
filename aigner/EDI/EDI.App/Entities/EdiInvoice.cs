using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class EdiInvoice : EdiMasterMessage
    {
       
        ////-------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1153 Reference qualifier M an..3 
        ///
        /// ON Order number (purchase)
        /// </summary>
        public string DeliveryReferenceQualifier { get; set; }

        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string DeliveryReferenceNumber { get; set; }

        /// <summary>
        /// 0080 SG1 C 10 1 RFF-DTM
        /// 0100 8 DTM C 5 2 Date/time/period
        ///
        /// 
        /// </summary>
        public DateTime DeliveryReferenceDate { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD
        /// 0120 11 NAD M 1 1 Name and address
        /// </summary>
        public NameAndAddress Buyer { get; set; }
        public NameAndAddress Supplier { get; set; }
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
        public string DutyTaxFeeRate { get; set; }
        /// <summary>
        /// 0240 SG6 C 5 1 TAX - 0250 21 TAX M 1 1 Duty/tax/fee details
        ///
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string DutyTaxFeeCategoryCode { get; set; }
        /// <summary>
        /// 0280 SG7 M 1 1 CUX - 0290 22 CUX M 1 1 Currencies
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 0310 SG8 D 10 1 PAT-PCD
        /// </summary>
        public PaymentTerm PaymentTerm { get; set; }
        /// <summary>
        /// 0460 SG12 C 5 1 TOD-LOC
        /// </summary>
        public DeliveryOrTransportTerm DeliveryOrTransportTerm { get; set; }
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
        public string Percentage { get; set; }
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
        public string MonetaryAmount { get; set; }
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
        public string AllowanceDutyTaxFeeRate { get; set; }
        /// <summary>
        /// 0750 SG21 C 5 2 TAX - 0760 30 TAX M 1 2 Duty/tax/fee details
        ///
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string AllowanceDutyTaxFeeCategoryCode { get; set; }
        /// <summary>
        /// 0890 SG25 M 9999999 1 LIN-PIA-IMD-QTY-FTX-SG26-SG28-SG29-SG33 - 0900 31 LIN M 1 1 Line item
        /// </summary>
        public List<LineItem> LineItems { get; set; }
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
        public string InvoiceMonetaryAmount { get; set; }
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
        public string TaxableMonetaryAmount { get; set; }
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
        public string TotalMonetaryAmount { get; set; }
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
        public string AmountDutyTaxFeeRate { get; set; }
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
        public string SumTaxMonetaryAmount { get; set; }
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
        public string SumTaxableMonetaryAmount { get; set; }
        /// <summary>
        /// 1860 SG50 M 10 1 TAX-MOA - 1880 50 MOA C 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string SumTaxableMonetaryCurrency { get; set; }

        public void init(TSINVOIC tsInvoice)
        {
            base.init(tsInvoice.BGM);
            base.init(tsInvoice.UNH);
            base.init(tsInvoice?.FTX[0]);
            base.init(tsInvoice.UNT);
            DocumentDate = tsInvoice.DTM[0].DATETIMEPERIOD_01.asDateTime();

            //Invoice  Reference
            ReferenceQualifier = tsInvoice.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReferenceNumber = tsInvoice.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReferenceDate = tsInvoice.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            
            DeliveryReferenceQualifier = tsInvoice.RFFLoop[1].RFF.REFERENCE_01.Referencequalifier_01;
            DeliveryReferenceNumber = tsInvoice.RFFLoop[1].RFF.REFERENCE_01.Referencenumber_02;
            DeliveryReferenceDate = tsInvoice.RFFLoop[1].DTM[0].DATETIMEPERIOD_01.asDateTime();

            Buyer = GenerateNameAndAddress(tsInvoice.NADLoop[0]);
            Supplier = GenerateNameAndAddress(tsInvoice.NADLoop[1]);
            DutyTaxFeeQualifier = tsInvoice.TAXLoop[0].TAX.Dutytaxfeefunctionqualifier_01;
            DutyTaxFeeCode = tsInvoice.TAXLoop[0].TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
            DutyTaxFeeRate = tsInvoice.TAXLoop[0].TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04;
            DutyTaxFeeCategoryCode = tsInvoice.TAXLoop[0].TAX.Dutytaxfeecategorycoded_06;

            Currency = tsInvoice.CUXLoop[0].CUX.CURRENCYDETAILS_01.Currencycoded_02;
            PaymentTerm = GeneratePaymentTerm(tsInvoice.PATLoop[0]);
            DeliveryOrTransportTerm = GenerateDeliveryOrTransportTerm(tsInvoice.TODLoop[0]);
            AllowanceChargeQualifier = tsInvoice.ALCLoop[0].ALC.Allowanceorchargequalifier_01;
            SpecialServicesCode = tsInvoice.ALCLoop[0].ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservicescoded_01;
            SpecialService = tsInvoice.ALCLoop[0].ALC.SPECIALSERVICESIDENTIFICATION_05.Specialservice_04;
            PercentageQualifier = tsInvoice.ALCLoop[0].PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentagequalifier_01;
            Percentage = tsInvoice.ALCLoop[0].PCDLoop.PCD.PERCENTAGEDETAILS_01.Percentage_02;

            MonetaryTypeQualifier = tsInvoice.ALCLoop[0].MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            MonetaryAmount = tsInvoice.ALCLoop[0].MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            MonetaryCurrencyCode = tsInvoice.ALCLoop[0].MOALoop[0].MOA.MONETARYAMOUNT_01.Currencycoded_03;
            AllowanceDutyTaxFeeQualifier = tsInvoice.ALCLoop[0].TAXLoop[0].TAX.Dutytaxfeefunctionqualifier_01;
            AllowanceDutyTaxFeeCode = tsInvoice.ALCLoop[0].TAXLoop[0].TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
            AllowanceDutyTaxFeeRate = tsInvoice.ALCLoop[0].TAXLoop[0].TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04;
            AllowanceDutyTaxFeeCategoryCode = tsInvoice.ALCLoop[0].TAXLoop[0].TAX.Dutytaxfeecategorycoded_06;

            LineItems = GenerateLineItems(tsInvoice.LINLoop);

            InvoiceMonetaryTypeQualifier = tsInvoice.MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            InvoiceMonetaryAmount = tsInvoice.MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            InvoiceMonetaryCurrency = tsInvoice.MOALoop[0].MOA.MONETARYAMOUNT_01.Currencycoded_03;

            TaxableMonetaryTypeQualifier = tsInvoice.MOALoop[1].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            TaxableMonetaryAmount = tsInvoice.MOALoop[1].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            TaxableMonetaryCurrency = tsInvoice.MOALoop[1].MOA.MONETARYAMOUNT_01.Currencycoded_03;

            TotalMonetaryTypeQualifier = tsInvoice.MOALoop[2].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            TotalMonetaryAmount = tsInvoice.MOALoop[2].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            TotalMonetaryCurrency = tsInvoice.MOALoop[2].MOA.MONETARYAMOUNT_01.Currencycoded_03;

            AmountDutyTaxFeeQualifier = tsInvoice.TAXLoop2[0].TAX.Dutytaxfeefunctionqualifier_01;
            AmountDutyTaxFeeCode = tsInvoice.TAXLoop2[0].TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
            AmountDutyTaxFeeRate = tsInvoice.TAXLoop2[0].TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04;
            AmountDutyTaxFeeCategoryCode = tsInvoice.TAXLoop2[0].TAX.Dutytaxfeecategorycoded_06;

            SumTaxMonetaryTypeQualifier = tsInvoice.TAXLoop2[0].MOA[0].MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            SumTaxMonetaryAmount = tsInvoice.TAXLoop2[0].MOA[0].MONETARYAMOUNT_01.Monetaryamount_02;
            SumTaxMonetaryCurrency = tsInvoice.TAXLoop2[0].MOA[0].MONETARYAMOUNT_01.Currencycoded_03;

            SumTaxableMonetaryTypeQualifier = tsInvoice.TAXLoop2[0].MOA[1].MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            SumTaxableMonetaryAmount = tsInvoice.TAXLoop2[0].MOA[1].MONETARYAMOUNT_01.Monetaryamount_02;
            SumTaxableMonetaryCurrency = tsInvoice.TAXLoop2[0].MOA[1].MONETARYAMOUNT_01.Currencycoded_03;

        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_INVOIC nadInvoices)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(nadInvoices);
            return nameAndAddress;
        }
        private PaymentTerm GeneratePaymentTerm(Loop_PAT_INVOIC patInvoices)
        {
            var paymentTerm = new PaymentTerm();
            paymentTerm.init(patInvoices);
            return paymentTerm;
        }
        private DeliveryOrTransportTerm GenerateDeliveryOrTransportTerm(Loop_TOD_INVOIC todInvoices)
        {
            var paymentTerm = new DeliveryOrTransportTerm();
            paymentTerm.init(todInvoices);
            return paymentTerm;
        }
        private List<LineItem> GenerateLineItems(List<Loop_LIN_INVOIC> linOrders)
        {
            List<LineItem> lineItems = new List<LineItem>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItem();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }
    }
}
