using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities
{
    public class EdiOrderChange : EdiOrderBase<EdiOrderChange>
    {
        public EdiOrderChange()
        {
        }
        public List<LineItemChange> LineItems { get; set; }
        //public void init(TSORDCHG tsorderchg)
        //{
        //    base.init(tsorderchg);
        //    LineItems = GenerateLineItems(tsorderchg.LINLoop);
        //}
        public void init(TSORDCHG tsorderchg)
        {
            base.init(tsorderchg.BGM);
            base.init(tsorderchg.UNH);
            if (tsorderchg.FTX != null)
                base.init(tsorderchg.FTX[0]);
            base.init(tsorderchg.UNT);
            if (tsorderchg.CUXLoop != null)
            {
                if (tsorderchg.CUXLoop.Count > 1) AddEdiConvertError("More than one Currency found!");
                CurrencyDetailsQualifier = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencydetailsqualifier_01;
                Currency = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencycoded_02;
                CurrencyQualifier = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencyqualifier_03;
            }

            //ReferenceQualifier = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            //ReferenceNumber = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            //if (tsorderchg.RFFLoop[0]?.DTM[0]?.DATETIMEPERIOD_01 != null)
            //    ReferenceDate = tsorderchg.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            //DocumentDate = tsorderchg.DTM[0].DATETIMEPERIOD_01.asDateTime();


            var purchaseRef = tsorderchg.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON");
            if (purchaseRef != null)
            {
                base.initRFF(purchaseRef.RFF);
                var refDate = purchaseRef.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "171");
                if (refDate != null && refDate.DATETIMEPERIOD_01 != null)
                    base.initRefDate(refDate);
            }
            var docDate = tsorderchg.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137");
            if (docDate != null)
                base.initDocDate(docDate);


            if (tsorderchg.PATLoop != null && tsorderchg.PATLoop.Count > 0 && tsorderchg.PATLoop[0] != null)
            {

                base.initPat1(tsorderchg.PATLoop[0].PAT);
                base.initPcd1(tsorderchg.PATLoop[0].PCD);
            }

            if (tsorderchg.PATLoop != null && tsorderchg.PATLoop.Count > 1 && tsorderchg.PATLoop[1] != null)
            {

                base.initPat2(tsorderchg.PATLoop[1].PAT);
                base.initPcd2(tsorderchg.PATLoop[1].PCD);
            }

            if (tsorderchg.PATLoop != null && tsorderchg.PATLoop.Count > 2 && tsorderchg.PATLoop[2] != null)
            {

                base.initPat3(tsorderchg.PATLoop[2].PAT);
                base.initPcd3(tsorderchg.PATLoop[2].PCD);
            }
            if (tsorderchg.PATLoop != null && tsorderchg.PATLoop.Count > 3 && tsorderchg.PATLoop[3] != null)
            {
                AddEdiConvertError("We found more than 3 Payment-Terms");
            }

            if (tsorderchg.TODLoop != null && tsorderchg.TODLoop.Count > 0 && tsorderchg.TODLoop[0] != null)
            {

                base.initTOD1(tsorderchg.TODLoop[0].TOD);
                if (tsorderchg.TODLoop[0].LOC != null)
                {
                    if (tsorderchg.TODLoop[0].LOC.Any())
                    {
                        base.initConditionLOC1(tsorderchg.TODLoop[0].LOC?.FirstOrDefault());

                    }
                }
            }

      
            if (tsorderchg.TODLoop != null && tsorderchg.TODLoop.Count > 1)
            {
                AddEdiConvertError("We found more than one Delivery-Terms");
            }
            Loop_NAD_ORDCHG partyBuyer = getParty("BY");
            if (partyBuyer != null)
            {
                base.initNADBY(partyBuyer.NAD);
                base.initCTABY(partyBuyer.CTALoop?.FirstOrDefault()?.CTA);
                base.initContactBY(partyBuyer.CTALoop?.FirstOrDefault()?.COM);

            }
            Loop_NAD_ORDCHG partySupplier = getParty("SU");
            if (partySupplier != null)
            {
                base.initNADSU(partySupplier.NAD);

            }
            Loop_NAD_ORDCHG partyDelivery = getParty("DP");
            if (partyDelivery != null)
            {
                base.initNADDP(partyDelivery.NAD);
                this.DPLoc(partyDelivery.LOC?.FirstOrDefault());
                if (partyDelivery.LOC.Count > 1) AddEdiConvertError("We found more than 1 Delivery Location");

            }
            Loop_NAD_ORDCHG getParty(string partyQualifier)
            {
                var nadWhere = tsorderchg.NADLoop.Where(nad => nad.NAD.Partyqualifier_01.EqualsIgnoreCase(partyQualifier));
                if (nadWhere.Count() > 1) AddEdiConvertError($"Found more than one Party with Code {partyQualifier}");
                return nadWhere.FirstOrDefault();
            }
            
            if (tsorderchg.LINLoop != null)
                LineItems = GenerateLineItems(tsorderchg.LINLoop);
            else
            {
                AddEdiConvertError("Line items for order change is empty.");
            }
        }

        private List<LineItemChange> GenerateLineItems(List<Loop_LIN_ORDCHG> linOrders)
        {
            List<LineItemChange> lineItems = new List<LineItemChange>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemChange();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }
    }
}
