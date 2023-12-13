using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class EdiOrderChange : EdiOrder
    {
        public void init(TSORDCHG tsorderchg)
        {
            base.init(tsorderchg.BGM);
            base.init(tsorderchg.UNH);
            base.init(tsorderchg.FTX[0]);
            base.init(tsorderchg.UNT);
            Currency = tsorderchg.CUXLoop.First().CUX.CURRENCYDETAILS_01.Currencycoded_02;
            Buyer = GenerateNameAndAddress(tsorderchg.NADLoop[0]);
            Supplier = GenerateNameAndAddress(tsorderchg.NADLoop[1]);
            DeliveryRecipient = GenerateNameAndAddress(tsorderchg.NADLoop[2]);
            PaymentTerm = GeneratePaymentTerm(tsorderchg.PATLoop[0]);
            DeliveryOrTransportTerm = GenerateDeliveryOrTransportTerm(tsorderchg.TODLoop[0]);
            LineItems = GenerateLineItems(tsorderchg.LINLoop);


            ReferenceQualifier = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReferenceNumber = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReferenceDate = tsorderchg.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            DocumentDate = tsorderchg.DTM[0].DATETIMEPERIOD_01.asDateTime();

        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_ORDCHG nadOrders)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(nadOrders);
            return nameAndAddress;
        }
        private PaymentTerm GeneratePaymentTerm(Loop_PAT_ORDCHG patOrders)
        {
            var paymentTerm = new PaymentTerm();
            paymentTerm.init(patOrders);
            return paymentTerm;
        }
        private DeliveryOrTransportTerm GenerateDeliveryOrTransportTerm(Loop_TOD_ORDCHG todOrders)
        {
            var paymentTerm = new DeliveryOrTransportTerm();
            paymentTerm.init(todOrders);
            return paymentTerm;
        }
        private List<LineItem> GenerateLineItems(List<Loop_LIN_ORDCHG> linOrders)
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
