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
    public class LineItemSchedule : LineItemBase<LineItemSchedule>
    {

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
        public DateTime? ReceivedDeliveryReferenceDate { get; set; }

        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string ReceivedQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public int? ReceivedItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string ReceivedQTYMeasureUnitQualifier { get; set; }

        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string BackorderedQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public int? BackorderedItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string BackorderedQTYMeasureUnitQualifier { get; set; }

        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string ScheduledQuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public int? ScheduledItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string ScheduledQTYMeasureUnitQualifier { get; set; }

        /// <summary>
        /// 1920 SG49 C 100 2 SCC-SG50 -1930 27 SCC M 1 2 Scheduling conditions
        /// 4017 Delivery plan status indicator, coded
        /// 1 Firm Planned quantity - is always 1.
        /// </summary>
        public string DeliveryPlanStatusIndicatorCode { get; set; }
        /// <summary>
        /// 0470 SG12 C 200 3 QTY-SCC-DTM -0490 29 SCC C 1 4 Scheduling conditions
        /// 4493 Delivery requirements, coded C an..3 C an..3
        /// 
        /// </summary>
        public string DeliveryRequirementsCode { get; set; }
        /// <summary>
        /// 0470 SG12 C 200 3 QTY-SCC-DTM -0490 29 SCC C 1 4 Scheduling conditions
        /// 2013 Frequency, coded C an..3 C an..3
        /// 
        /// </summary>
        public string FrequencyCode { get; set; }
        /// <summary>
        /// 0470 SG12 C 200 3 QTY-SCC-DTM - 0500 31 DTM D 2 4 Date/time/period
        /// C507 Date/time/period M 
        /// 2005 Date/time/period qualifier M an..3 
        /// </summary>
        public DateTime? EarliestDate { get; set; }
        /// <summary>
        /// 0470 SG12 C 200 3 QTY-SCC-DTM - 0500 31 DTM D 2 4 Date/time/period
        /// C507 Date/time/period M 
        /// 2005 Date/time/period qualifier M an..3 
        /// </summary>
        public DateTime? LatestDate { get; set; }


        public void init(Loop_LIN_DELFOR linDelfors)
        {
            base.initLIN(linDelfors.LIN);
            base.initPIA(linDelfors.PIA);
            base.initIMD(linDelfors.IMD);

            var quantity = linDelfors.QTYLoop.FirstOrDefault(x => x.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01 == "194");
            var receivedQuantity = linDelfors.QTYLoop.FirstOrDefault(x => x.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01 == "70");
            var backorderedQuantity = linDelfors.QTYLoop.FirstOrDefault(x => x.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01 == "83");
            var scheduledQuantity = linDelfors.QTYLoop.FirstOrDefault(x => x.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01 == "113");

            base.initQTY(quantity?.QTY);

            ReceivedDeliveryReferenceQualifier = linDelfors.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReceivedDeliveryReferenceNumber = linDelfors.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReceivedDeliveryReferenceDate = linDelfors.RFFLoop[0].DTM.DATETIMEPERIOD_01.asDateTime();


            if (receivedQuantity?.QTY != null)
            {
                ReceivedQuantityQualifier = receivedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(receivedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02))
                    ReceivedItemQuantity = int.Parse(receivedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02);
                ReceivedQTYMeasureUnitQualifier = receivedQuantity?.QTY?.QUANTITYDETAILS_01?.Measureunitqualifier_03;
            }

            if (backorderedQuantity?.QTY != null)
            {
                BackorderedQuantityQualifier = backorderedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(backorderedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02))
                    BackorderedItemQuantity = int.Parse(backorderedQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02);
                BackorderedQTYMeasureUnitQualifier = backorderedQuantity?.QTY?.QUANTITYDETAILS_01?.Measureunitqualifier_03;
            }

            if (scheduledQuantity?.QTY != null)
            {
                ScheduledQuantityQualifier = scheduledQuantity?.QTY?.QUANTITYDETAILS_01?.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(scheduledQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02))
                    ScheduledItemQuantity = int.Parse(scheduledQuantity?.QTY?.QUANTITYDETAILS_01?.Quantity_02);
                ScheduledQTYMeasureUnitQualifier = scheduledQuantity?.QTY?.QUANTITYDETAILS_01?.Measureunitqualifier_03;
            }
            //ScheduleCondition = GenerateScheduleCondition(linDelfors.QTYLoop[3]);
            if (scheduledQuantity != null)
            {
                DeliveryPlanStatusIndicatorCode = scheduledQuantity.SCC?.Deliveryplanstatusindicatorcoded_01;
                DeliveryRequirementsCode = scheduledQuantity.SCC?.Deliveryrequirementscoded_02;
                FrequencyCode = scheduledQuantity.SCC?.PATTERNDESCRIPTION_03?.Frequencycoded_01;
                DTM deliveryDtm = scheduledQuantity.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "2");
                DTM earliestDtm = scheduledQuantity.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "64");
                DTM latestDtm = scheduledQuantity.DTM.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "63");
                if (deliveryDtm != null)//DeliveryDate = deliveryDtm.DATETIMEPERIOD_01?.asDateTime();
                    base.initDeliveryDTM(deliveryDtm);
                if (earliestDtm != null)
                    EarliestDate = earliestDtm?.DATETIMEPERIOD_01?.asDateTime();
                if (latestDtm != null)
                    LatestDate = latestDtm?.DATETIMEPERIOD_01?.asDateTime();
            }

        }

        public RFF ReceivedDeliveryRff()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = ReceivedDeliveryReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = ReceivedDeliveryReferenceNumber;
            return rff;
        }

        public DTM ReceivedDeliveryDTM()
        {
            if (ReceivedDeliveryReferenceDate != null)
            {
                DTM dtm = new DTM();
                dtm.DATETIMEPERIOD_01 = new C507();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = ReceivedDeliveryReferenceDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return dtm;
            }

            return null;

        }

        public QTY ReceivedQuantity()
        {
            if (ReceivedQuantityQualifier != null)
            {
                QTY qty = new QTY();
                qty.QUANTITYDETAILS_01 = new C186();
                qty.QUANTITYDETAILS_01.Quantityqualifier_01 = ReceivedQuantityQualifier;
                if (ReceivedItemQuantity != null)
                    qty.QUANTITYDETAILS_01.Quantity_02 = ReceivedItemQuantity.Value.ToString();
                qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = ReceivedQTYMeasureUnitQualifier;

                return qty;
            }

            return null;

        }
        public QTY BackorderedQuantity()
        {
            if (BackorderedQuantityQualifier != null)
            {
                QTY qty = new QTY();
                qty.QUANTITYDETAILS_01 = new C186();
                qty.QUANTITYDETAILS_01.Quantityqualifier_01 = BackorderedQuantityQualifier;
                if (BackorderedItemQuantity != null)
                    qty.QUANTITYDETAILS_01.Quantity_02 = BackorderedItemQuantity.Value.ToString();
                qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = BackorderedQTYMeasureUnitQualifier;

                return qty;
            }

            return null;
        }
        public QTY ScheduledQuantity()
        {
            if (ScheduledQuantityQualifier != null)
            {
                QTY qty = new QTY();
                qty.QUANTITYDETAILS_01 = new C186();
                qty.QUANTITYDETAILS_01.Quantityqualifier_01 = ScheduledQuantityQualifier;
                if (ScheduledItemQuantity != null)
                    qty.QUANTITYDETAILS_01.Quantity_02 = ScheduledItemQuantity.Value.ToString();
                qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = ScheduledQTYMeasureUnitQualifier;

                return qty;
            }

            return null;

        }

        public SCC LineSchedulingConditions()
        {
            if (!string.IsNullOrEmpty(DeliveryPlanStatusIndicatorCode))
            {
                SCC scc = new SCC();
                scc.Deliveryplanstatusindicatorcoded_01 = DeliveryPlanStatusIndicatorCode;
                scc.Deliveryrequirementscoded_02 = DeliveryRequirementsCode;
                scc.PATTERNDESCRIPTION_03 = new C329();
                scc.PATTERNDESCRIPTION_03.Frequencycoded_01 = FrequencyCode;
                return scc;
            }

            return null;
        }
        public DTM EarliestDTM()
        {
            if (EarliestDate != null)
            {
                DTM dtm = new DTM();
                dtm.DATETIMEPERIOD_01 = new C507();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "64";
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = EarliestDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";

                return dtm;
            }

            return null;
        }
        public DTM LatestDTM()
        {
            if (LatestDate != null)
            {
                DTM dtm = new DTM();
                dtm.DATETIMEPERIOD_01 = new C507();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "63";
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = LatestDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";

                return dtm;
            }

            return null;
        }
        public override void Configure(EntityTypeBuilder<LineItemSchedule> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }

    }
}
