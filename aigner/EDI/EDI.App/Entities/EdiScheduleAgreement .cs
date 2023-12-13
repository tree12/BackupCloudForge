using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class EdiScheduleAgreement: EdiMasterMessage
    {
        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0050 8 RFF M 1 1 Reference
        /// C506 Reference M
        /// 1153 Reference qualifier M an..3 
        ///
        /// AIF Previous delivery instruction number
        /// </summary>
        public string PreviousDeliveryReferenceQualifier { get; set; }
        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0050 8 RFF M 1 1 Reference
        /// C506 Reference M
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string PreviousDeliveryReferenceNumber { get; set; }

        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0050 8 RFF M 1 1 Reference
        ///
        /// </summary>
        public DateTime PreviousDeliveryReferenceDate { get; set; }
        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0050 10 RFF M 1 1 Reference
        /// C506 Reference M
        /// 1153 Reference qualifier M an..3 
        ///
        /// AAN Delivery schedule number
        /// </summary>
        public string CurrentDeliveryReferenceQualifier { get; set; }

        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0050 10 RFF M 1 1 Reference
        /// C506 Reference M
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string CurrentDeliveryReferenceNumber { get; set; }

        /// <summary>
        /// 0040 SG1 C 10 1 RFF-DTM - 0060 11 DTM C 1 2 Date/time/period
        /// </summary>
        public DateTime CurrentDeliveryReferenceDate { get; set; }
        /// <summary>
        /// 0110 SG2 C 99 1 NAD-SG5
        /// </summary>
        public NameAndAddress Buyer { get; set; }
        /// <summary>
        ///  0110 SG2 C 99 1 NAD
        /// </summary>
        public NameAndAddress Supplier { get; set; }
        /// <summary>
        ///  0140 SG4 C 500 1 NAD-LOC-SG8 - 0150 18 NAD M 1 1 Name and address
        /// </summary>
        public NameAndAddress Recipient { get; set; }
        /// <summary>
        /// 0270 SG8 C 9999 2 LIN-PIA-IMD-SG10-SG12
        /// 0280 20 LIN M 1 2 Line item
        /// </summary>
        public List<LineItem> LineItems { get; set; }

        public void init(TSDELFOR tsdelfor)
        {
            base.init(tsdelfor.BGM);
            base.init(tsdelfor.UNH);
            base.init(tsdelfor.UNT);

            DocumentDate = tsdelfor.DTM[0].DATETIMEPERIOD_01.asDateTime();
            ReferenceQualifier = tsdelfor.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            ReferenceNumber = tsdelfor.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            ReferenceDate = tsdelfor.RFFLoop[0].DTM.DATETIMEPERIOD_01.asDateTime();
            
            PreviousDeliveryReferenceQualifier = tsdelfor.RFFLoop[1].RFF.REFERENCE_01.Referencequalifier_01;
            PreviousDeliveryReferenceNumber = tsdelfor.RFFLoop[1].RFF.REFERENCE_01.Referencenumber_02;
            PreviousDeliveryReferenceDate = tsdelfor.RFFLoop[1].DTM.DATETIMEPERIOD_01.asDateTime();

            CurrentDeliveryReferenceQualifier = tsdelfor.RFFLoop[2].RFF.REFERENCE_01.Referencequalifier_01;
            CurrentDeliveryReferenceNumber = tsdelfor.RFFLoop[2].RFF.REFERENCE_01.Referencenumber_02;
            CurrentDeliveryReferenceDate = tsdelfor.RFFLoop[2].DTM.DATETIMEPERIOD_01.asDateTime();

            Buyer = GenerateNameAndAddress(tsdelfor.NADLoop[0]);
            Supplier = GenerateNameAndAddress(tsdelfor.NADLoop[1]);
            Recipient = GenerateNameAndAddress(tsdelfor.NADLoop2[0]);

            LineItems = GenerateLineItems(tsdelfor.NADLoop2[0].LINLoop);

        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_DELFOR linDelfors)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(linDelfors);
            return nameAndAddress;
        }
        private NameAndAddress GenerateNameAndAddress(Loop_NAD_DELFOR_2 linDelfors)
        {
            var nameAndAddress = new NameAndAddress();
            nameAndAddress.init(linDelfors);
            return nameAndAddress;
        }
        private List<LineItem> GenerateLineItems(List<Loop_LIN_DELFOR> linDelfors)
        {
            List<LineItem> lineItems = new List<LineItem>();
            if (linDelfors.Any())
            {
                foreach (var lin in linDelfors)
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
