using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IDeliveryLocation
    {
        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3227 Place/location qualifier M an..3
        ///
        /// 1 Place of terms of delivery
        /// </summary>
        public string Delivery_PlaceLocationQualifier { get; set; }

        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3225 Place/location identification C an..25
        ///
        /// </summary>
        public string Delivery_PlaceLocationIdentification { get; set; }

        public void DPLoc(LOC loc);

        public LOC generateDeliveryLOC();

    }
}
