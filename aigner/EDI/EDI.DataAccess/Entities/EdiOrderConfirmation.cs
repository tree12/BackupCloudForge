using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities
{
    public class EdiOrderConfirmation : EdiOrderBase<EdiOrderConfirmation>, ISupplierContact, IFreeText
    {
        public string Supplier_ContactCode { get; set; }

        public string Supplier_Name { get; set; }

        public string Supplier_Email { get; set; }

        public string Supplier_Phone { get; set; }

        public int AuftragsId { get; set; }


        public EdiOrderConfirmation()
        {
        }

        public List<LineItemOrderConfirmation> LineItems { get; set; }

        //public void init(TSORDRSP tsordrsp)
        //{
        //    base.init(tsordrsp);
        //    LineItems = GenerateLineItems(tsordrsp.LINLoop);

        //}
        public void init(TSORDRSP tsordrsp)
        {
            base.init(tsordrsp.BGM);
            base.init(tsordrsp.UNH);
            if (tsordrsp.FTX != null)
                base.init(tsordrsp.FTX[0]);
            base.init(tsordrsp.UNT);

            if (tsordrsp.CUXLoop != null)
            {
                if (tsordrsp.CUXLoop.Count > 1) AddEdiConvertError("More than one Currency found!");
                base.initCurrency(tsordrsp.CUXLoop[0]?.CUX);
                //CurrencyDetailsQualifier = tsordrsp.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencydetailsqualifier_01;
                //Currency = tsordrsp.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencycoded_02;
                //CurrencyQualifier = tsordrsp.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencyqualifier_03;
            }

            //var purchaseRef = tsordrsp.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON");
            //if (purchaseRef != null)
            //{
            //    base.initRFF(purchaseRef.RFF);
            //    var refDate = purchaseRef.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "171");
            //    if (refDate != null && refDate.DATETIMEPERIOD_01 != null)
            //        base.initRefDate(refDate);
            //}
            var docDate = tsordrsp.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137");
            if (docDate != null)
                base.initDocDate(docDate);


            if (tsordrsp.PATLoop != null && tsordrsp.PATLoop.Count > 0 && tsordrsp.PATLoop[0] != null)
            {
                base.initPat1(tsordrsp.PATLoop[0].PAT);
                base.initPcd1(tsordrsp.PATLoop[0].PCD);
            }

            if (tsordrsp.PATLoop != null && tsordrsp.PATLoop.Count > 1 && tsordrsp.PATLoop[1] != null)
            {

                base.initPat2(tsordrsp.PATLoop[1].PAT);
                base.initPcd2(tsordrsp.PATLoop[1].PCD);
            }

            if (tsordrsp.PATLoop != null && tsordrsp.PATLoop.Count > 2 && tsordrsp.PATLoop[2] != null)
            {

                base.initPat3(tsordrsp.PATLoop[2].PAT);
                base.initPcd3(tsordrsp.PATLoop[2].PCD);
            }
            if (tsordrsp.PATLoop != null && tsordrsp.PATLoop.Count > 3 && tsordrsp.PATLoop[3] != null)
            {
                AddEdiConvertError("We found more than 3 Payment-Terms");
            }

            if (tsordrsp.TODLoop != null && tsordrsp.TODLoop.Count > 0 && tsordrsp.TODLoop[0] != null)
            {

                base.initTOD1(tsordrsp.TODLoop[0].TOD);
                if (tsordrsp.TODLoop[0].LOC != null)
                {
                    if (tsordrsp.TODLoop[0].LOC.Any())
                    {
                        base.initConditionLOC1(tsordrsp.TODLoop[0].LOC?.FirstOrDefault());

                    }
                }
            }

            if (tsordrsp.TODLoop != null && tsordrsp.TODLoop.Count > 1)
            {
                AddEdiConvertError("We found more than one Delivery-Terms");
            }
            Loop_NAD_ORDRSP partyBuyer = getParty("BY");
            if (partyBuyer != null)
            {

                base.initNADBY(partyBuyer.NAD);
                base.initCTABY(partyBuyer.CTALoop?.FirstOrDefault()?.CTA);
                base.initContactBY(partyBuyer.CTALoop?.FirstOrDefault()?.COM);

            }
            Loop_NAD_ORDRSP partySupplier = getParty("SU");
            if (partySupplier != null)
            {
                base.initNADSU(partySupplier.NAD);
                this.initCTASU(partySupplier.CTALoop?.FirstOrDefault()?.CTA);
                this.initContactSU(partySupplier.CTALoop?.FirstOrDefault()?.COM);
            }
            Loop_NAD_ORDRSP partyDelivery = getParty("DP");
            if (partyDelivery != null)
            {

                base.initNADDP(partyDelivery.NAD);
                this.DPLoc(partyDelivery.LOC.FirstOrDefault());
                if (partyDelivery.LOC.Count > 1) AddEdiConvertError("We found more than 1 Delivery Location");

            }
            Loop_NAD_ORDRSP getParty(string partyQualifier)
            {
                var nadWhere = tsordrsp.NADLoop.Where(nad => nad.NAD.Partyqualifier_01.EqualsIgnoreCase(partyQualifier));
                if (nadWhere.Count() > 1) AddEdiConvertError($"Found more than one Party with Code {partyQualifier}");
                return nadWhere.FirstOrDefault();
            }

            if (tsordrsp.LINLoop != null)
            {
                LineItems = GenerateLineItems(tsordrsp.LINLoop);
                List<IMD> imds = tsordrsp.LINLoop.Select(x => x.IMD.FirstOrDefault()).ToList();
                initIMDs(imds);
            }
            else
            {
                AddEdiConvertError("Line items for Order Confirmation is empty.");
            }
        }

        private List<LineItemOrderConfirmation> GenerateLineItems(List<Loop_LIN_ORDRSP> linOrders)
        {
            List<LineItemOrderConfirmation> lineItems = new List<LineItemOrderConfirmation>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemOrderConfirmation();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }



        public void initCTASU(CTA cta)
        {
            Supplier_ContactCode = cta?.Contactfunctioncoded_01;
            Supplier_Name = cta?.DEPARTMENTOREMPLOYEEDETAILS_02?.Departmentoremployee_02;
        }

        public void initContactSU(List<COM> coms)
        {
            Supplier_Email = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
            Supplier_Phone = coms?.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01?.Communicationnumber_01;
        }
        public void initIMDs(List<IMD> imdList)
        {
            int index = 0;
            foreach (var imd in imdList)
            {
                if (imd != null)
                {
                    ++index;
                    //PropertyInfo qualifier = this.GetType().GetProperty($"Text{index}SubjectQualifier");
                    PropertyInfo freeTextCoded = this.GetType().GetProperty($"Text{index}FreeTextCoded");
                    PropertyInfo text = this.GetType().GetProperty($"Text{index}");
                    //if (qualifier != null)
                    //    qualifier.SetValue(this, ftx.Textsubjectqualifier_01);
                    if (freeTextCoded != null)
                        freeTextCoded.SetValue(this, imd.Itemdescriptiontypecoded_01);
                    if (text != null)
                        text.SetValue(this, imd.ITEMDESCRIPTION_03?.Itemdescription_04 + (!string.IsNullOrEmpty(imd.ITEMDESCRIPTION_03?.Itemdescription_05) ? imd.ITEMDESCRIPTION_03.Itemdescription_05 : ""));
                }


            }
        }

        public List<IMD> generateIMD()
        {
            List<IMD> imdList = new List<IMD>();
            for (int index = 0; index < 12; ++index)
            {
                IMD imd = new IMD();

                // PropertyInfo qualifier = this.GetType().GetProperty($"Text{(index + 1)}SubjectQualifier");
                PropertyInfo freeTextCoded = this.GetType().GetProperty($"Text{(index + 1)}FreeTextCoded");
                PropertyInfo text = this.GetType().GetProperty($"Text{(index + 1)}");
                //if (qualifier != null)
                //    ftx.Textsubjectqualifier_01 = qualifier.GetValue(this)?.ToString();
                if (freeTextCoded != null)
                    imd.Itemdescriptiontypecoded_01 = freeTextCoded.GetValue(this)?.ToString();
                imd.ITEMDESCRIPTION_03 = new C273();
                if (text != null)
                {
                    string descriptions = text.GetValue(this)?.ToString().EscapeForEdi();
                    imd.ITEMDESCRIPTION_03.GenC273FromText(descriptions);
                    //if (!string.IsNullOrEmpty(descriptions) && descriptions.Length > 35)
                    //{
                    //    imd.ITEMDESCRIPTION_03.Itemdescription_04 = descriptions.LimitStringLength(35);
                    //    imd.ITEMDESCRIPTION_03.Itemdescription_05 = descriptions.LimitStringLength(descriptions.Length - 35, 35);
                    //}
                    //else
                    //{
                    //    imd.ITEMDESCRIPTION_03.Itemdescription_04 = descriptions;
                    //}

                }

                if (!string.IsNullOrEmpty(imd.Itemdescriptiontypecoded_01) && !string.IsNullOrEmpty(imd.ITEMDESCRIPTION_03.Itemdescription_04))
                    imdList.Add(imd);

            }

            return imdList;
        }

        public CTA generateSupplierCTA()
        {
            CTA cta = new CTA();
            cta.Contactfunctioncoded_01 = Supplier_ContactCode;
            cta.DEPARTMENTOREMPLOYEEDETAILS_02 = new C056();
            cta.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02 = Supplier_Name;
            return cta;
        }

        public COM generateSupplierPhone()
        {
            var comPhone = new COM();
            comPhone.COMMUNICATIONCONTACT_01 = new C076();
            comPhone.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Supplier_Phone;
            comPhone.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "TE";
            return comPhone;
        }

        public COM generateSupplierEmail()
        {
            var comEmail = new COM();
            comEmail.COMMUNICATIONCONTACT_01 = new C076();
            comEmail.COMMUNICATIONCONTACT_01.Communicationnumber_01 = Supplier_Email;
            comEmail.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02 = "EM";
            return comEmail;
        }

        public override EdiMessage CreateEdiDocument()
        {
            var result = new TSORDRSP();
            result.UNH = base.generateUNH();
            result.BGM = base.generateBGM();

            result.DTM = new List<DTM>();
            result.DTM.Add(base.generateDocumentDTM());

            var ftx = base.generateFTX();
            if (ftx != null)
            {
                result.FTX = new List<FTX>();
                result.FTX.Add(ftx);
            }

            //result.RFFLoop = new List<Loop_RFF_ORDRSP>();
            //var rffLoop = new Loop_RFF_ORDRSP();

            //rffLoop.RFF = base.generateRFF();
            //rffLoop.DTM = new List<DTM>();
            //rffLoop.DTM.Add(base.generateReferenceDTM());

            //result.RFFLoop.Add(rffLoop);

            result.NADLoop = new List<Loop_NAD_ORDRSP>();

            #region Buyer
            var nadLoopBY = new Loop_NAD_ORDRSP();
            nadLoopBY.NAD = base.generateBuyer();
            nadLoopBY.CTALoop = new List<Loop_CTA_ORDRSP>();
            var ctaLoopBY = new Loop_CTA_ORDRSP();
            ctaLoopBY.CTA = base.generateBuyerCTA();

            var buyerEmail = base.generateBuyerEmail();
            var buyerPhone = base.generateBuyerPhone();
            if (buyerEmail != null || buyerPhone != null)
            {
                ctaLoopBY.COM = new List<COM>();
                if (buyerEmail != null)
                    ctaLoopBY.COM.Add(buyerEmail);
                if (buyerPhone != null)
                    ctaLoopBY.COM.Add(buyerPhone);
            }
            nadLoopBY.CTALoop.Add(ctaLoopBY);
            result.NADLoop.Add(nadLoopBY);

            #endregion

            #region Supplier
            var nadLoopSU = new Loop_NAD_ORDRSP();
            nadLoopSU.NAD = base.generateSupplier();
            result.NADLoop.Add(nadLoopSU);

            #endregion

            #region Delivery
            var nadLoopDP = new Loop_NAD_ORDRSP();
            nadLoopDP.NAD = base.generateDelivery();
            var deLoc = base.generateDeliveryLOC();
            if (deLoc != null)
            {
                nadLoopDP.LOC = new List<LOC>();
                nadLoopDP.LOC.Add(deLoc);
            }

            result.NADLoop.Add(nadLoopDP);

            #endregion

            result.CUXLoop = new List<Loop_CUX_ORDRSP>();
            var cuxLoop = new Loop_CUX_ORDRSP();
            cuxLoop.CUX = base.generateCurrency();
            result.CUXLoop.Add(cuxLoop);

            #region Payment Term

            if (!string.IsNullOrEmpty(PaymentTerm1_TypeQualifier))
            {
                result.PATLoop = new List<Loop_PAT_ORDRSP>();
                var patLoop = new Loop_PAT_ORDRSP();
                patLoop.PAT = base.generatePayment1();
                patLoop.PCD = base.generatePercentage1();
                result.PATLoop.Add(patLoop);
            }

            if (!string.IsNullOrEmpty(PaymentTerm2_TypeQualifier))
            {
                var patLoop2 = new Loop_PAT_ORDRSP();
                patLoop2.PAT = base.generatePayment2();
                patLoop2.PCD = base.generatePercentage2();
                result.PATLoop.Add(patLoop2);

            }

            if (!string.IsNullOrEmpty(PaymentTerm3_TypeQualifier))
            {
                var patLoop3 = new Loop_PAT_ORDRSP();
                patLoop3.PAT = base.generatePayment3();
                patLoop3.PCD = base.generatePercentage3();
                result.PATLoop.Add(patLoop3);
            }

            #endregion

            #region DeliveryOrTransport Term
            result.TODLoop = new List<Loop_TOD_ORDRSP>();
            var todLoop = new Loop_TOD_ORDRSP();
            todLoop.TOD = base.generateDeliveryCondition1();
            LOC loc = base.generateDeliveryConditionLocation1();
            if (loc != null)
            {
                todLoop.LOC = new List<LOC>();
                todLoop.LOC.Add(loc);
            }
            result.TODLoop.Add(todLoop);

            #endregion

            #region Line Item
            result.LINLoop = new List<Loop_LIN_ORDRSP>();
           
            List<IMD> imds = generateIMD();
            //int index = 0;
            foreach (var lineItem in LineItems)
            {
                var linLoop1 = new Loop_LIN_ORDRSP();
                linLoop1.LIN = lineItem.generateLIN();
                linLoop1.LIN.Actionrequestnotificationcoded_02 = lineItem.ActionRequestCoded;
                var pia = lineItem.generatePIA();
                if (pia != null)
                {
                    linLoop1.PIA = new List<PIA>();
                    linLoop1.PIA.Add(pia);
                }
                //linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                ////linLoop1.IMD.Add(lineItem.generateIMD());
                //if (index < imds.Count)
                //    linLoop1.IMD.Add(imds[index]);
                //++index;
                var imd = lineItem.generateIMD();
                if (imd != null)
                {
                    linLoop1.IMD = new List<EdiFabric.Templates.EdifactD96A.IMD>();
                    linLoop1.IMD.Add(imd);
                }
                linLoop1.QTY = new List<QTY>();
                var orderQty = lineItem.generateQTY();
                if (orderQty != null)
                {
                    linLoop1.QTY.Add(lineItem.generateQTY());
                }

                //TODO:: Because new specification new more QTY ("66 Committed quantity"). We temporary fixed this solution
                //linLoop1.QTY.Add(new QTY()
                //{
                //    QUANTITYDETAILS_01 = new C186() { Quantityqualifier_01 = "66", Quantity_02 = (lineItem.ItemQuantity != null ? lineItem.ItemQuantity.Value.ToString("G29") : "0"), Measureunitqualifier_03 = lineItem.QTYMeasureUnitQualifier }

                //});
                var commitQty = lineItem.generateCommittedQTY();
                linLoop1.QTY.Add(commitQty);

                linLoop1.PRILoop = new List<Loop_PRI_ORDRSP>();
                var priLoop = new Loop_PRI_ORDRSP();
                priLoop.PRI = lineItem.generateComfirmPRI();
                linLoop1.PRILoop.Add(priLoop);

                linLoop1.RFFLoop = new List<Loop_RFF_ORDRSP>();
                var loopRff = new Loop_RFF_ORDRSP();
                loopRff.RFF = lineItem.generateComfirmPurchaseRFF();
                loopRff.DTM = new List<DTM>();
                loopRff.DTM.Add(lineItem.generateComfirmPurchaseDTM());
                linLoop1.RFFLoop.Add(loopRff);

                linLoop1.SCCLoop = new List<Loop_SCC_ORDRSP>();
                var loopScc = new Loop_SCC_ORDRSP();
                loopScc.SCC = lineItem.generateConfirmSCC();
                loopScc.QTYLoop = new List<Loop_QTY_ORDRSP>();
                var loopQty = new Loop_QTY_ORDRSP();
                //TODO:: Because new specification new more QTY ("66 Committed quantity"). We temporary fixed this solution
                var qty = lineItem.generateConfirmSccQTY();
                qty.QUANTITYDETAILS_01.Quantityqualifier_01 = "66";
                loopQty.QTY = qty;

                loopQty.DTM = new List<DTM>();
                var dtm = lineItem.generateDeliveryDTM();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "55";
                loopQty.DTM.Add(dtm);

                loopScc.QTYLoop.Add(loopQty);
                linLoop1.SCCLoop.Add(loopScc);

                result.LINLoop.Add(linLoop1);
            }


            #endregion

            result.UNS = base.generateUNS(); 
            //result.UNT = base.generateUNT();

            return result;
        }


      
    }
}
