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
    public class LineItemOrderConfirmation : LineItemBase<LineItemOrderConfirmation>
    {
        /// <summary>
        /// 0960 SG26 M 200000 1 LIN-PIA-IMD-QTY-SG30-SG31-SG5 
        /// 1010 22 QTY M 10 2 Quantity
        /// 6063 Quantity qualifier M an..3 M an..3 66 Committed quantity
        /// </summary>
        public string CommittedQuantityQualifier { get; set; }
        /// <summary>
        /// 1010 22 QTY M 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? CommittedItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string CommittedQTYMeasureUnitQualifier { get; set; }

        /// <summary>
        /// 1229 Action request/notification, coded C an..3
        ///
        /// 1 Added
        /// 2 Deleted
        /// 3 Changed
        /// 4 No action
        /// </summary>
        public string ActionRequestCoded { get; set; }

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
        /// 1920 SG49 C 100 2 SCC-SG50 -1930 27 SCC M 1 2 Scheduling conditions
        /// 4017 Delivery plan status indicator, coded
        /// 1 Firm Planned quantity - is always 1.
        /// </summary>
        public string DeliveryPlanStatusIndicatorCode { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string ScheduleQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public int? ScheduleItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string ScheduleQTYMeasureUnitQualifier { get; set; }

        public void init(Loop_LIN_ORDRSP linOrdrsps)
        {
            base.initLIN(linOrdrsps.LIN);
            base.initPIA(linOrdrsps.PIA);
            base.initIMD(linOrdrsps.IMD);
            initQTY(linOrdrsps.QTY.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "21"));
            initCommittedQTY(linOrdrsps.QTY.FirstOrDefault(x => x.QUANTITYDETAILS_01.Quantityqualifier_01 == "66"));

            ActionRequestCoded = linOrdrsps.LIN.Actionrequestnotificationcoded_02;

            //Quantity = GenerateQuantity(linOrdrsps.QTY[0]);
            if (linOrdrsps.QTY[0] != null)
            {
                QuantityQualifier = linOrdrsps.QTY.FirstOrDefault()?.QUANTITYDETAILS_01?.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(linOrdrsps.QTY.FirstOrDefault()?.QUANTITYDETAILS_01?.Quantity_02))
                    ItemQuantity = decimal.Parse(linOrdrsps.QTY.FirstOrDefault().QUANTITYDETAILS_01?.Quantity_02);
                QTYMeasureUnitQualifier = linOrdrsps.QTY.FirstOrDefault()?.QUANTITYDETAILS_01?.Measureunitqualifier_03;
            }
            //TextSubjectQualifier = linOrdrsps.FTX[0]?.Textsubjectqualifier_01;
            //TextFunctionCode = linOrdrsps.FTX[0]?.Textfunctioncoded_02;
            //FreeText = linOrdrsps.FTX[0].TEXTLITERAL_04.Freetext_01;

            PurchaseReferenceQualifier = linOrdrsps.RFFLoop.FirstOrDefault()?.RFF.REFERENCE_01.Referencequalifier_01;
            PurchaseReferenceNumber = linOrdrsps.RFFLoop.FirstOrDefault()?.RFF.REFERENCE_01.Referencenumber_02;
            PurchaseLineNumber = linOrdrsps.RFFLoop.FirstOrDefault()?.RFF.REFERENCE_01.Linenumber_03;
            PurchaseDateQualifier =
                linOrdrsps.RFFLoop.FirstOrDefault().DTM[0].DATETIMEPERIOD_01.Datetimeperiodqualifier_01;
            PurchaseDate = linOrdrsps.RFFLoop.FirstOrDefault().DTM[0].DATETIMEPERIOD_01.asDateTime();
            PurchaseDateFormat =
                linOrdrsps.RFFLoop.FirstOrDefault().DTM[0].DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03;

            PriceQualifier = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            if (!string.IsNullOrEmpty(linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02))
                Price = decimal.Parse(linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02);
            UnitPriceBasis = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linOrdrsps.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            //ScheduleCondition = GenerateScheduleCondition(linOrdrsps.SCCLoop[0]);

            if (linOrdrsps.SCCLoop[0] != null)
            {
                DeliveryPlanStatusIndicatorCode = linOrdrsps.SCCLoop[0].SCC.Deliveryplanstatusindicatorcoded_01;
                //DeliveryDate = linOrdrsps.SCCLoop[0].QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
                base.initDeliveryDTM(linOrdrsps.SCCLoop[0].QTYLoop[0]?.DTM[0]);
                //Quantity = GenerateQuantity(scc.QTYLoop[0]?.QTY);
                if (linOrdrsps.SCCLoop[0].QTYLoop[0]?.QTY != null)
                {
                    ScheduleQuantityQualifier = linOrdrsps.SCCLoop[0].QTYLoop[0]?.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01;
                    if (!string.IsNullOrEmpty(linOrdrsps.SCCLoop[0].QTYLoop[0]?.QTY?.QUANTITYDETAILS_01?.Quantity_02))
                        ScheduleItemQuantity = int.Parse(linOrdrsps.SCCLoop[0].QTYLoop[0]?.QTY?.QUANTITYDETAILS_01?.Quantity_02);
                    ScheduleQTYMeasureUnitQualifier = linOrdrsps.SCCLoop[0].QTYLoop[0]?.QTY?.QUANTITYDETAILS_01?.Measureunitqualifier_03;
                }
            }
        }

        #region Generate EDI
        public void initCommittedQTY(QTY qty)
        {
            if (qty != null)
            {
                CommittedQuantityQualifier = qty.QUANTITYDETAILS_01.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(qty.QUANTITYDETAILS_01.Quantity_02))
                    CommittedItemQuantity = decimal.Parse(qty.QUANTITYDETAILS_01.Quantity_02);
                CommittedQTYMeasureUnitQualifier = qty.QUANTITYDETAILS_01.Measureunitqualifier_03;
            }

        }
        public PRI generateComfirmPRI()
        {
            PRI pri = new PRI();
            pri.PRICEINFORMATION_01 = new C509();
            pri.PRICEINFORMATION_01.Pricequalifier_01 = PriceQualifier;
            pri.PRICEINFORMATION_01.Price_02 = Price?.ToString("G29");
            pri.PRICEINFORMATION_01.Unitpricebasis_05 = UnitPriceBasis;
            pri.PRICEINFORMATION_01.Measureunitqualifier_06 = PriceMeasureUnitQualifier;
            return pri;
        }

        public RFF generateComfirmPurchaseRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = PurchaseReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = PurchaseReferenceNumber;
            rff.REFERENCE_01.Linenumber_03 = PurchaseLineNumber;

            return rff;
        }

        public DTM generateComfirmPurchaseDTM()
        {
            DTM dtm = new DTM();
            dtm.DATETIMEPERIOD_01 = new C507();
            dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = PurchaseDateQualifier ?? "171";
            if (PurchaseDate != null)
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = PurchaseDate.ToString("yyyyMMdd");
            dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = PurchaseDateFormat ?? "102";
            return dtm;
        }

        public SCC generateConfirmSCC()
        {
            SCC scc = new SCC();
            scc.Deliveryplanstatusindicatorcoded_01 = DeliveryPlanStatusIndicatorCode;
            return scc;
        }

        public QTY generateConfirmSccQTY()
        {
            QTY qty = new QTY();
            qty.QUANTITYDETAILS_01 = new C186();
            qty.QUANTITYDETAILS_01.Quantityqualifier_01 = ScheduleQuantityQualifier;
            qty.QUANTITYDETAILS_01.Quantity_02 = ScheduleItemQuantity.Value.ToString();
            qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = ScheduleQTYMeasureUnitQualifier;

            return qty;
        }
        public QTY generateCommittedQTY()
        {
            QTY qty = new QTY();
            qty.QUANTITYDETAILS_01 = new C186();
            qty.QUANTITYDETAILS_01.Quantityqualifier_01 = CommittedQuantityQualifier;
            qty.QUANTITYDETAILS_01.Quantity_02 = CommittedItemQuantity.Value.ToString();
            qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = CommittedQTYMeasureUnitQualifier;

            return qty;
        }

        #endregion
        public override void Configure(EntityTypeBuilder<LineItemOrderConfirmation> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }

    }
}
