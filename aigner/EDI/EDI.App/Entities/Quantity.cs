using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.App.Entities
{
    public class Quantity
    {
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
        public string ItemQuantity { get; set; }
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

        public void init(EdiFabric.Templates.EdifactD96A.QTY qty)
        {
            if (qty != null)
            {
                QuantityQualifier = qty.QUANTITYDETAILS_01.Quantityqualifier_01;
                ItemQuantity = qty.QUANTITYDETAILS_01.Quantity_02;
                QTYMeasureUnitQualifier = qty.QUANTITYDETAILS_01.Measureunitqualifier_03;
            }
        }
    }
}
