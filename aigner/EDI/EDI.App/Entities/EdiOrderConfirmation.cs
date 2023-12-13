using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    class EdiOrderConfirmation : EdiOrder
    {
        public void init(TSORDRSP tsordrsp)
        {
            base.init(tsordrsp.BGM);
            base.init(tsordrsp.UNH);
            //base.init(tsordrsp.FTX[0]);
            base.init(tsordrsp.UNT);
            Currency = tsordrsp.CUXLoop.First().CUX.CURRENCYDETAILS_01.Currencycoded_02;
            Buyer = GenerateNameAndAddress(tsordrsp.NADLoop[0]);
            Supplier = GenerateNameAndAddress(tsordrsp.NADLoop[1]);
            DeliveryRecipient = GenerateNameAndAddress(tsordrsp.NADLoop[2]);
            PaymentTerm = GeneratePaymentTerm(tsordrsp.PATLoop[0]);
            DeliveryOrTransportTerm = GenerateDeliveryOrTransportTerm(tsordrsp.TODLoop[0]);
            LineItems = GenerateLineItems(tsordrsp.LINLoop);


            //ReferenceQualifier = tsordrsp.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            //ReferenceNumber = tsordrsp.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            //ReferenceDate = tsordrsp.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            DocumentDate = tsordrsp.DTM[0].DATETIMEPERIOD_01.asDateTime();

        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_ORDRSP nadOrders)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(nadOrders);
            return nameAndAddress;
        }
        private PaymentTerm GeneratePaymentTerm(Loop_PAT_ORDRSP patOrders)
        {
            var paymentTerm = new PaymentTerm();
            paymentTerm.init(patOrders);
            return paymentTerm;
        }
        private DeliveryOrTransportTerm GenerateDeliveryOrTransportTerm(Loop_TOD_ORDRSP todOrders)
        {
            var paymentTerm = new DeliveryOrTransportTerm();
            paymentTerm.init(todOrders);
            return paymentTerm;
        }
        private List<LineItem> GenerateLineItems(List<Loop_LIN_ORDRSP> linOrders)
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
