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
    public class LineItemOrder : LineItemBase<LineItemOrder>
    {
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
        public string FreeTextLineItem { get; set; }

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

        /// <summary>
        /// 1920 SG49 C 100 2 SCC-SG50 -1930 27 SCC M 1 2 Scheduling conditions
        /// 4017 Delivery plan status indicator, coded
        /// 1 Firm Planned quantity - is always 1.
        /// </summary>
        //public string DeliveryPlanStatusIndicatorCode2 { get; set; }

        ///// <summary>
        ///// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        /////
        ///// 21 Ordered quantity
        ///// </summary>
        //public string ScheduleQuantityQualifier2 { get; set; }
        ///// <summary>
        ///// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        /////
        ///// </summary>
        //public int? ScheduleItemQuantity2 { get; set; }
        ///// <summary>
        ///// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        /////
        ///// Code specifying the unit of measurement, use UN/ECE
        ///// Recommendation 20, Common code.
        /////     PCE Piece
        /////     MTR Metre*
        /////     KGM Kilogram*
        ///// </summary>
        //public string ScheduleQTYMeasureUnitQualifier2 { get; set; }
        ///// <summary>
        ///// 1960 SG50 C 10 3 QTY-DTM
        ///// 1980 29 DTM C 5 4 Date/time/period
        /////
        ///// </summary>
        //public DateTime? DeliveryDate2 { get; set; }

        public void init(Loop_LIN_ORDERS linOrders)
        {
            initLIN(linOrders.LIN);
            initPIA(linOrders.PIA);
            initIMD(linOrders.IMD);
            if (linOrders.QTY.Count > 1)
                AddEdiConvertError("Order Quantity more than 1");
            initQTY(linOrders.QTY.FirstOrDefault());


            if (linOrders.FTX != null && linOrders.FTX.Any())
            {
                //TextSubjectQualifier = linOrders.FTX[0]?.Textsubjectqualifier_01;
                //TextFunctionCode = linOrders.FTX[0]?.Textfunctioncoded_02;
                //FreeTextLineItem = linOrders.FTX[0].TEXTLITERAL_04.Freetext_01;
                assignFTXToOrder(linOrders.FTX[0]);
            }
            assignPRIToOrder(linOrders.PRILoop[0]?.PRI);
            //PriceQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            //if (!string.IsNullOrEmpty(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02))
            //    Price = decimal.Parse(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02);
            //UnitPriceBasis = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            //PriceMeasureUnitQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;

            if (linOrders.SCCLoop[0] != null)
            {
                DeliveryPlanStatusIndicatorCode = linOrders.SCCLoop[0].SCC.Deliveryplanstatusindicatorcoded_01;
                //DeliveryDate = linOrders.SCCLoop[0].QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
                base.initDeliveryDTM(linOrders.SCCLoop[0].QTYLoop[0]?.DTM[0]);

                if (linOrders.SCCLoop[0].QTYLoop[0]?.QTY != null)
                {
                    ScheduleQuantityQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantityqualifier_01;
                    if (!string.IsNullOrEmpty(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02))
                        ScheduleItemQuantity = int.Parse(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02);
                    ScheduleQTYMeasureUnitQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Measureunitqualifier_03;
                }
            }
            //if (linOrders.SCCLoop.Count> 1 && linOrders.SCCLoop[1] != null)
            //{
            //    DeliveryPlanStatusIndicatorCode2 = linOrders.SCCLoop[1].SCC.Deliveryplanstatusindicatorcoded_01;
            //    DeliveryDate2 = linOrders.SCCLoop[1].QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();

            //    if (linOrders.SCCLoop[1].QTYLoop[0]?.QTY != null)
            //    {
            //        ScheduleQuantityQualifier2 = linOrders.SCCLoop[1].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantityqualifier_01;
            //        if (!string.IsNullOrEmpty(linOrders.SCCLoop[1].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02))
            //            ScheduleItemQuantity2 = int.Parse(linOrders.SCCLoop[1].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02);
            //        ScheduleQTYMeasureUnitQualifier2 = linOrders.SCCLoop[1].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Measureunitqualifier_03;
            //    }
            //}

            if (linOrders.SCCLoop.Count > 1 && linOrders.SCCLoop[1] != null)
            {
                AddEdiConvertError("We found ScheduleInformations more than 2");
            }
        }
        public void init(Loop_LIN_ORDCHG linOrders)
        {
            base.initLIN(linOrders.LIN);
            base.initPIA(linOrders.PIA);
            base.initIMD(linOrders.IMD);
            if (linOrders.QTY.Count > 1)
                AddEdiConvertError("Order Quantity more than 1");
            initQTY(linOrders.QTY.FirstOrDefault());

            ActionRequestCoded = linOrders.LIN?.Actionrequestnotificationcoded_02;
            if (linOrders.FTX != null && linOrders.FTX.Any())
            {
                //TextSubjectQualifier = linOrders.FTX[0]?.Textsubjectqualifier_01;
                //TextFunctionCode = linOrders.FTX[0]?.Textfunctioncoded_02;
                //FreeTextLineItem = linOrders.FTX[0].TEXTLITERAL_04.Freetext_01;
                assignFTXToOrder(linOrders.FTX[0] );
            }
            assignPRIToOrder(linOrders.PRILoop[0]?.PRI);
            //PriceQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            //if (!string.IsNullOrEmpty(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01?.Price_02))
            //    Price = decimal.Parse(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01?.Price_02);
            //UnitPriceBasis = linOrders.PRILoop[0]?.PRI?.PRICEINFORMATION_01?.Unitpricebasis_05;
            //PriceMeasureUnitQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01?.Measureunitqualifier_06;
            if (linOrders.SCCLoop[0] != null)
            {
                DeliveryPlanStatusIndicatorCode = linOrders.SCCLoop[0].SCC.Deliveryplanstatusindicatorcoded_01;
                //DeliveryDate = linOrders.SCCLoop[0].QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
                base.initDeliveryDTM(linOrders.SCCLoop[0].QTYLoop[0]?.DTM[0]);

                if (linOrders.SCCLoop[0].QTYLoop[0]?.QTY != null)
                {
                    ScheduleQuantityQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantityqualifier_01;
                    if (!string.IsNullOrEmpty(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02))
                        ScheduleItemQuantity = int.Parse(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02);
                    ScheduleQTYMeasureUnitQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Measureunitqualifier_03;
                }
            }
        }

        private void assignFTXToOrder(FTX ftx) {
            if (ftx != null) {
                TextSubjectQualifier = ftx.Textsubjectqualifier_01;
                TextFunctionCode = ftx.Textfunctioncoded_02;
                FreeTextLineItem = ftx.TEXTLITERAL_04.Freetext_01;
            }
           
        }
        private void assignPRIToOrder(PRI pri) {
            
            if (pri != null) {
                PriceQualifier = pri.PRICEINFORMATION_01.Pricequalifier_01;
                if (!string.IsNullOrEmpty(pri.PRICEINFORMATION_01?.Price_02))
                    Price = decimal.Parse(pri.PRICEINFORMATION_01?.Price_02);
                UnitPriceBasis = pri.PRICEINFORMATION_01?.Unitpricebasis_05;
                PriceMeasureUnitQualifier = pri.PRICEINFORMATION_01?.Measureunitqualifier_06;
            }

        }

        #region Generate EDI

        public PRI generateOrderPRI()
        {
            PRI pri = new PRI();
            pri.PRICEINFORMATION_01 = new C509();
            pri.PRICEINFORMATION_01.Pricequalifier_01 = PriceQualifier;
            pri.PRICEINFORMATION_01.Price_02 = Price?.ToString("G29");
            pri.PRICEINFORMATION_01.Unitpricebasis_05 = UnitPriceBasis;
            pri.PRICEINFORMATION_01.Measureunitqualifier_06 = PriceMeasureUnitQualifier;
            return pri;
        }

        public FTX generateOrderFTX()
        {
            if (!string.IsNullOrEmpty(TextSubjectQualifier)) {
                FTX ftx = new FTX();
                ftx.Textsubjectqualifier_01 = TextSubjectQualifier;
                ftx.Textfunctioncoded_02 = TextFunctionCode;
                ftx.TEXTLITERAL_04 = new C108();
                ftx.TEXTLITERAL_04.Freetext_01 = FreeTextLineItem;
                return ftx;
            }
            return null;

        }

        public SCC generateOrderSCC()
        {
            SCC scc = new SCC();
            scc.Deliveryplanstatusindicatorcoded_01 = DeliveryPlanStatusIndicatorCode;
            return scc;
        }
        public QTY generateOrderSccQTY()
        {
            QTY qty = new QTY();
            qty.QUANTITYDETAILS_01 = new C186();
            qty.QUANTITYDETAILS_01.Quantityqualifier_01 = ScheduleQuantityQualifier;
            qty.QUANTITYDETAILS_01.Quantity_02 = ScheduleItemQuantity.Value.ToString();
            qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = ScheduleQTYMeasureUnitQualifier;

            return qty;
        }
        #endregion

        public override void Configure(EntityTypeBuilder<LineItemOrder> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }

    }
}
