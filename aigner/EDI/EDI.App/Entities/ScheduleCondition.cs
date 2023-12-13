using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class ScheduleCondition
    {
        /// <summary>
        /// 1920 SG49 C 100 2 SCC-SG50 -1930 27 SCC M 1 2 Scheduling conditions
        ///
        /// 1 Firm Planned quantity - is always 1.
        /// </summary>
        public string DeliveryPlanStatusIndicatorCode { get; set; }
        /// <summary>
        /// 1960 SG50 C 10 3 QTY-DTM -1960 SG50 C 10 3 QTY-DTM
        /// </summary>
        public Quantity Quantity { get; set; }

        /// <summary>
        /// 1960 SG50 C 10 3 QTY-DTM
        /// 1980 29 DTM C 5 4 Date/time/period
        ///
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
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

        public void init(Loop_SCC_ORDERS scc)
        {
            DeliveryPlanStatusIndicatorCode = scc.SCC.Deliveryplanstatusindicatorcoded_01;
            DeliveryDate = scc.QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
            Quantity = GenerateQuantity(scc.QTYLoop[0]?.QTY);
        }
        private Quantity GenerateQuantity(QTY qty)
        {
            Quantity quqQuantity = new Quantity();
            if (qty != null)
            {
                quqQuantity.init(qty);
            }
            return quqQuantity;
        }
        public void init(Loop_SCC_ORDCHG scc)
        {
            DeliveryPlanStatusIndicatorCode = scc.SCC.Deliveryplanstatusindicatorcoded_01;
            DeliveryDate = scc.QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
            Quantity = GenerateQuantity(scc.QTYLoop[0]?.QTY);
        }
        public void init(Loop_QTY_DELFOR scc)
        {
            DeliveryPlanStatusIndicatorCode = scc.SCC.Deliveryplanstatusindicatorcoded_01;
            DeliveryDate = scc.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
            EarliestDate = scc.DTM[1]?.DATETIMEPERIOD_01.asDateTime();
            LatestDate = scc.DTM[2]?.DATETIMEPERIOD_01.asDateTime();
            Quantity = GenerateQuantity(scc.QTY);
        }
        public void init(Loop_SCC_ORDRSP scc)
        {
            DeliveryPlanStatusIndicatorCode = scc.SCC.Deliveryplanstatusindicatorcoded_01;
            DeliveryDate = scc.QTYLoop[0]?.DTM[0]?.DATETIMEPERIOD_01.asDateTime();
            Quantity = GenerateQuantity(scc.QTYLoop[0]?.QTY);
        }
    }
}
