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
    public class LineItemChange : LineItemBase<LineItemChange>
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
        public string FreeText { get; set; }
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


        public void init(Loop_LIN_ORDCHG linOrders)
        {
            base.initLIN(linOrders.LIN);
            base.initPIA(linOrders.PIA);
            base.initIMD(linOrders.IMD);
            if (linOrders.QTY.Count > 1)
                AddEdiConvertError("Order Quantity more than 1");
            initQTY(linOrders.QTY.FirstOrDefault());

            ActionRequestCoded = linOrders.LIN?.Actionrequestnotificationcoded_02;

            TextSubjectQualifier = linOrders.FTX[0]?.Textsubjectqualifier_01;
            TextFunctionCode = linOrders.FTX[0]?.Textfunctioncoded_02;
            FreeText = linOrders.FTX[0].TEXTLITERAL_04.Freetext_01;
            PriceQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Pricequalifier_01;
            if (!string.IsNullOrEmpty(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02))
                Price = decimal.Parse(linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Price_02);
            UnitPriceBasis = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Unitpricebasis_05;
            PriceMeasureUnitQualifier = linOrders.PRILoop[0]?.PRI.PRICEINFORMATION_01.Measureunitqualifier_06;
            // ScheduleCondition = GenerateScheduleCondition(linOrders.SCCLoop[0]);
            if (linOrders.SCCLoop[0] != null)
            {
                DeliveryPlanStatusIndicatorCode = linOrders.SCCLoop[0].SCC.Deliveryplanstatusindicatorcoded_01;
                DeliveryDate = linOrders.SCCLoop[0].QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();

                if (linOrders.SCCLoop[0].QTYLoop[0]?.QTY != null)
                {
                    ScheduleQuantityQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantityqualifier_01;
                    if (!string.IsNullOrEmpty(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02))
                        ScheduleItemQuantity = int.Parse(linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Quantity_02);
                    ScheduleQTYMeasureUnitQualifier = linOrders.SCCLoop[0].QTYLoop[0]?.QTY.QUANTITYDETAILS_01.Measureunitqualifier_03;
                }
            }
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
        public override void Configure(EntityTypeBuilder<LineItemChange> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }

    }
}
