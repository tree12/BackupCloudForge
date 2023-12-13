using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    /// <summary>
    /// 0940 21 LIN M 1 1 Line item
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// 1082 Line item number C n..6
        ///
        /// Positon number of this article. The position number is needed as reference in the return receipts to KTM(e.g. dispatch advices)
        /// </summary>
        public string LineItemNumber { get; set; }
        /// <summary>
        /// 7140 Item number C an..35
        ///
        /// KTM's article number of this line item
        /// </summary>
        public string ItemNumber { get; set; }
        /// <summary>
        /// 7143 Item number type, coded C an..3
        ///
        /// BP Buyer's part number
        /// </summary>
        public string ItemNumberType { get; set; }
        /// <summary>
        /// 0950 22 PIA C 25 2 Additional product id - 4347 Product id. function qualifier M an..3
        /// 
        /// </summary>
        public string AdditionalProductId { get; set; }
        /// <summary>
        /// 0950 22 PIA C 25 2 Additional product id - 7140 Item number C an..35
        /// 
        /// </summary>
        public string AdditionalItemNumber { get; set; }
        /// <summary>
        /// 0950 22 PIA C 25 2 Additional product id - 7143 Item number type, coded C an..3
        /// 
        /// </summary>
        public string AdditionalItemNumberType { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7077 Item description type, coded C an..3
        ///
        /// Item description type, coded 
        /// </summary>
        public string ItemDescriptionType  { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7081 Item characteristic, coded C an..3
        /// 
        /// </summary>
        public string ItemCharacteristicCode { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7009 Item description identification C an..17
        /// 
        /// </summary>
        public string ItemDescriptionIdentification { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 1131 Code list qualifier C an..3
        /// 
        /// </summary>
        public string CodeListQualifier { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 3055 Code list responsible agency, coded C an..3
        ///
        /// </summary>
        public string CodeListResponsibleAgency { get; set; }
        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7008 Item description C an..35
        ///
        /// Free text description of the line item.
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// 0410 SG10 C 1 3 RFF-DTM - 0420 23 RFF M 1 3 Reference
        /// C506 Reference M
        /// 1153 Reference qualifier M an..3 - ON Order number (purchase)
        /// </summary>
        public string ReceivedDeliveryReferenceQualifier { get; set; }
        /// <summary>
        /// 0410 SG10 C 1 3 RFF-DTM - 0420 23 RFF M 1 3 Reference
        /// C506 Reference M
        /// 1154 Reference number C an..35 -Purchase order number of KTM
        /// </summary>
        public string ReceivedDeliveryReferenceNumber { get; set; }
        /// <summary>
        /// 0410 SG10 C 1 3 RFF-DTM - 0430 24 DTM C 1 4 Date/time/period
        /// C507 Date/time/period M
        /// 
        /// </summary>
        public DateTime ReceivedDeliveryReferenceDate { get; set; }
        public Quantity Quantity { get; set; }
        public Quantity ReceivedQuantity { get; set; }
        public Quantity BackorderedQuantity { get; set; }
        public Quantity ScheduledQuantity { get; set; }

        /// <summary>
        /// 1080 25 FTX C 99 - 4451 Text subject qualifier M an..3
        ///
        /// AAI General information
        /// </summary>
        public string TextSubjectQualifier { get; set; }
        /// <summary>
        /// 1080 25 FTX C 99 - 4453 Text function, coded C an..3
        ///
        /// 1 Text for subsequent use
        /// </summary>
        public string TextFunctionCode { get; set; }
        /// <summary>
        /// 1080 25 FTX C 99 - 4440 Free text M an..70
        ///
        /// 1 Text for subsequent use
        /// </summary>
        public string FreeText { get; set; }
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
        public string MonetaryAmount { get; set; }
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
        public string Price { get; set; }
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
        /// C507 Date/time/period M
        /// 2005 Date/time/period qualifier M an..3 - 171 Reference date/time
        /// </summary>
        public DateTime PurchaseDate { get; set; }
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
        /// 1160 SG29 M 1 2 RFF-DTM - 1180 39 DTM C 1 3 Date/time/period
        /// C507 Date/time/period M
        /// 2005 Date/time/period qualifier M an..3 - 171 Reference date/time
        /// </summary>
        public DateTime DeliveryDate { get; set; }
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
        public string TaxMonetaryAmount { get; set; }
        /// <summary>
        /// 1310 SG33 M 1 2 TAX-MOA - 1330 43 MOA M 1 3 Monetary amount
        /// C516 Monetary amount M 
        /// 6345 Currency, coded C an..3
        /// </summary>
        public string TaxMonetaryCurrency { get; set; }


        public ScheduleCondition ScheduleCondition { get; set; }

        public void init(Loop_LIN_ORDERS linOrders)
        {
            LineItemNumber = linOrders.LIN.Lineitemnumber_01;
            ItemNumber = linOrders.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01;
            ItemNumberType = linOrders.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02;
            AdditionalProductId = linOrders.PIA[0]?.Productidfunctionqualifier_01;
            AdditionalItemNumber = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
            AdditionalItemNumberType = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
            ItemDescriptionType = linOrders.IMD[0]?.Itemdescriptiontypecoded_01;
            ItemCharacteristicCode = linOrders.IMD[0]?.Itemcharacteristiccoded_02;
            ItemDescriptionIdentification = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
            CodeListQualifier = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Codelistqualifier_02;
            CodeListResponsibleAgency = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
            ItemDescription = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Itemdescription_04;
            Quantity = GenerateQuantity(linOrders.QTY[0]);
            TextSubjectQualifier = linOrders.FTX[0]?.Textsubjectqualifier_01;
            TextFunctionCode = linOrders.FTX[0]?.Textfunctioncoded_02;
            FreeText = linOrders.FTX[0].TEXTLITERAL_04.Freetext_01;
            PriceQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            Price = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02;
            UnitPriceBasis = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            ScheduleCondition = GenerateScheduleCondition(linOrders.SCCLoop[0]);
        }
        public void init(Loop_LIN_INVOIC linInvoices)
        {
            LineItemNumber = linInvoices.LIN.Lineitemnumber_01;
            ItemNumber = linInvoices.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01;
            ItemNumberType = linInvoices.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02;
            AdditionalProductId = linInvoices.PIA[0]?.Productidfunctionqualifier_01;
            AdditionalItemNumber = linInvoices.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
            AdditionalItemNumberType = linInvoices.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
            ItemDescriptionType = linInvoices.IMD[0]?.Itemdescriptiontypecoded_01;
            ItemCharacteristicCode = linInvoices.IMD[0]?.Itemcharacteristiccoded_02;
            ItemDescriptionIdentification = linInvoices.IMD[0]?.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
            CodeListQualifier = linInvoices.IMD[0]?.ITEMDESCRIPTION_03.Codelistqualifier_02;
            CodeListResponsibleAgency = linInvoices.IMD[0]?.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
            ItemDescription = linInvoices.IMD[0]?.ITEMDESCRIPTION_03.Itemdescription_04;
            Quantity = GenerateQuantity(linInvoices.QTY[0]);
            TextSubjectQualifier = linInvoices.FTX[0]?.Textsubjectqualifier_01;
            TextFunctionCode = linInvoices.FTX[0]?.Textfunctioncoded_02;
            FreeText = linInvoices.FTX[0].TEXTLITERAL_04.Freetext_01;

            MonetaryTypeQualifier = linInvoices.MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            MonetaryAmount = linInvoices.MOALoop[0].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            MonetaryCurrency = linInvoices.MOALoop[0].MOA.MONETARYAMOUNT_01.Currencycoded_03;
            PriceQualifier = linInvoices.PRILoop[0].PRI.PRICEINFORMATION_01.Pricequalifier_01;
            Price = linInvoices.PRILoop[0].PRI.PRICEINFORMATION_01.Price_02;
            UnitPriceBasis = linInvoices.PRILoop[0].PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linInvoices.PRILoop[0].PRI.PRICEINFORMATION_01.Measureunitqualifier_06;

            PurchaseReferenceQualifier = linInvoices.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            PurchaseReferenceNumber = linInvoices.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            PurchaseLineNumber = linInvoices.RFFLoop[0].RFF.REFERENCE_01.Linenumber_03;
            PurchaseDate = linInvoices.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();

            DeliveryReferenceQualifier = linInvoices.RFFLoop[1].RFF.REFERENCE_01.Referencequalifier_01;
            DeliveryReferenceNumber = linInvoices.RFFLoop[1].RFF.REFERENCE_01.Referencenumber_02;
            DeliveryLineNumber = linInvoices.RFFLoop[1].RFF.REFERENCE_01.Linenumber_03;
            DeliveryDate = linInvoices.RFFLoop[1].DTM[0].DATETIMEPERIOD_01.asDateTime();

            InvoiceDutyTaxFeeQualifier = linInvoices.TAXLoop[0].TAX.Dutytaxfeefunctionqualifier_01;
            InvoiceTax = linInvoices.TAXLoop[0].TAX.DUTYTAXFEETYPE_02.Dutytaxfeetypecoded_01;
            InvoiceDutyTaxFeeRate = linInvoices.TAXLoop[0].TAX.DUTYTAXFEEDETAIL_05.Dutytaxfeerate_04;
            TaxCategoryCode = linInvoices.TAXLoop[0].TAX.Dutytaxfeecategorycoded_06;

            TaxMonetaryTypeQualifier = linInvoices.TAXLoop[0].MOA.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01;
            TaxMonetaryAmount = linInvoices.TAXLoop[0].MOA.MONETARYAMOUNT_01.Monetaryamount_02;
            TaxMonetaryCurrency = linInvoices.TAXLoop[0].MOA.MONETARYAMOUNT_01.Currencycoded_03;

            PriceQualifier = linInvoices.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            Price = linInvoices.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02;
            UnitPriceBasis = linInvoices.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linInvoices.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
        }
        public void init(Loop_LIN_ORDCHG linOrders)
        {
            LineItemNumber = linOrders.LIN.Lineitemnumber_01;
            ItemNumber = linOrders.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01;
            ItemNumberType = linOrders.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02;
            AdditionalProductId = linOrders.PIA[0]?.Productidfunctionqualifier_01;
            AdditionalItemNumber = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
            AdditionalItemNumberType = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
            ItemDescriptionType = linOrders.IMD[0]?.Itemdescriptiontypecoded_01;
            ItemCharacteristicCode = linOrders.IMD[0]?.Itemcharacteristiccoded_02;
            ItemDescriptionIdentification = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
            CodeListQualifier = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Codelistqualifier_02;
            CodeListResponsibleAgency = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
            ItemDescription = linOrders.IMD[0]?.ITEMDESCRIPTION_03.Itemdescription_04;
            Quantity = GenerateQuantity(linOrders.QTY[0]);
            TextSubjectQualifier = linOrders.FTX[0]?.Textsubjectqualifier_01;
            TextFunctionCode = linOrders.FTX[0]?.Textfunctioncoded_02;
            FreeText = linOrders.FTX[0].TEXTLITERAL_04.Freetext_01;
            PriceQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            Price = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02;
            UnitPriceBasis = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            ScheduleCondition = GenerateScheduleCondition(linOrders.SCCLoop[0]);
        }

        public void init(Loop_LIN_DELFOR linDelfors)
        {
            LineItemNumber = linDelfors.LIN.Lineitemnumber_01;
            ItemNumber = linDelfors.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01;
            ItemNumberType = linDelfors.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02;
            AdditionalProductId = linDelfors.PIA[0]?.Productidfunctionqualifier_01;
            AdditionalItemNumber = linDelfors.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
            AdditionalItemNumberType = linDelfors.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
            ItemDescriptionType = linDelfors.IMD[0]?.Itemdescriptiontypecoded_01;
            ItemCharacteristicCode = linDelfors.IMD[0]?.Itemcharacteristiccoded_02;
            ItemDescriptionIdentification = linDelfors.IMD[0]?.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
            CodeListQualifier = linDelfors.IMD[0]?.ITEMDESCRIPTION_03.Codelistqualifier_02;
            CodeListResponsibleAgency = linDelfors.IMD[0]?.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
            ItemDescription = linDelfors.IMD[0]?.ITEMDESCRIPTION_03.Itemdescription_04;
            ReceivedDeliveryReferenceQualifier = linDelfors.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReceivedDeliveryReferenceNumber = linDelfors.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReceivedDeliveryReferenceDate = linDelfors.RFFLoop[0].DTM.DATETIMEPERIOD_01.asDateTime();

            Quantity = GenerateQuantity(linDelfors.QTYLoop[0].QTY);
            ReceivedQuantity = GenerateQuantity(linDelfors.QTYLoop[1].QTY);
            BackorderedQuantity = GenerateQuantity(linDelfors.QTYLoop[2].QTY);
            ScheduledQuantity = GenerateQuantity(linDelfors.QTYLoop[3].QTY);
            ScheduleCondition = GenerateScheduleCondition(linDelfors.QTYLoop[3]);

        }
        public void init(Loop_LIN_ORDRSP linOrdrsps)
        {
            LineItemNumber = linOrdrsps.LIN.Lineitemnumber_01;
            ItemNumber = linOrdrsps.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01;
            ItemNumberType = linOrdrsps.LIN.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02;
            AdditionalProductId = linOrdrsps.PIA[0]?.Productidfunctionqualifier_01;
            AdditionalItemNumber = linOrdrsps.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
            AdditionalItemNumberType = linOrdrsps.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
            ItemDescriptionType = linOrdrsps.IMD[0]?.Itemdescriptiontypecoded_01;
            ItemCharacteristicCode = linOrdrsps.IMD[0]?.Itemcharacteristiccoded_02;
            ItemDescriptionIdentification = linOrdrsps.IMD[0]?.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
            CodeListQualifier = linOrdrsps.IMD[0]?.ITEMDESCRIPTION_03.Codelistqualifier_02;
            CodeListResponsibleAgency = linOrdrsps.IMD[0]?.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
            ItemDescription = linOrdrsps.IMD[0]?.ITEMDESCRIPTION_03.Itemdescription_04;
            Quantity = GenerateQuantity(linOrdrsps.QTY[0]);
            //TextSubjectQualifier = linOrdrsps.FTX[0]?.Textsubjectqualifier_01;
            //TextFunctionCode = linOrdrsps.FTX[0]?.Textfunctioncoded_02;
            //FreeText = linOrdrsps.FTX[0].TEXTLITERAL_04.Freetext_01;

            PurchaseReferenceQualifier = linOrdrsps.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            PurchaseReferenceNumber = linOrdrsps.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            PurchaseLineNumber = linOrdrsps.RFFLoop[0].RFF.REFERENCE_01.Linenumber_03;
            PurchaseDate = linOrdrsps.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();

            PriceQualifier = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            Price = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02;
            UnitPriceBasis = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            ScheduleCondition = GenerateScheduleCondition(linOrdrsps.SCCLoop[0]);
        }
        private Quantity GenerateQuantity(EdiFabric.Templates.EdifactD96A.QTY qty)
        {
            Quantity quqQuantity = new Quantity();
            if (qty != null)
            {
                quqQuantity.init(qty);
            }
            return quqQuantity;
        }
        private ScheduleCondition GenerateScheduleCondition(Loop_SCC_ORDERS scc)
        {
           
                ScheduleCondition scheduleCondition = new ScheduleCondition();
                scheduleCondition.init(scc);

                return scheduleCondition;
        }
        private ScheduleCondition GenerateScheduleCondition(Loop_SCC_ORDCHG scc)
        {
          
                ScheduleCondition scheduleCondition = new ScheduleCondition();
                scheduleCondition.init(scc);

                return scheduleCondition;
        }
        private ScheduleCondition GenerateScheduleCondition(Loop_QTY_DELFOR scc)
        {

            ScheduleCondition scheduleCondition = new ScheduleCondition();
            scheduleCondition.init(scc);

            return scheduleCondition;
        }
        private ScheduleCondition GenerateScheduleCondition(Loop_SCC_ORDRSP scc)
        {

            ScheduleCondition scheduleCondition = new ScheduleCondition();
            scheduleCondition.init(scc);

            return scheduleCondition;
        }

    }
}
