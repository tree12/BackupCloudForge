using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IEdiDeliveryCondition
    {
        /// <summary>
        /// 0430 19 TOD M 1 1 Terms of delivery or transport - 4055 Terms of delivery or transport function, coded C an..3
        ///
        /// 5 Transport condition
        /// </summary>
        public string TermsOfDeliveryFunctionCode { get; set; }

        /// <summary>
        /// 0430 19 TOD M 1 1 Terms of delivery or transport - 4053 Terms of delivery or transport,coded C an..3
        ///
        /// Incoterms will be used
        /// </summary>
        public string TermsOfDeliveryIncoterms { get; set; }

        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3227 Place/location qualifier M an..3
        ///
        /// 1 Place of terms of delivery
        /// </summary>
        public string TermsOfDeliveryPlaceLocationQualifier { get; set; }

        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3225 Place/location identification C an..25
        ///
        /// 
        /// </summary>
        public string TermsOfDeliveryPlaceLocationIdentification { get; set; }

        public TOD generateDeliveryCondition1();

        public LOC generateDeliveryConditionLocation1();
    }
}
