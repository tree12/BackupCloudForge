using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Interfaces;
using EdiFabric.Core.Model.Edi;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities
{
    public class EdiOrder : EdiOrderBase<EdiOrder>, IDocumentReference
    {


        #region Invoicee
        public string Invoicee_PartyQualifier { get; set; }
        public string Invoicee_PartyId { get; set; }

        public string Invoicee_ResponsibleAgency { get; set; }
        #endregion
        public List<LineItemOrder> LineItems { get; set; }
        public EdiOrder() : base()
        {
        }

        public void init(TSORDERS tsorder)
        {
            base.init(tsorder.BGM);
            base.init(tsorder.UNH);
            if (tsorder.FTX != null)
                base.init(tsorder.FTX);
            base.init(tsorder.UNT);
            //ReferenceDate= tsorder.DTM.
            if (tsorder.CUXLoop != null)
            {
                if (tsorder.CUXLoop.Count > 1) AddEdiConvertError("More than one Currency found!");
                base.initCurrency(tsorder.CUXLoop.FirstOrDefault()?.CUX);
                //CurrencyDetailsQualifier = tsorder.CUXLoop.FirstOrDefault()?.CUX?.CURRENCYDETAILS_01?.Currencydetailsqualifier_01;
                //Currency = tsorder.CUXLoop.FirstOrDefault()?.CUX?.CURRENCYDETAILS_01?.Currencycoded_02;
                //CurrencyQualifier = tsorder.CUXLoop.FirstOrDefault()?.CUX?.CURRENCYDETAILS_01?.Currencyqualifier_03;
            }



            var purchaseRef = tsorder.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON");
            if (purchaseRef != null)
            {
                initRFF(purchaseRef.RFF);
                var refDate = purchaseRef.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "171");
                if (refDate != null && refDate.DATETIMEPERIOD_01 != null)
                    initRefDate(refDate);
            }
            var docDate = tsorder.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "137");
            if (docDate != null)
                base.initDocDate(docDate);


            if (tsorder.PATLoop != null && tsorder.PATLoop.Count > 0 && tsorder.PATLoop[0] != null)
            {
                base.initPat1(tsorder.PATLoop[0].PAT);
                base.initPcd1(tsorder.PATLoop[0].PCD);
            }

            if (tsorder.PATLoop != null && tsorder.PATLoop.Count > 1 && tsorder.PATLoop[1] != null)
            {
                base.initPat2(tsorder.PATLoop[1].PAT);
                base.initPcd2(tsorder.PATLoop[1].PCD);
            }

            if (tsorder.PATLoop != null && tsorder.PATLoop.Count > 2 && tsorder.PATLoop[2] != null)
            {
                base.initPat3(tsorder.PATLoop[2].PAT);
                base.initPcd3(tsorder.PATLoop[2].PCD);
            }
            if (tsorder.PATLoop != null && tsorder.PATLoop.Count > 3 && tsorder.PATLoop[3] != null)
            {
                AddEdiConvertError("We found more than 3 Payment-Terms");
            }

            if (tsorder.TODLoop != null && tsorder.TODLoop.Count > 0 && tsorder.TODLoop[0] != null)
            {
                base.initTOD1(tsorder.TODLoop[0].TOD);
                if (tsorder.TODLoop[0].LOC != null)
                {
                    if (tsorder.TODLoop[0].LOC.Any())
                    {
                        base.initConditionLOC1(tsorder.TODLoop[0].LOC?.FirstOrDefault());

                    }
                }
            }

            if (tsorder.TODLoop != null && tsorder.TODLoop.Count > 1)
            {
                AddEdiConvertError("We found more than one Delivery-Terms");
            }


            List<string> VALID_NAD_QUALIFIERS = new List<string>() { "BY", "SU", "DP", "IV" };   //TODO-use constants for checking!
            if (tsorder.NADLoop.Any(nad => !VALID_NAD_QUALIFIERS.Contains(nad.NAD.Partyqualifier_01.ToUpper())))
            {
                AddEdiConvertError($"Found Partys with codes we can not process yet: {string.Join(",", tsorder.NADLoop.Where(nad => !VALID_NAD_QUALIFIERS.Contains(nad.NAD.Partyqualifier_01.ToUpper())))}");
            }


            Loop_NAD_ORDERS getParty(string partyQualifier)
            {
                var nadWhere = tsorder.NADLoop.Where(nad => nad.NAD.Partyqualifier_01.EqualsIgnoreCase(partyQualifier));
                if (nadWhere.Count() > 1) AddEdiConvertError($"Found more than one Party with Code {partyQualifier}");
                return nadWhere.FirstOrDefault();
            }
            Loop_NAD_ORDERS partyBuyer = getParty("BY");
            if (partyBuyer != null)
            {
                base.initNADBY(partyBuyer.NAD);
                this.initCTABY(partyBuyer.CTALoop?.FirstOrDefault()?.CTA);
                this.initContactBY(partyBuyer.CTALoop?.FirstOrDefault()?.COM);
                if (partyBuyer.CTALoop.Count > 1) AddEdiConvertError("We found more than one Contact for the Buyer!");
            }

            Loop_NAD_ORDERS partySupplier = getParty("SU");
            if (tsorder.NADLoop[1] != null)
            {
                base.initNADSU(partySupplier.NAD);
                //base.initCTASU(partySupplier.CTALoop?.FirstOrDefault()?.CTA);
                //base.initContactSU(partySupplier.CTALoop?.FirstOrDefault()?.COM);
            }

            Loop_NAD_ORDERS partyDelivery = getParty("DP");
            if (partyDelivery != null)
            {
                base.initNADDP(partyDelivery.NAD);
                this.DPLoc(partyDelivery.LOC?.FirstOrDefault());
                if (partyDelivery.LOC.Count > 1) AddEdiConvertError("We found more than 1 Delivery Location");

            }
            Loop_NAD_ORDERS partyInvoicee = getParty("IV");
            if (partyInvoicee != null) {
                Invoicee_PartyQualifier = partyInvoicee.NAD?.Partyqualifier_01;
                Invoicee_PartyId = partyInvoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
                Invoicee_ResponsibleAgency = partyInvoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            }
            if (tsorder.LINLoop != null)
                LineItems = GenerateLineItems(tsorder.LINLoop);
            else
            {
                AddEdiConvertError("Line items for order is empty.");
            }

        }
        public void init(TSORDCHG tsorderchg)
        {
            base.init(tsorderchg.BGM);
            base.init(tsorderchg.UNH);
            if (tsorderchg.FTX != null)
                base.init(tsorderchg.FTX);
            base.init(tsorderchg.UNT);
            if (tsorderchg.CUXLoop != null)
            {
                if (tsorderchg.CUXLoop.Count > 1) AddEdiConvertError("More than one Currency found!");
                base.initCurrency(tsorderchg.CUXLoop.FirstOrDefault()?.CUX);
                //CurrencyDetailsQualifier = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencydetailsqualifier_01;
                //Currency = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencycoded_02;
                //CurrencyQualifier = tsorderchg.CUXLoop[0]?.CUX?.CURRENCYDETAILS_01?.Currencyqualifier_03;
            }

            //ReferenceQualifier = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencequalifier_01;
            //ReferenceNumber = tsorderchg.RFFLoop[0].RFF.REFERENCE_01.Referencenumber_02;
            //if (tsorderchg.RFFLoop[0]?.DTM[0]?.DATETIMEPERIOD_01 != null)
            //    ReferenceDate = tsorderchg.RFFLoop[0].DTM[0].DATETIMEPERIOD_01.asDateTime();
            //DocumentDate = tsorderchg.DTM[0].DATETIMEPERIOD_01.asDateTime();


            var purchaseRef = tsorderchg.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON");
            if (purchaseRef != null)
            {
                initRFF(purchaseRef.RFF);
                var refDate = purchaseRef.DTM?.FirstOrDefault(x => x.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 == "171");
                if (refDate != null && refDate.DATETIMEPERIOD_01 != null)
                    initRefDate(refDate);
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


            Loop_NAD_ORDCHG partyInvoicee = getParty("IV");
            if (partyInvoicee != null)
            {
                Invoicee_PartyQualifier = partyInvoicee.NAD?.Partyqualifier_01;
                Invoicee_PartyId = partyInvoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
                Invoicee_ResponsibleAgency = partyInvoicee.NAD?.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;

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
        public List<LineItemOrder> GenerateLineItems(List<Loop_LIN_ORDERS> linOrders)
        {
            List<LineItemOrder> lineItems = new List<LineItemOrder>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemOrder();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }
            }

            return lineItems;
        }
        private List<LineItemOrder> GenerateLineItems(List<Loop_LIN_ORDCHG> linOrders)
        {
            List<LineItemOrder> lineItems = new List<LineItemOrder>();
            if (linOrders.Any())
            {
                foreach (var lin in linOrders)
                {
                    var lineItem = new LineItemOrder();
                    lineItem.init(lin);
                    lineItems.Add(lineItem);
                }

            }
            return lineItems;
        }

        public override EdiMessage CreateEdiDocument()
        {
            if (TypeIdentifier == "ORDERS")
            {
                var result = new TSORDERS();
                result.UNH = base.generateUNH();
                result.BGM = base.generateBGM();

                result.DTM = new List<DTM>();
                result.DTM.Add(base.generateDocumentDTM());

                var ftxs = base.generateFTX();
                if (ftxs != null && ftxs.Any())
                {
                    ftxs.ForEach(ftx => {
                        ftx.Textfunctioncoded_02 = "1";
                    });
                    result.FTX = ftxs;
                }

                result.RFFLoop = new List<Loop_RFF_ORDERS>();
                var rffLoop = new Loop_RFF_ORDERS();

                rffLoop.RFF =generateRFF();
                var docDtm = generateReferenceDTM();
                if (docDtm != null)
                {
                    rffLoop.DTM = new List<DTM>();
                    rffLoop.DTM.Add(docDtm);
                }

                result.RFFLoop.Add(rffLoop);
                result.NADLoop = new List<Loop_NAD_ORDERS>();

                #region Buyer
                var nadLoopBY = new Loop_NAD_ORDERS();
                nadLoopBY.NAD = base.generateBuyer();
                nadLoopBY.CTALoop = new List<Loop_CTA_ORDERS>();
                var ctaLoopBY = new Loop_CTA_ORDERS();
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
                var nadLoopSU = new Loop_NAD_ORDERS();
                nadLoopSU.NAD = base.generateSupplier();
                result.NADLoop.Add(nadLoopSU);

                #endregion

                #region Delivery
                var nadLoopDP = new Loop_NAD_ORDERS();
                nadLoopDP.NAD = base.generateDelivery();
                var deLoc = base.generateDeliveryLOC();
                if (deLoc != null)
                {
                    nadLoopDP.LOC = new List<LOC>();
                    nadLoopDP.LOC.Add(deLoc);
                }
                result.NADLoop.Add(nadLoopDP);
                #endregion

                #region Invoicee
                var nadLoopIV = new Loop_NAD_ORDERS();
                nadLoopIV.NAD = this.generateInvoicee();
                result.NADLoop.Add(nadLoopIV);
                #endregion


                result.CUXLoop = new List<Loop_CUX_ORDERS>();
                var cuxLoop = new Loop_CUX_ORDERS();
                cuxLoop.CUX = base.generateCurrency();
                result.CUXLoop.Add(cuxLoop);

                #region Payment Term

                if (!string.IsNullOrEmpty(PaymentTerm1_TypeQualifier))
                {
                    result.PATLoop = new List<Loop_PAT_ORDERS>();
                    var patLoop = new Loop_PAT_ORDERS();
                    patLoop.PAT = base.generatePayment1();
                    patLoop.PCD = base.generatePercentage1();
                    result.PATLoop.Add(patLoop);
                }

                if (!string.IsNullOrEmpty(PaymentTerm2_TypeQualifier))
                {
                    var patLoop2 = new Loop_PAT_ORDERS();
                    patLoop2.PAT = base.generatePayment2();
                    patLoop2.PCD = base.generatePercentage2();
                    result.PATLoop.Add(patLoop2);
                }

                if (!string.IsNullOrEmpty(PaymentTerm3_TypeQualifier))
                {
                    var patLoop3 = new Loop_PAT_ORDERS();
                    patLoop3.PAT = base.generatePayment3();
                    patLoop3.PCD = base.generatePercentage3();
                    result.PATLoop.Add(patLoop3);
                }

                #endregion

                #region DeliveryOrTransport Term
                result.TODLoop = new List<Loop_TOD_ORDERS>();
                var todLoop = new Loop_TOD_ORDERS();
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
                result.LINLoop = new List<Loop_LIN_ORDERS>();
                
                foreach (var lineItem in LineItems)
                {
                    var linLoop1 = new Loop_LIN_ORDERS();
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
                    var qty = lineItem.generateQTY();
                    if (qty != null)
                    {
                        linLoop1.QTY = new List<QTY>();
                        linLoop1.QTY.Add(qty);
                    }

                    linLoop1.FTX = new List<FTX>();
                    linLoop1.FTX.Add(lineItem.generateOrderFTX());

                    linLoop1.PRILoop = new List<Loop_PRI_ORDERS>();
                    var priLoop = new Loop_PRI_ORDERS();
                    priLoop.PRI = lineItem.generateOrderPRI();
                    linLoop1.PRILoop.Add(priLoop);


                    linLoop1.SCCLoop = new List<Loop_SCC_ORDERS>();
                    var loopScc = new Loop_SCC_ORDERS();
                    loopScc.SCC = lineItem.generateOrderSCC();
                    loopScc.QTYLoop = new List<Loop_QTY_ORDERS>();
                    var loopQty = new Loop_QTY_ORDERS();
                    loopQty.QTY = lineItem.generateOrderSccQTY();

                    loopQty.DTM = new List<DTM>();
                    loopQty.DTM.Add(lineItem.generateDeliveryDTM());
                    loopScc.QTYLoop.Add(loopQty);
                    linLoop1.SCCLoop.Add(loopScc);

                    result.LINLoop.Add(linLoop1);
                }
                #endregion
                result.UNS = base.generateUNS();
                //result.UNT = base.generateUNT();

                return result;
            }
            else if (TypeIdentifier == "ORDCHG")
            {
                var result = new TSORDCHG();
                result.UNH = base.generateUNH();
                result.BGM = base.generateBGM();

                result.DTM = new List<DTM>();
                result.DTM.Add(base.generateDocumentDTM());

                var ftxs = base.generateFTX();
                if (ftxs != null && ftxs.Any())
                {
                    ftxs.ForEach(ftx => {
                        ftx.Textfunctioncoded_02 = "1";
                    });
                    result.FTX = ftxs;
                }

                result.RFFLoop = new List<Loop_RFF_ORDCHG>();
                var rffLoop = new Loop_RFF_ORDCHG();

                rffLoop.RFF = generateRFF();
                rffLoop.DTM = new List<DTM>();
                rffLoop.DTM.Add(generateReferenceDTM());

                result.RFFLoop.Add(rffLoop);
                result.NADLoop = new List<Loop_NAD_ORDCHG>();

                #region Buyer
                var nadLoopBY = new Loop_NAD_ORDCHG();
                nadLoopBY.NAD = base.generateBuyer();
                nadLoopBY.CTALoop = new List<Loop_CTA_ORDCHG>();
                var ctaLoopBY = new Loop_CTA_ORDCHG();
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
                var nadLoopSU = new Loop_NAD_ORDCHG();
                nadLoopSU.NAD = base.generateSupplier();
                result.NADLoop.Add(nadLoopSU);

                #endregion

                #region Delivery
                var nadLoopDP = new Loop_NAD_ORDCHG();
                nadLoopDP.NAD = base.generateDelivery();
                var deLoc = base.generateDeliveryLOC();
                if (deLoc != null)
                {
                    nadLoopDP.LOC = new List<LOC>();
                    nadLoopDP.LOC.Add(deLoc);
                }
                result.NADLoop.Add(nadLoopDP);
                #endregion

                #region Invoicee
                var nadLoopIV = new Loop_NAD_ORDCHG();
                nadLoopIV.NAD = this.generateInvoicee();
                result.NADLoop.Add(nadLoopIV);
                #endregion

                result.CUXLoop = new List<Loop_CUX_ORDCHG>();
                var cuxLoop = new Loop_CUX_ORDCHG();
                cuxLoop.CUX = base.generateCurrency();
                result.CUXLoop.Add(cuxLoop);

                #region Payment Term

                if (!string.IsNullOrEmpty(PaymentTerm1_TypeQualifier))
                {
                    result.PATLoop = new List<Loop_PAT_ORDCHG>();
                    var patLoop = new Loop_PAT_ORDCHG();
                    patLoop.PAT = base.generatePayment1();
                    patLoop.PCD = base.generatePercentage1();
                    result.PATLoop.Add(patLoop);
                }

                if (!string.IsNullOrEmpty(PaymentTerm2_TypeQualifier))
                {
                    var patLoop2 = new Loop_PAT_ORDCHG();
                    patLoop2.PAT = base.generatePayment2();
                    patLoop2.PCD = base.generatePercentage2();
                    result.PATLoop.Add(patLoop2);
                }

                if (!string.IsNullOrEmpty(PaymentTerm3_TypeQualifier))
                {
                    var patLoop3 = new Loop_PAT_ORDCHG();
                    patLoop3.PAT = base.generatePayment3();
                    patLoop3.PCD = base.generatePercentage3();
                    result.PATLoop.Add(patLoop3);
                }

                #endregion

                #region DeliveryOrTransport Term
                result.TODLoop = new List<Loop_TOD_ORDCHG>();
                var todLoop = new Loop_TOD_ORDCHG();
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
                result.LINLoop = new List<Loop_LIN_ORDCHG>();
                var linLoop1 = new Loop_LIN_ORDCHG();
                foreach (var lineItem in LineItems)
                {
                    linLoop1.LIN = lineItem.generateLIN();
                    linLoop1.LIN.Actionrequestnotificationcoded_02 = lineItem.ActionRequestCoded;

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
                    var qty = lineItem.generateQTY();
                    if (qty != null)
                    {
                        linLoop1.QTY = new List<QTY>();
                        linLoop1.QTY.Add(qty);
                    }

                    linLoop1.FTX = new List<FTX>();
                    linLoop1.FTX.Add(lineItem.generateOrderFTX());

                    linLoop1.PRILoop = new List<Loop_PRI_ORDCHG>();
                    var priLoop = new Loop_PRI_ORDCHG();
                    priLoop.PRI = lineItem.generateOrderPRI();
                    linLoop1.PRILoop.Add(priLoop);


                    linLoop1.SCCLoop = new List<Loop_SCC_ORDCHG>();
                    var loopScc = new Loop_SCC_ORDCHG();
                    loopScc.SCC = lineItem.generateOrderSCC();
                    loopScc.QTYLoop = new List<Loop_QTY_ORDCHG>();
                    var loopQty = new Loop_QTY_ORDCHG();
                    loopQty.QTY = lineItem.generateOrderSccQTY();

                    loopQty.DTM = new List<DTM>();
                    loopQty.DTM.Add(lineItem.generateDeliveryDTM());
                    loopScc.QTYLoop.Add(loopQty);
                    linLoop1.SCCLoop.Add(loopScc);

                    result.LINLoop.Add(linLoop1);
                }
                #endregion
                result.UNS = base.generateUNS();
                //result.UNT = base.generateUNT();
                return result;
            }
            else
                throw new EdiException("Document type not match.");
        

        }

        public string ReferenceQualifier { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? ReferenceDate { get; set; }
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
        public RFF generateRFF()
        {
            if (!string.IsNullOrEmpty(ReferenceQualifier))
            {
                RFF rff = new RFF();
                rff.REFERENCE_01 = new C506();
                rff.REFERENCE_01.Referencequalifier_01 = ReferenceQualifier;
                rff.REFERENCE_01.Referencenumber_02 = ReferenceNumber;
                return rff;
            }

            return null;
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
        private NAD generateInvoicee()
        {
            if (!string.IsNullOrEmpty(Invoicee_PartyQualifier))
            {
                NAD nad = new NAD();
                nad.Partyqualifier_01 = Invoicee_PartyQualifier;
                nad.PARTYIDENTIFICATIONDETAILS_02 = new C082();
                nad.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01 = Invoicee_PartyId;
                nad.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03 = Invoicee_ResponsibleAgency;
                return nad;
            }

            return null;
        }
    }
}