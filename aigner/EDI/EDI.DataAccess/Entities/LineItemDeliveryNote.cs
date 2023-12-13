using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities
{
    public class LineItemDeliveryNote : LineItemBase<LineItemDeliveryNote>
    {
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        ///
        /// 0610 42 ALI C 1 3 Additional information - 3239 Country of origin, coded C an..3 M an..3 Refer to International Standard ISO 3166 “ISO ALPHA –2 Country Code” list.
        /// </summary>
        public string CountryOriginCoded { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        ///
        /// 0620 43 GIN O 100 3 Goods identity number - 7405 Identity number qualifier M an..3 M an..3 BN Serial number
        /// </summary>
        public string GoodsIdentityNumberQualifier { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        ///
        /// C208 Identity number range M M - 7402 Identity number M an..35 M an..35
        /// </summary>
        public string GoodsIdentityNumberRange { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        ///
        /// 00630 44 GIR O 100 3 Related identification numbers - 7297 Set identification qualifier M an..3 M an..3
        /// </summary>
        public string RelatedSetIdentificationQualifier { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0630 44 GIR O 100 3 Related identification numbers
        /// C206 Identification number M - 7402 Identity number M an..35 M an..35 
        /// </summary>
        public string RelatedIdentityNumber { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0630 44 GIR O 100 3 Related identification numbers
        /// C206 Identification number M - 7405 Identity number qualifier C an..3 M an..3 BX Batch number
        /// </summary>
        public string RelatedIdentityNumberQualifier { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0650 45 DTM O 1 3 Date/time/period
        /// </summary>
        public DateTime? ManufacturingDate { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0670 46 MOA O 1 3 Monetary amount
        /// C516 Monetary amount M M - 5025 Monetary amount type qualifier M an..3 M an..3
        /// </summary>
        public string MonetaryAmountTypeQualifier { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0670 46 MOA O 1 3 Monetary amount
        /// C516 Monetary amount M M - 5004 Monetary amount C n..18 M n..18
        /// </summary>
        public decimal? MonetaryAmount { get; set; }
        /// <summary>
        /// 0550 SG15 C 9999 2 LIN-PIA-IMD-QTY-ALI-GIN-GIR-DTM-MOA-SG16
        /// 0670 46 MOA O 1 3 Monetary amount
        /// C516 Monetary amount M M - 6345 Currency, coded C an..3 C an..3
        /// </summary>
        public string CurrencyCoded { get; set; }

        #region ON Order number (purchase)
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1153 Reference qualifier M an..3 - ON Order number (purchase)
        /// </summary>
        public string PurchaseReferenceQualifier { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1154 Reference number C an..35 M an..35 
        /// </summary>
        public string PurchaseReferenceNumber { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1156 Line number C an..6 M an..6
        /// </summary>
        public string PurchaseLineNumber { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0700 48 DTM M 1 4 Date/time/period
        /// C507 Date/time/period - 2005 Date/time/period qualifier M an..3 M an..3 171 Reference date/time
        /// </summary>
        public string PurchaseDateQualifier { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0700 48 DTM M 1 4 Date/time/period
        /// C507 Date/time/period - 2380 Date/time/period C an..35 M an..35
        /// </summary>
        public DateTime? PurchaseDate { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0700 48 DTM M 1 4 Date/time/period
        /// C507 Date/time/period M M - 2379 Date/time/period format qualifier C an..3 M an..3 102 CCYYMMDD
        /// </summary>
        public string PurchaseDateFormat { get; set; }

        #endregion
        //TODO:: DeliveryDate(datetime) not use in this lineItemDeliveryNote but it com from LineItemBase. Maybe consider to remove.
        #region AAU Despatch note number
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1153 Reference qualifier M an..3 - ON Order number (purchase)
        /// </summary>
        public string DespatchReferenceQualifier { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1154 Reference number C an..35 M an..35 
        /// </summary>
        public string DespatchReferenceNumber { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0690 47 RFF M 1 3 Reference
        /// C506 Reference M M - 1156 Line number C an..6 M an..6
        /// </summary>
        public string DespatchLineNumber { get; set; }
        /// <summary>
        /// 0680 SG16 M 1 3 RFF-DTM
        /// 0700 48 DTM M 1 4 Date/time/period
        /// C507 Date/time/period M M - 2005 Date/time/period qualifier M an..3 M an..3
        /// </summary>
        public DateTime? DespatchDate { get; set; }

        #endregion

        public void init(Loop_LIN_DESADV linDeliveryNote)
        {
            initLIN(linDeliveryNote.LIN);
            initPIA(linDeliveryNote.PIA);
            initIMD(linDeliveryNote.IMD);
            if (linDeliveryNote.QTY.Count > 1)
                AddEdiConvertError("Order Quantity more than 1");
            initQTY(linDeliveryNote.QTY.FirstOrDefault());
            if (linDeliveryNote.ALI.Count > 1)
                AddEdiConvertError("Additional information more than 1");
            CountryOriginCoded = linDeliveryNote.ALI?.FirstOrDefault()?.Countryoforigincoded_01;
            if (linDeliveryNote.GIN.Count > 1)
                AddEdiConvertError("Goods identity number more than 1");
            GoodsIdentityNumberQualifier = linDeliveryNote.GIN?.FirstOrDefault(x => x.Identitynumberqualifier_01 == "BN")?.Identitynumberqualifier_01;
            GoodsIdentityNumberRange = linDeliveryNote.GIN?.FirstOrDefault(x => x.Identitynumberqualifier_01 == "BN")?.IDENTITYNUMBERRANGE_02?.Identitynumber_01;
            if (linDeliveryNote.GIR.Count > 1)
                AddEdiConvertError("Related identification numbers more than 1");
            RelatedSetIdentificationQualifier = linDeliveryNote.GIR?.FirstOrDefault(x => x.Setidentificationqualifier_01 == "1")?.Setidentificationqualifier_01;
            RelatedIdentityNumber = linDeliveryNote.GIR?.FirstOrDefault(x => x.Setidentificationqualifier_01 == "1")?.IDENTIFICATIONNUMBER_02?.Identitynumber_01;
            RelatedIdentityNumberQualifier = linDeliveryNote.GIR?.FirstOrDefault(x => x.Setidentificationqualifier_01 == "1")?.IDENTIFICATIONNUMBER_02?.Identitynumberqualifier_02;
            ManufacturingDate = linDeliveryNote.DTM[0].DATETIMEPERIOD_01.asDateTime();
            MonetaryAmountTypeQualifier = linDeliveryNote.MOA[0]?.MONETARYAMOUNT_01?.Monetaryamounttypequalifier_01;

            if (!string.IsNullOrEmpty(linDeliveryNote.MOA[0]?.MONETARYAMOUNT_01?.Monetaryamount_02))
                MonetaryAmount = decimal.Parse(linDeliveryNote.MOA[0]?.MONETARYAMOUNT_01?.Monetaryamount_02);

            CurrencyCoded = linDeliveryNote.MOA[0]?.MONETARYAMOUNT_01?.Currencycoded_03;
            PurchaseReferenceQualifier = linDeliveryNote.RFFLoop?.FirstOrDefault(x=>x.RFF.REFERENCE_01.Referencequalifier_01=="ON")?.RFF?.REFERENCE_01?.Referencequalifier_01;
            PurchaseReferenceNumber = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON")?.RFF?.REFERENCE_01?.Referencenumber_02;
            PurchaseLineNumber = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON")?.RFF?.REFERENCE_01?.Linenumber_03;
            PurchaseDateQualifier = linDeliveryNote.RFFLoop
                ?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON")?.DTM?.DATETIMEPERIOD_01
                ?.Datetimeperiodqualifier_01;
            PurchaseDate = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON")?.DTM?.DATETIMEPERIOD_01.asDateTime();
            PurchaseDateFormat = linDeliveryNote.RFFLoop
                ?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "ON")?.DTM?.DATETIMEPERIOD_01
                .Datetimeperiodformatqualifier_03;
            DespatchReferenceQualifier = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "AAU")?.RFF?.REFERENCE_01?.Referencequalifier_01;
            DespatchReferenceNumber = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "AAU")?.RFF?.REFERENCE_01?.Referencenumber_02;
            DespatchLineNumber = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "AAU")?.RFF?.REFERENCE_01?.Linenumber_03;
            DespatchDate = linDeliveryNote.RFFLoop?.FirstOrDefault(x => x.RFF.REFERENCE_01.Referencequalifier_01 == "AAU")?.DTM?.DATETIMEPERIOD_01.asDateTime();
        }

        public ALI generateALI()
        {
            if (!string.IsNullOrEmpty(CountryOriginCoded))
            {
                ALI ali = new ALI();
                ali.Countryoforigincoded_01 = CountryOriginCoded;
                return ali;
            }

            return null;
        }
        public GIN generateGIN()
        {
            if (!string.IsNullOrEmpty(GoodsIdentityNumberQualifier))
            {
                GIN gin = new GIN();
                gin.Identitynumberqualifier_01 = GoodsIdentityNumberQualifier;
                gin.IDENTITYNUMBERRANGE_02 = new C208();
                gin.IDENTITYNUMBERRANGE_02.Identitynumber_01 = GoodsIdentityNumberRange;
                return gin;
            }

            return null;

        }
        public GIR generateGIR()
        {
            if (!string.IsNullOrEmpty(RelatedSetIdentificationQualifier))
            {
                GIR gir = new GIR();
                gir.Setidentificationqualifier_01 = RelatedSetIdentificationQualifier;
                gir.IDENTIFICATIONNUMBER_02 = new C206();
                gir.IDENTIFICATIONNUMBER_02.Identitynumber_01 = RelatedIdentityNumber;
                gir.IDENTIFICATIONNUMBER_02.Identitynumberqualifier_02 = RelatedIdentityNumberQualifier;
                return gir;
            }

            return null;
        }

        public DTM generateManufacturingDTM()
        {
           
            if (ManufacturingDate != null)
            {
                DTM dtm = new DTM();
                dtm.DATETIMEPERIOD_01 = new C507();
                dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "94";
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = ManufacturingDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
                return dtm;
            }

            return null;
        }

        public MOA generateMOA()
        {
            if (!string.IsNullOrEmpty(MonetaryAmountTypeQualifier))
            {
                MOA moa = new MOA();
                moa.MONETARYAMOUNT_01 = new C516();
                moa.MONETARYAMOUNT_01.Monetaryamounttypequalifier_01 = MonetaryAmountTypeQualifier;
                moa.MONETARYAMOUNT_01.Monetaryamount_02 = MonetaryAmount?.ToString("G29");
                moa.MONETARYAMOUNT_01.Currencycoded_03 = CurrencyCoded;
                return moa;
            }

            return null;
        }

        public RFF generatePurchaseRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = PurchaseReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = PurchaseReferenceNumber;
            rff.REFERENCE_01.Linenumber_03 = PurchaseLineNumber;
            return rff;
        }
        public RFF generateDespatchRFF()
        {
            RFF rff = new RFF();
            rff.REFERENCE_01 = new C506();
            rff.REFERENCE_01.Referencequalifier_01 = DespatchReferenceQualifier;
            rff.REFERENCE_01.Referencenumber_02 = DespatchReferenceNumber;
            rff.REFERENCE_01.Linenumber_03 = DespatchLineNumber;
            return rff;
        }
        public DTM generatePurchaseDTM()
        {
            DTM dtm = new DTM();
            dtm.DATETIMEPERIOD_01 = new C507();
            dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = PurchaseDateQualifier?? "171";
            if (PurchaseDate != null)
            {
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = PurchaseDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = PurchaseDateFormat ?? "102";
            }
            return dtm;
        }
        public DTM generateDespatchDTM()
        {
            DTM dtm = new DTM();
            dtm.DATETIMEPERIOD_01 = new C507();
            dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = "171";
            if (DespatchDate != null)
            {
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = DespatchDate.Value.ToString("yyyyMMdd");
                dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = "102";
            }
            return dtm;
        }

        public override void Configure(EntityTypeBuilder<LineItemDeliveryNote> b)
        {
            base.Configure(b);
            b.ToTable("EDI_" + this.GetType().Name).Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
