using System;
using System.Collections.Generic;
using System.Linq;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities
{
    public class LineItemBase<TEntity> : BaseEdiObject<TEntity> where TEntity : LineItemBase<TEntity>
    {
        /// <summary>
        /// 1082 Line item number C n..6
        ///
        /// Positon number of this article. The position number is needed as reference in the return receipts to KTM(e.g. dispatch advices)
        /// </summary>
        public string LineItemNumber { get; set; }

        /// <summary>
        /// 7140 Item number C an..35
        ///
        /// KTM's article number of this line item
        /// </summary>
        public string BuyersArticleNumber { get; set; }

        /// <summary>
        /// 7143 Item number type, coded C an..3
        ///
        /// BP Buyer's part number
        /// </summary>
        public string BuyersArticleNumberType { get; set; }
        /// <summary>
        /// 0890 SG25 M 9999999 1 LIN-PIA-IMD-QTY-FTX-SG26-SG28-SG29-SG33 - 0910 32 PIA C 1 2 Additional product id
        ///
        /// 4347 Product id. function qualifier M an..3 M an..3
        /// </summary>
        public string SupplierArticleNumberQualifier { get; set; }
        /// <summary>
        /// 0890 SG25 M 9999999 1 LIN-PIA-IMD-QTY-FTX-SG26-SG28-SG29-SG33 - 0910 32 PIA C 1 2 Additional product id
        ///
        /// 7140 Item number C an..35
        /// </summary>
        public string SupplierArticleNumber { get; set; }
        /// <summary>
        /// 0890 SG25 M 9999999 1 LIN-PIA-IMD-QTY-FTX-SG26-SG28-SG29-SG33 - 0910 32 PIA C 1 2 Additional product id
        ///
        /// 7143 Item number type, coded C an..3 M an..3 SA Supplier's article number
        /// </summary>
        public string SupplierArticleNumberType { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7077 Item description type, coded C an..3
        ///
        /// Item description type, coded 
        /// </summary>
        public string ItemDescriptionType { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7081 Item characteristic, coded C an..3
        /// 
        /// </summary>
        public string ItemCharacteristicCode { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7009 Item description identification C an..17
        /// 
        /// </summary>
        public string ItemDescriptionIdentification { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 1131 Code list qualifier C an..3
        /// 
        /// </summary>
        public string CodeListQualifier { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 3055 Code list responsible agency, coded C an..3
        ///
        /// </summary>
        public string CodeListResponsibleAgency { get; set; }

        /// <summary>
        /// 0960 23 IMD C 99 2 Item description - 7008 Item description C an..35
        ///
        /// Free text description of the line item.
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6063 Quantity qualifier M an..3
        ///
        /// 21 Ordered quantity
        /// </summary>
        public string QuantityQualifier { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6060 Quantity M n..15
        ///
        /// </summary>
        public decimal? ItemQuantity { get; set; }
        /// <summary>
        /// 0980 24 QTY C 10 2 Quantity - 6411 Measure unit qualifier C an..3
        ///
        /// Code specifying the unit of measurement, use UN/ECE
        /// Recommendation 20, Common code.
        ///     PCE Piece
        ///     MTR Metre*
        ///     KGM Kilogram*
        /// </summary>
        public string QTYMeasureUnitQualifier { get; set; }
        /// <summary>
        /// 1960 SG50 C 10 3 QTY-DTM
        /// 1980 29 DTM C 5 4 Date/time/period
        /// C507 Date/time/period - 2005 Date/time/period qualifier M an..3 M an..3 171 Reference date/time
        /// </summary>
        public string DeliveryDateQualifier { get; set; }
        /// <summary>
        /// 1960 SG50 C 10 3 QTY-DTM
        /// 1980 29 DTM C 5 4 Date/time/period
        ///
        /// </summary>
        public DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// 1960 SG50 C 10 3 QTY-DTM
        /// 1980 29 DTM C 5 4 Date/time/period
        /// C507 Date/time/period M M - 2379 Date/time/period format qualifier C an..3 M an..3 102 CCYYMMDD
        /// </summary>
        public string DeliveryDateFormat { get; set; }

        protected void initPIA(List<PIA> pias)
        {
            if (pias != null && pias.Any())
            {
                if (pias.Any(p => !p.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02.EqualsIgnoreCase("SA")))
                    AddEdiConvertError("Found ArticleNumbers that we can not handle yet");
                //AdditionalItemNumber = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
                //AdditionalItemNumberType = linOrders.PIA[0]?.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
                var pia = pias.FirstOrDefault(x => x.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02.EqualsIgnoreCase("SA"));
                if (pia != null)
                {
                    SupplierArticleNumberQualifier = pia.Productidfunctionqualifier_01;
                    SupplierArticleNumber = pia.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01;
                    SupplierArticleNumberType = pia.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02;
                }

            }
        }

        protected void initLIN(LIN lin)
        {
            LineItemNumber = lin?.Lineitemnumber_01;
            BuyersArticleNumber = lin?.ITEMNUMBERIDENTIFICATION_03?.Itemnumber_01;
            BuyersArticleNumberType = lin?.ITEMNUMBERIDENTIFICATION_03?.Itemnumbertypecoded_02;
        }

        protected void initIMD(List<IMD> imds)
        {
            var imd = imds.FirstOrDefault();
            if (imd != null)
            {
                ItemDescriptionType = imd.Itemdescriptiontypecoded_01;
                ItemCharacteristicCode = imd.Itemcharacteristiccoded_02;
                ItemDescriptionIdentification = imd.ITEMDESCRIPTION_03.Itemdescriptionidentification_01;
                CodeListQualifier = imd.ITEMDESCRIPTION_03.Codelistqualifier_02;
                CodeListResponsibleAgency = imd.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03;
                ItemDescription = imd.ITEMDESCRIPTION_03.Itemdescription_04;
                if (!string.IsNullOrEmpty(imd.ITEMDESCRIPTION_03.Itemdescription_05))
                {
                    ItemDescription += imd.ITEMDESCRIPTION_03.Itemdescription_05;
                }
            }
        }

        protected void initQTY(QTY qty)
        {
            if (qty != null)
            {
                QuantityQualifier = qty.QUANTITYDETAILS_01.Quantityqualifier_01;
                if (!string.IsNullOrEmpty(qty.QUANTITYDETAILS_01.Quantity_02))
                    ItemQuantity = decimal.Parse(qty.QUANTITYDETAILS_01.Quantity_02);
                QTYMeasureUnitQualifier = qty.QUANTITYDETAILS_01.Measureunitqualifier_03;
            }

        }
        protected void initDeliveryDTM(DTM dtm)
        {
            if (dtm != null)
            {
                DeliveryDateQualifier = dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01;
                DeliveryDate = dtm.DATETIMEPERIOD_01.asDateTime();
                DeliveryDateFormat = dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03;
            }

        }
        #region Generate Line Item

        public LIN generateLIN()
        {
            LIN lin = new LIN();
            lin.Lineitemnumber_01 = LineItemNumber;
            lin.ITEMNUMBERIDENTIFICATION_03 = new C212();
            lin.ITEMNUMBERIDENTIFICATION_03.Itemnumber_01 = BuyersArticleNumber;
            lin.ITEMNUMBERIDENTIFICATION_03.Itemnumbertypecoded_02 = BuyersArticleNumberType;
            return lin;
        }

        public PIA generatePIA()
        {
            if (!string.IsNullOrEmpty(SupplierArticleNumberQualifier))
            {
                var pia = new PIA();
                pia.Productidfunctionqualifier_01 = SupplierArticleNumberQualifier;
                pia.ITEMNUMBERIDENTIFICATION_02 = new C212();
                pia.ITEMNUMBERIDENTIFICATION_02.Itemnumber_01 = SupplierArticleNumber;
                pia.ITEMNUMBERIDENTIFICATION_02.Itemnumbertypecoded_02 = SupplierArticleNumberType;
                return pia;
            }

            return null;

        }

        public IMD generateIMD()
        {
            if (!string.IsNullOrEmpty(ItemDescriptionType))
            {
                var imd = new IMD();
                imd.Itemdescriptiontypecoded_01 = ItemDescriptionType;
                imd.Itemcharacteristiccoded_02 = ItemCharacteristicCode;
                imd.ITEMDESCRIPTION_03 = new C273();
                imd.ITEMDESCRIPTION_03.Itemdescriptionidentification_01 = ItemDescriptionIdentification;
                imd.ITEMDESCRIPTION_03.Codelistqualifier_02 = CodeListQualifier;
                imd.ITEMDESCRIPTION_03.Codelistresponsibleagencycoded_03 = CodeListResponsibleAgency;
                imd.ITEMDESCRIPTION_03.GenC273FromText(ItemDescription);
                //if (ItemDescription.Length > 35)
                //{
                //    imd.ITEMDESCRIPTION_03.Itemdescription_04 = ItemDescription.LimitStringLength(35);
                //    imd.ITEMDESCRIPTION_03.Itemdescription_05 = ItemDescription.LimitStringLength(ItemDescription.Length - 35, 35);
                //}
                //else
                //{
                //    imd.ITEMDESCRIPTION_03.Itemdescription_04 = ItemDescription;
                //}

                return imd;
            }

            return null;

        }

        public QTY generateQTY()
        {
            
            if (!string.IsNullOrEmpty(QuantityQualifier))
            {
                var qty = new QTY();
                qty.QUANTITYDETAILS_01 = new C186();
                qty.QUANTITYDETAILS_01.Quantityqualifier_01 = QuantityQualifier;
                if (ItemQuantity != null)
                    qty.QUANTITYDETAILS_01.Quantity_02 = ItemQuantity.Value.ToString("G29");
                qty.QUANTITYDETAILS_01.Measureunitqualifier_03 = QTYMeasureUnitQualifier;
                return qty;
            }

            return null;


        }
        public DTM generateDeliveryDTM()
        {
            DTM dtm = new DTM();
            dtm.DATETIMEPERIOD_01 = new C507();
            dtm.DATETIMEPERIOD_01.Datetimeperiodqualifier_01 = DeliveryDateQualifier?? "2";
            if (DeliveryDate != null)
                dtm.DATETIMEPERIOD_01.Datetimeperiod_02 = DeliveryDate.Value.ToString("yyyyMMdd");
            dtm.DATETIMEPERIOD_01.Datetimeperiodformatqualifier_03 = DeliveryDateFormat?? "102";
            return dtm;
        }

        #endregion

    }
}