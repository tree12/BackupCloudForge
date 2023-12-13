using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface ICurrency
    {
        ///<summary>
        /// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        /// 6347 Currency details qualifier M an..3 M an..3 2 Reference currency
        ///</summary>
        public string CurrencyDetailsQualifier { get; set; }

        /// <summary>
        /// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        /// 6345 Currency, coded C an..3 M an..3 Is required in ISO 4217 three alpha standard, e.g. EUR.
        /// </summary>
        public string Currency { get; set; }
        ///<summary>
        /// 0280 SG7 C 5 1 CUX -0290 22 CUX M 1 1 Currencies
        /// 6343 Currency qualifier C an..3 M an..3 4 Invoicing currency
        ///</summary>
        public string CurrencyQualifier { get; set; }

        public CUX generateCurrency();
        public void initCurrency(CUX cux);
    }
}
