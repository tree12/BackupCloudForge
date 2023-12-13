using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities
{
    public class EdiScheduleAgreement : EdiMasterMessage<EdiScheduleAgreement>, IDeliveryLocation, IBuyerContact, IDocumentReference, IBuyer, ICurrency
    {
        public EdiScheduleAgreement()
        {
        }
        public string ReferenceQualifier { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
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
        public DateTime? PreviousDeliveryReferenceDate { get; set; }
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
        public DateTime? CurrentDeliveryReferenceDate { get; set; }

        #region Buyer
        public string Buyer_PartyQualifier { get; set; }
        public string Buyer_PartyId { get; set; }

        public string Buyer_ResponsibleAgency { get; set; }

        public string Buyer_ContactCode { get; set; }

        public string Buyer_Name { get; set; }

        public string Buyer_Email { get; set; }

        public string Buyer_Phone { get; set; }
        #endregion

        #region Delivery
        #region Location

        public string Delivery_PlaceLocationQualifier { get; set; }

        public string Delivery_PlaceLocationIdentification { get; set; }

        #endregion
        #endregion

        #region Currency

        public string CurrencyDetailsQualifier { get; set; }
        public string Currency { get; set; }
        public string CurrencyQualifier { get; set; }
        #endregion


        public List<LineItemSchedule> LineItems { get; set; }

        public void init(TSDELFOR tsdelfor)
        {
            base.init(tsdelfor.BGM);
            base.init(tsdelfor.UNH);
            base.init(tsdelfor.UNT);

            //DocumentDate = tsdelfor.DTM[0].DATETIMEPERIOD_01.asDateTime();
            //var reference = tsdelfor.RFFLoop.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01.EqualsIgnoreCase("ON"));
            //if (reference != null)
            //{
            //    ReferenceQualifier = tsdelfor.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            //    ReferenceNumber = tsdelfor.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            //    ReferenceDate = tsdelfor.RFFLoop[0].DTM.DATETIMEPERIOD_01.asDateTime();
            //}
            var purchaseRef = tsdelfor.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON");
            if (purchaseRef != null)
            {
                initRFF(purchaseRef.RFF);
                if (purchaseRef.DTM != null && purchaseRef.DTM.DATETIMEPERIOD_01 != null)
                    initRefDate(purchaseRef.DTM);
            }
            var docDate = tsdelfor.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137");

            if (docDate != null)
                base.initDocDate(docDate);
            var previousReference = tsdelfor.RFFLoop.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01.EqualsIgnoreCase("AIF"));
            if (previousReference != null)
            {
                PreviousDeliveryReferenceQualifier = tsdelfor.RFFLoop[1].RFF.REFERENCE_01.Referencequalifier_01;
                PreviousDeliveryReferenceNumber = tsdelfor.RFFLoop[1].RFF.REFERENCE_01.Referencenumber_02;
                PreviousDeliveryReferenceDate = tsdelfor.RFFLoop[1].DTM.DATETIMEPERIOD_01.asDateTime();
            }

            var currentReference = tsdelfor.RFFLoop.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01.EqualsIgnoreCase("AAN"));
            if (currentReference != null)
            {
                CurrentDeliveryReferenceQualifier = tsdelfor.RFFLoop[2].RFF.REFERENCE_01.Referencequalifier_01;
                CurrentDeliveryReferenceNumber = tsdelfor.RFFLoop[2].RFF.REFERENCE_01.Referencenumber_02;
                CurrentDeliveryReferenceDate = tsdelfor.RFFLoop[2].DTM.DATETIMEPERIOD_01.asDateTime();
            }



            GetBuyer(tsdelfor.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "BY"));
            GetSeller(tsdelfor.NADLoop.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "SE"));
            GetDelivery(tsdelfor.NADLoop2.FirstOrDefault(x => x.NAD.Partyqualifier_01 == "DP"));

            if (tsdelfor.NADLoop2.FirstOrDefault() != null)
                LineItems = GenerateLineItems(tsdelfor.NADLoop2.FirstOrDefault().LINLoop);
            else
            {
                AddEdiConvertError("Line items for Scheduling agreement is empty.");
            }

        }

        public void initCurrency(CUX cux)
        {
            CurrencyDetailsQualifier = cux.CURRENCYDETAILS_01.Currencydetailsqualifier_01;
            Currency = cux.CURRENCYDETAILS_01.Currencycoded_02;
            CurrencyQualifier = cux.CURRENCYDETAILS_01.Currencyqualifier_03;
        }

        private List<LineItemSchedule> GenerateLineItems(List<Loop_LIN_DELFOR> linDelfors)
        {
            List<LineItemSchedule> lineItems = new List<LineItemSchedule>();
            if (linDelfors.Any())
            {
                foreach (var lin in linDelfors)
                {
                    var lineItem = new LineItemSchedule();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }
        private void GetDelivery(Loop_NAD_DELFOR_2 nadTsdelfor)
        {
            if (nadTsdelfor != null)
            {
                base.initNADDP(nadTsdelfor.NAD);
                this.DPLoc(nadTsdelfor.LOC.FirstOrDefault());
            }


        }
        private void GetBuyer(Loop_NAD_DELFOR nadTsdelfor)
        {
            if (nadTsdelfor != null)
            {

                initNADBY(nadTsdelfor.NAD);
                this.initCTABY(nadTsdelfor.CTALoop?.FirstOrDefault()?.CTA);
                this.initContactBY(nadTsdelfor.CTALoop?.FirstOrDefault()?.COM);
            }

        }
        private void GetSeller(Loop_NAD_DELFOR nadTsdelfor)
        {
            if (nadTsdelfor != null)
            {
                /*At this point we use Suplier for Seller in case DELFOR because DELFOR not use Suplier at this moment.*/
                base.initNADSU(nadTsdelfor.NAD);

            }


        }

        public void initCTABY(CTA cta)
        {
            Buyer_ContactCode = cta?.Contactfunctioncoded_01;
            Buyer_Name = cta?.DEPARTMENTOREMPLOYEEDETAILS_02?.Departmentoremployee_02;
        }

        public void initContactBY(List<COM> coms)
        {
            Buyer_Email = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
            Buyer_Phone = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
        }

        public void DPLoc(LOC loc)
        {
            Delivery_PlaceLocationQualifier = loc?.Placelocationqualifier_01;
            Delivery_PlaceLocationIdentification = loc?.LOCATIONIDENTIFICATION_02?.Placelocationidentification_01;
        }

        public LOC generateDeliveryLOC()
        {
            if (!string.IsNullOrEmpty(Delivery_PlaceLocationQualifier))
            {
                LOC deliveryRecipientLoc = new LOC();
                deliveryRecipientLoc.Placelocationqualifier_01 = Delivery_PlaceLocationQualifier; //.DeliveryRecipient.Location.PlaceLocationQualifier;
                deliveryRecipientLoc.LOCATIONIDENTIFICATION_02 = new C517();
                deliveryRecipientLoc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01 = Delivery_PlaceLocationIdentification;
                return deliveryRecipientLoc;
            }

            return null;

        }

        public CTA generateBuyerCTA()
        {
            CTA cta = new CTA();
            cta.Contactfunctioncoded_01 = Buyer_ContactCode;
            cta.DEPARTMENTOREMPLOYEEDETAILS_02 = new C056();
            cta.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02 = Buyer_Name;
            return cta;
        }

        public COM generateBuyerPhone()
        {
            if (!string.IsNullOrEmpty(Buyer_Phone))
            {
                var comPhone = new COM();
                comPhone.COMMUNICATIONCONTACT_01 = new C076();
                comPhone.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Buyer_Phone;
                comPhone.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "TE";
                return comPhone;
            }

            return null;
        }

        public COM generateBuyerEmail()
        {
            if (!string.IsNullOrEmpty(Buyer_Email))
            {
                var comEmail = new COM();
                comEmail.COMMUNICATIONCONTACT_01 = new C076();
                comEmail.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Buyer_Email;
                comEmail.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "EM";
                return comEmail;
            }

            return null;
        }

        public override EdiMessage CreateEdiDocument()
        {
            var result = new TSDELFOR();
            result.UNH = base.generateUNH();
            result.BGM = base.generateBGM();

            result.DTM = new List<DTM>();
            result.DTM.Add(base.generateDocumentDTM());

            //result.FTX = new List<FTX>();
            //result.FTX.Add(base.generateIMD());

            result.RFFLoop = new List<Loop_RFF_DELFOR>();

            var rffLoop = new Loop_RFF_DELFOR();
            rffLoop.RFF = generateRFF();
            var refDtm = generateReferenceDTM();
            if (refDtm != null)
                rffLoop.DTM = refDtm;

            result.RFFLoop.Add(rffLoop);

            var previousRffLoop = new Loop_RFF_DELFOR();
            previousRffLoop.RFF = generatePreviousRFF();
            var previousRffDtm = generatePreviousReferenceDTM();
            if (previousRffDtm != null)
                previousRffLoop.DTM = previousRffDtm;

            result.RFFLoop.Add(previousRffLoop);

            var currentRffLoop = new Loop_RFF_DELFOR();
            currentRffLoop.RFF = generateCurrentRFF();
            var currentRffDtm = generateCurrentReferenceDTM();
            if (currentRffDtm != null)
                currentRffLoop.DTM = currentRffDtm;
            result.RFFLoop.Add(currentRffLoop);

            result.NADLoop = new List<Loop_NAD_DELFOR>();

            #region Buyer
            var nadLoopBY = new Loop_NAD_DELFOR();
            nadLoopBY.NAD = generateBuyer();
            nadLoopBY.CTALoop = new List<Loop_CTA_DELFOR>();
            var ctaLoopBY = new Loop_CTA_DELFOR();
            ctaLoopBY.CTA = generateBuyerCTA();

            var comEmail = generateBuyerEmail();
            var comPhone = generateBuyerPhone();
            if (comEmail != null || comPhone != null)
            {
                ctaLoopBY.COM = new List<COM>();
                if (comEmail != null)
                    ctaLoopBY.COM.Add(comEmail);
                if (comPhone != null)
                    ctaLoopBY.COM.Add(comPhone);
            }
            nadLoopBY.CTALoop.Add(ctaLoopBY);
            result.NADLoop.Add(nadLoopBY);
            #endregion

            #region Supplier
            var nadLoopSU = new Loop_NAD_DELFOR();
            nadLoopSU.NAD = base.generateSupplier();
            result.NADLoop.Add(nadLoopSU);

            #endregion

            #region Delivery
            result.NADLoop2 = new List<Loop_NAD_DELFOR_2>();
            var nadLoopDP = new Loop_NAD_DELFOR_2();
            nadLoopDP.NAD = base.generateDelivery();
            var deliveryNad = generateDeliveryLOC();
            if (deliveryNad != null)
            {
                nadLoopDP.LOC = new List<LOC>();
                nadLoopDP.LOC.Add(deliveryNad);
            }

            #region Line Item
            result.LINLoop = new List<Loop_LIN_DELFOR_2>();
            nadLoopDP.LINLoop = new List<Loop_LIN_DELFOR>();
            var linLoop1 = new Loop_LIN_DELFOR();
            foreach (var lineItem in LineItems)
            {
                linLoop1.LIN = lineItem.generateLIN();
                var pia = lineItem.generatePIA();
                if (pia != null)
                {
                    linLoop1.PIA = new List<PIA>();
                    linLoop1.PIA.Add(pia);
                }
                var imd = lineItem.generateIMD();
                if (imd != null)
                {
                    linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                    linLoop1.IMD.Add(imd);
                }
                //TODO:: In the new specification delfor-d.96a-ktm_1_1.pdf has FTX but not implement yet.(it is optional)
                linLoop1.RFFLoop = new List<Loop_RFF_DELFOR>();
                Loop_RFF_DELFOR receivedRff = new Loop_RFF_DELFOR();
                receivedRff.RFF = lineItem.ReceivedDeliveryRff();
                receivedRff.DTM = lineItem.ReceivedDeliveryDTM();
                linLoop1.RFFLoop.Add(receivedRff);

                linLoop1.QTYLoop = new List<Loop_QTY_DELFOR>();

                var qty = lineItem.generateQTY();
                var receivedQty = lineItem.ReceivedQuantity();
                var backorderedQty = lineItem.BackorderedQuantity();

                if (qty != null)
                {
                    Loop_QTY_DELFOR quantity = new Loop_QTY_DELFOR();
                    quantity.QTY = qty;
                    linLoop1.QTYLoop.Add(quantity);
                }

                if (receivedQty != null)
                {
                    Loop_QTY_DELFOR receivedQuantity = new Loop_QTY_DELFOR();
                    receivedQuantity.QTY = receivedQty;
                    linLoop1.QTYLoop.Add(receivedQuantity);
                }

                if (backorderedQty != null)
                {
                    Loop_QTY_DELFOR backorderedQuantity = new Loop_QTY_DELFOR();
                    backorderedQuantity.QTY = backorderedQty;
                    linLoop1.QTYLoop.Add(backorderedQuantity);
                }

                Loop_QTY_DELFOR scheduledQuantityQuantity = new Loop_QTY_DELFOR();
                scheduledQuantityQuantity.QTY = lineItem.ScheduledQuantity();

                scheduledQuantityQuantity.SCC = lineItem.LineSchedulingConditions();

                var deliveryDtm = lineItem.generateDeliveryDTM();
                var earliestDtm = lineItem.EarliestDTM();
                var latestDtm = lineItem.LatestDTM();
                if (deliveryDtm != null || earliestDtm != null || latestDtm != null)
                {
                    scheduledQuantityQuantity.DTM = new List<DTM>();
                    if (deliveryDtm != null)
                        scheduledQuantityQuantity.DTM.Add(deliveryDtm);
                    if (earliestDtm != null)
                        scheduledQuantityQuantity.DTM.Add(earliestDtm);
                    if (latestDtm != null)
                        scheduledQuantityQuantity.DTM.Add(latestDtm);
                }

                linLoop1.QTYLoop.Add(scheduledQuantityQuantity);

                nadLoopDP.LINLoop.Add(linLoop1);
            }
            #endregion
            result.NADLoop2.Add(nadLoopDP);

            #endregion


            result.UNS = new UNS() { Sectionidentification_01 = "D" };
            result.UNS2 = base.generateUNS();
            //result.UNT = base.generateUNT();

            return result;
        }
        private RFF generatePreviousRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = PreviousDeliveryReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = PreviousDeliveryReferenceNumber;
            return rff;
        }
        private DTM generatePreviousReferenceDTM()
        {
            if (PreviousDeliveryReferenceDate != null)
            {
                var rffDtm1 = new DTM();
                rffDtm1.DATETIMEPERIOD_01 = new C507();
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiod_02 = PreviousDeliveryReferenceDate.Value.ToString("yyyyMMdd");
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return rffDtm1;
            }

            return null;

        }
        private RFF generateCurrentRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = CurrentDeliveryReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = CurrentDeliveryReferenceNumber;
            return rff;
        }
        private DTM generateCurrentReferenceDTM()
        {
            if (CurrentDeliveryReferenceDate != null)
            {
                var rffDtm1 = new DTM();
                rffDtm1.DATETIMEPERIOD_01 = new C507();
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiod_02 = CurrentDeliveryReferenceDate.Value.ToString("yyyyMMdd");
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return rffDtm1;
            }

            return null;

        }

        public RFF generateRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = ReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = ReferenceNumber;
            return rff;
        }

        public DTM generateReferenceDTM()
        {

            if (ReferenceDate != null)
            {
                var rffDtm1 = new DTM();
                rffDtm1.DATETIMEPERIOD_01 = new C507();
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiod_02 = ReferenceDate.Value.ToString("yyyyMMdd");
                rffDtm1.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return rffDtm1;
            }

            return null;

        }

        public void initRFF(RFF reff)
        {
            ReferenceQualifier = reff?.REFERENCE_01?.Referencequalifier_01;
            ReferenceNumber = reff?.REFERENCE_01?.Referencenumber_02;
        }
        public void initRefDate(DTM dtm)
        {
            if (dtm != null)
                ReferenceDate = dtm.DATETIMEPERIOD_01.asDateTime();
        }

        public NAD generateBuyer()
        {
            NAD nad = new NAD();
            nad.Partyqualifier_01 = Buyer_PartyQualifier;
            nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
            nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Buyer_PartyId;
            nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Buyer_ResponsibleAgency;
            return nad;
        }
        #region InitBuyer
        public void initNADBY(NAD nad)
        {
            Buyer_PartyQualifier = nad?.Partyqualifier_01;
            Buyer_PartyId = nad?.PARTYIDENTIFICATIONDETAILS_02?.Partyididentification_01;
            Buyer_ResponsibleAgency = nad?.PARTYIDENTIFICATIONDETAILS_02?.Codelistresponsibleagencycoded_03;

        }
        #endregion

        public CUX generateCurrency()
        {
            CUX cux = new CUX();
            cux.CURRENCYDETAILS_01 = new C504();
            cux.CURRENCYDETAILS_01.Currencydetailsqualifier_01 = CurrencyDetailsQualifier;
            cux.CURRENCYDETAILS_01.Currencycoded_02 = Currency;
            cux.CURRENCYDETAILS_01.Currencyqualifier_03 = CurrencyQualifier;
            return cux;
        }
    }
}
