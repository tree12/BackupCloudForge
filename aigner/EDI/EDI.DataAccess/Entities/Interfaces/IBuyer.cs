using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IBuyer
    {
        /// <summary>
        /// 0110 SG2 M 1 1 NAD
        /// 0120 11 NAD M 1 1 Name and address
        /// 3035 Party qualifier M an..3 M an..3 BY Buyer
        /// </summary>
        public string Buyer_PartyQualifier { get; set; }

        /// <summary>
        /// C082 Party identification details C  - 3039 Party id. identification M an..35
        ///
        /// Buyer organisation number assigned by KTM. You can find
        /// the list here: https://ecosio.com/ktm/
        /// </summary>
        public string Buyer_PartyId { get; set; }

        /// <summary>
        /// 
        /// C082 Party identification details C  3055 Code list responsible agency,coded C an..3
        /// </summary>
        public string Buyer_ResponsibleAgency { get; set; }

        public NAD generateBuyer();
        public void initNADBY(NAD nad);

    }
}
