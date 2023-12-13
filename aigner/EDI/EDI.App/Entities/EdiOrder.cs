using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class EdiOrder : EdiMasterMessage
    {
        /// <summary>
        /// 0110 SG2 C 99 1 NAD-SG5
        /// </summary>
        public NameAndAddress Buyer { get; set; }

        /// <summary>
        ///  0110 SG2 C 99 1 NAD
        /// </summary>
        public NameAndAddress Supplier { get; set; }

        /// <summary>
        ///  0110 SG2 C 99 1 NAD-LOC
        /// </summary>
        public NameAndAddress DeliveryRecipient { get; set; }
        /// <summary>
        /// 0280 SG7 C 5 1 CUX
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 0320 SG8 C 10 1 PAT-PCD
        /// </summary>
        public PaymentTerm PaymentTerm { get; set; }
        /// <summary>
        /// 0420 SG11 C 5 1 TOD-LOC
        /// </summary>
        public DeliveryOrTransportTerm DeliveryOrTransportTerm { get; set; }
        /// <summary>
        /// 0930 SG25 C 200000 1 LIN-PIA-IMD-QTY-FTX-SG28-SG49
        /// </summary>
        public List<LineItem> LineItems { get; set; }


        public void init(TSORDERS tsorder)
        {
            base.init(tsorder.BGM);
            base.init(tsorder.UNH);
            base.init(tsorder?.FTX[0]);
            base.init(tsorder.UNT);
            //ReferenceDate= tsorder.DTM.
            Currency = tsorder.CUXLoop.First().CUX.CURRENCYDETAILS_01.Currencycoded_02;
            Buyer = GenerateNameAndAddress(tsorder.NADLoop[0]);
            Supplier = GenerateNameAndAddress(tsorder.NADLoop[1]);
            DeliveryRecipient = GenerateNameAndAddress(tsorder.NADLoop[2]);
            PaymentTerm = GeneratePaymentTerm(tsorder.PATLoop[0]);
            DeliveryOrTransportTerm = GenerateDeliveryOrTransportTerm(tsorder.TODLoop[0]);
            LineItems = GenerateLineItems(tsorder.LINLoop);


            ReferenceQualifier = tsorder.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReferenceNumber = tsorder.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReferenceDate = tsorder.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            DocumentDate = tsorder.DTM[0].DATETIMEPERIOD_01.asDateTime();

        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_ORDERS nadOrders)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(nadOrders);
            return nameAndAddress;
        }
        private PaymentTerm GeneratePaymentTerm(Loop_PAT_ORDERS patOrders)
        {
            var paymentTerm = new PaymentTerm();
            paymentTerm.init(patOrders);
            return paymentTerm;
        }
        private DeliveryOrTransportTerm GenerateDeliveryOrTransportTerm(Loop_TOD_ORDERS todOrders)
        {
            var paymentTerm = new DeliveryOrTransportTerm();
            paymentTerm.init(todOrders);
            return paymentTerm;
        }
        private List<LineItem> GenerateLineItems(List<Loop_LIN_ORDERS> linOrders)
        {
            List <LineItem> lineItems =new List<LineItem>();
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
