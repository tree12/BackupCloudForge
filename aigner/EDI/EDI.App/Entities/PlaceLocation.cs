using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EdiFabric.Templates.EancomD01B;

namespace EDI.App.Entities
{
    public class PlaceLocation
    {
        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3227 Place/location qualifier M an..3
        ///
        /// 1 Place of terms of delivery
        /// </summary>
        public string PlaceLocationQualifier { get; set; }
        /// <summary>
        /// 0440 20 LOC C 2 2 Place/location identification - 3225 Place/location identification C an..25
        ///
        /// 
        /// </summary>
        public string PlaceLocationIdentification { get; set; }
        //public void init(EdiFabric.Templates.EancomD01B.LOC loc)
        //{
        //    if (loc != null)
        //    {
        //        PlaceLocationQualifier = loc.Locationfunctioncodequalifier_01;
        //        PlaceLocationIdentification = loc.LOCATIONIDENTIFICATION_02.Locationnamecode_01;
        //    }

        //}

        public void init(EdiFabric.Templates.EdifactD96A.LOC loc)
        {
            if (loc != null)
            {
                PlaceLocationQualifier = loc.Placelocationqualifier_01;
                PlaceLocationIdentification = loc.LOCATIONIDENTIFICATION_02.Placelocationidentification_01;
            }

        }
    }
}
