using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EdiFabric.Templates.EancomD01B;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class DeliveryOrTransportTerm
    {
        /// <summary>
        /// 0430 19 TOD M 1 1 Terms of delivery or transport - 4055 Terms of delivery or transport function, coded C an..3
        ///
        /// 5 Transport condition
        /// </summary>
        public string FunctionCode { get; set; }
        /// <summary>
        /// 0430 19 TOD M 1 1 Terms of delivery or transport - 4053 Terms of delivery or transport,coded C an..3
        ///
        /// Incoterms will be used
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 0420 SG11 C 5 1 TOD-LOC
        /// </summary>
        public PlaceLocation Location { get; set; }

        public void init(Loop_TOD_ORDERS todOrders)
        {
            FunctionCode = todOrders.TOD.Termsofdeliveryortransportfunctioncoded_01;
            Code = todOrders.TOD.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01;
            if (todOrders.LOC.Any())
            {
                Location = new PlaceLocation();
                Location.init(todOrders.LOC.FirstOrDefault());
            }
        }
        public void init(Loop_TOD_INVOIC todInvoices)
        {
            FunctionCode = todInvoices.TOD.Termsofdeliveryortransportfunctioncoded_01;
            Code = todInvoices.TOD.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01;
            if (todInvoices.LOC.Any())
            {
                Location = new PlaceLocation();
                Location.init(todInvoices.LOC.FirstOrDefault());
            }
        }

        public void init(Loop_TOD_ORDCHG todOrders)
        {
            FunctionCode = todOrders.TOD.Termsofdeliveryortransportfunctioncoded_01;
            Code = todOrders.TOD.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01;
            if (todOrders.LOC.Any())
            {
                Location = new PlaceLocation();
                Location.init(todOrders.LOC.FirstOrDefault());
            }
        }
        public void init(Loop_TOD_ORDRSP todOrdrsps)
        {
            FunctionCode = todOrdrsps.TOD.Termsofdeliveryortransportfunctioncoded_01;
            Code = todOrdrsps.TOD.TERMSOFDELIVERYORTRANSPORT_03.Termsofdeliveryortransportcoded_01;
            if (todOrdrsps.LOC.Any())
            {
                Location = new PlaceLocation();
                Location.init(todOrdrsps.LOC.FirstOrDefault());
            }
        }
    }
}
