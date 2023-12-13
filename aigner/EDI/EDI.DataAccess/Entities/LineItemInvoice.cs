using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Common.Entity.Abstracts;

namespace EDI.DataAccess.Entities
{
    /// <summary>
    /// 0940 21 LIN M 1 1 Line item
    /// </summary>
    public class LineItemInvoice : LineItemBase<LineItemInvoice>
    {
        /// <summary>
        /// 1080 25 FTX C 99 - 4451 Text subject qualifier M an..3
        ///
        /// AAI General information
        /// </summary>
        public string TextSubjectQualifier { get; set; }
        /// <summary>
        /// 1080 25 FTX C 99 - 4440 Free text M an..70
        ///
        /// 1 Text for subsequent use
        /// </summary>
        public string FreeTextLineItem { get; set; }
        /// <summary>
        /// 1030 SG26 M 1 2 MOA - 1040 36 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3
        /// </summary>
        public string MonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1030 SG26 M 1 2 MOA - 1040 36 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? MonetaryAmount { get; set; }
        /// <summary>
        /// 1030 SG26 M 1 2 MOA - 1040 36 MOA M 1 2 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string MonetaryCurrency { get; set; }
        /// <summary>
        /// 1190 26 PRI M 1 2 Price details - 5125 Price qualifier M an..3
        ///
        /// AAA Calculation net
        /// </summary>
        public string PriceQualifier { get; set; }
        /// <summary>
        /// 1190 26 PRI M 1 2 Price details - 5118 Price C n..15
        ///
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 1190 26 PRI M 1 2 Price details - 5284 Unit price basis C n..9
        ///
        /// </summary>
        public string UnitPriceBasis { get; set; }
        /// <summary>
        /// 1190 26 PRI M 1 2 Price details - 6411 Measure unit qualifier C an..3
        ///
        /// </summary>
        public string PriceMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1153 Reference qualifier M an..3 - ON Order number (purchase)
        /// </summary>
        public string PurchaseReferenceQualifier { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1154 Reference number C an..35 -Purchase order number of KTM
        /// </summary>
        public string PurchaseReferenceNumber { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1156 Line number C an..6 - Line number of referenced KTM purchase order line item
        /// </summary>
        public string PurchaseLineNumber { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1180 39 DTM C 1 3 Date/time/period
        /// 
        /// C507 Date/time/period - 2005 Date/time/period qualifier M an..3 M an..3 171 Reference date/time
        /// </summary>
        public string PurchaseDateQualifier { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1180 39 DTM C 1 3 Date/time/period
        /// C507 Date/time/period M
        /// 2005 Date/time/period qualifier M an..3 - 171 Reference date/time
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1180 39 DTM C 1 3 Date/time/period
        /// 
        /// C507 Date/time/period M M - 2379 Date/time/period format qualifier C an..3 M an..3 102 CCYYMMDD
        /// </summary>
        public string PurchaseDateFormat { get; set; }

        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1153 Reference qualifier M an..3 - ON Order number (purchase)
        /// </summary>
        public string DeliveryReferenceQualifier { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1154 Reference number C an..35 -Purchase order number of KTM
        /// </summary>
        public string DeliveryReferenceNumber { get; set; }
        /// <summary>
        /// 1160 SG29 M 1 2 RFF-DTM - 1170 38 RFF M 1 2 Reference
        /// C506 Reference M
        /// 1156 Line number C an..6 - Line number of referenced KTM purchase order line item
        /// </summary>
        public string DeliveryLineNumber { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1320 42 TAX M 1 2 Duty/tax/fee details
        /// 
        /// 5283 Duty/tax/fee function qualifier M an..3
        /// </summary>
        public string InvoiceDutyTaxFeeQualifier { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1320 42 TAX M 1 2 Duty/tax/fee details
        /// C241 Duty/tax/fee type C
        /// 5153 Duty/tax/fee type, coded C an..3 VAT Value added tax
        /// </summary>
        public string InvoiceTax { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1320 42 TAX M 1 2 Duty/tax/fee details
        /// C243 Duty/tax/fee detail C
        /// 5278 Duty/tax/fee rate C an..17
        /// </summary>
        public string InvoiceDutyTaxFeeRate { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1320 42 TAX M 1 2 Duty/tax/fee details
        /// 
        /// 5305 Duty/tax/fee category, coded C an..3
        /// </summary>
        public string TaxCategoryCode { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1330 43 MOA M 1 3 Monetary amount
        /// C516 Monetary amount M 
        /// 5025 Monetary amount type qualifier M an..3
        /// </summary>
        public string TaxMonetaryTypeQualifier { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1330 43 MOA M 1 3 Monetary amount
        /// C516 Monetary amount M 
        /// 5004 Monetary amount C n..18
        /// </summary>
        public decimal? TaxMonetaryAmount { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1330 43 MOA M 1 3 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string TaxMonetaryCurrency { get; set; }

        public void init(Loop_LIN_INVOIC linInvoices)
        {
            initLIN(linInvoices.LIN);
            initPIA(linInvoices.PIA);
            initIMD(linInvoices.IMD);
            if (linInvoices.QTY.Count > 1)
                AddEdiConvertError("Order Quantity more than 1");
            initQTY(linInvoices.QTY.FirstOrDefault(x=>x.QUANTITYDETAILS_01.Quantityqualifier_01 == "47"));//47 Invoiced quantity


            if (linInvoices.FTX.Count > 1) AddEdiConvertError("Free text more than one.");
            var ftx = linInvoices.FTX.FirstOrDefault();
            if (ftx != null)
            {
                TextSubjectQualifier = ftx.Textsubjectqualifier_01;
                FreeTextLineItem = ftx.TEXTLITERAL_04.Freetext_01;
            }

            if (linInvoices.MOALoop?.Count > 1) AddEdiConvertError("Monetary amount more than one.");
            var moa = linInvoices.MOALoop?[0].MOA;
            if (moa != null)
            {
                MonetaryTypeQualifier = moa.MONETARYAMOUNT_01?.Monetaryamounttypequalifier_01;
                if (!string.IsNullOrEmpty(moa.MONETARYAMOUNT_01?.Monetaryamount_02))
                    MonetaryAmount = decimal.Parse(moa.MONETARYAMOUNT_01.Monetaryamount_02);
                MonetaryCurrency = moa.MONETARYAMOUNT_01?.Currencycoded_03;
            }
            if (linInvoices.PRILoop.Count > 1) AddEdiConvertError("Price details more than one.");
            var pri = linInvoices.PRILoop.FirstOrDefault();
            if (pri != null)
            {
                PriceQualifier = pri.PRI.PRICEINFORMATION_01.Pricequalifier_01;

                if (!string.IsNullOrEmpty(pri.PRI.PRICEINFORMATION_01.Price_02)) 
                    Price = decimal.Parse(pri.PRI.PRICEINFORMATION_01.Price_02);
                UnitPriceBasis = pri.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
                PriceMeasureUnitQualifier = pri.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;

                /***ON Order number (purchase)***/
                var purchaseReference = linInvoices.RFFLoop.FirstOrDefault(x => x.RFF?.REFERENCE_01?.Referencequalifier_01 == "ON");
                /***DQ Delivery note number***/
                var deliveryReference = linInvoices.RFFLoop.FirstOrDefault(x => x.RFF?.REFERENCE_01?.Referencequalifier_01 == "DQ");
                if (purchaseReference != null)
                {
                    PurchaseReferenceQualifier = purchaseReference.RFF?.REFERENCE_01?.Referencequalifier_01;
                    PurchaseReferenceNumber = purchaseReference.RFF?.REFERENCE_01?.Referencenumber_02;
                    PurchaseLineNumber = purchaseReference.RFF?.REFERENCE_01?.Linenumber_03;
                    if (purchaseReference.DTM.Count > 0)
                    {
                        PurchaseDateQualifier = purchaseReference.DTM[0].DATETIMEPERIOD_01.Datetimeperiodqualifier_01;
                        PurchaseDate = purchaseReference.DTM[0].DATETIMEPERIOD_01.asDateTime();
                        PurchaseDateFormat = purchaseReference.DTM[0].DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03;
                    }

                    
                }

                if (deliveryReference != null)
                {
                    DeliveryReferenceQualifier = deliveryReference.RFF.REFERENCE_01.Referencequalifier_01;
                    DeliveryReferenceNumber = deliveryReference.RFF.REFERENCE_01.Referencenumber_02;
                    DeliveryLineNumber = deliveryReference.RFF.REFERENCE_01.Linenumber_03;
                    if (deliveryReference.DTM.Count > 0)
                        base.initDeliveryDTM(deliveryReference.DTM[0]);
                    //DeliveryDate = deliveryReference.DTM[0].DATETIMEPERIOD_01.asDateTime();
                }

                if (linInvoices.TAXLoop?.Count > 1) AddEdiConvertError("Tax details more than one.");
                var tax = linInvoices.TAXLoop.FirstOrDefault();
                if (tax != null)
                {
                    InvoiceDutyTaxFeeQualifier = tax.TAX?.Dutytaxfeefunctionqualifier_01;
                    InvoiceTax = tax.TAX?.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
                    InvoiceDutyTaxFeeRate = tax.TAX?.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04;
                    TaxCategoryCode = tax.TAX?.Dutytaxfeecategorycoded_06;


                    TaxMonetaryTypeQualifier = tax.MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
                    if (!string.IsNullOrEmpty(tax.MOA.MONETARYAMOUNT_01.Monetaryamount_02))
                        TaxMonetaryAmount = decimal.Parse(tax.MOA.MONETARYAMOUNT_01.Monetaryamount_02);
                    TaxMonetaryCurrency = tax.MOA.MONETARYAMOUNT_01.Currencycoded_03;
                }


                PriceQualifier = pri.PRI.PRICEINFORMATION_01.Pricequalifier_01;
                if (!string.IsNullOrEmpty(pri.PRI.PRICEINFORMATION_01.Price_02))
                    Price = decimal.Parse(pri.PRI.PRICEINFORMATION_01.Price_02);
                UnitPriceBasis = pri.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
                PriceMeasureUnitQualifier = pri.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            }

        }
        //Cannot use generateDeliveryDTM in base class because Datetimeperiodqualifier_01 is difference.
        public new DTM generateDeliveryDTM()
        {
            if (!string.IsNullOrEmpty(DeliveryDateQualifier))
            {
                DTM dtm = base.generateDeliveryDTM();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = DeliveryDateQualifier ?? "171";
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = DeliveryDateFormat ?? "102";
                //dtm.DATETIMEPERIOD_01 = new C507();
                //dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                //if (DeliveryDate != null)
                //    dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = DeliveryDate.Value.ToString("yyyyMMdd");
                //dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";

                return dtm;
            }

            return null;
        }

        public override void Configure(EntityTypeBuilder<LineItemInvoice> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }

    }
}
