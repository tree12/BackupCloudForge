using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IFreightForwarder
    {
        /// <summary>
        /// 3035 Party qualifier M an..3 M an..3
        /// 
        /// FW FreightForwarder
        /// </summary>
        public string FreightForwarder_PartyQualifier { get; set; }

        /// <summary>
        /// C082 Party identification details C  - 3039 Party id. identification M an..35
        ///
        /// Buyer organisation number assigned by the Supplier.
        /// </summary>
        public string FreightForwarder_PartyId { get; set; }

        /// <summary>
        /// C082 Party identification details C  3055 Code list responsible agency,coded C an..3
        /// 
        /// 92 Assigned by buyer or buyer's agent
        /// 91 Assigned by seller or seller's agent
        /// 16 DUNS(Dun & Bradstreet)
        /// </summary>
        public string FreightForwarder_ResponsibleAgency { get; set; }

        /// <summary>
        /// 
        /// C080 Party name C  3036 Party name M an..35
        /// </summary>
        public string FreightForwarder_CompanyName { get; set; }

        /// <summary>
        /// 
        /// C059 Street C  3042 Street and number/p.o. box M an..35
        /// </summary>
        public string FreightForwarder_Street { get; set; }

        /// <summary>
        /// 
        /// 3164 City name
        /// </summary>
        public string FreightForwarder_CityName { get; set; }

        /// <summary>
        /// 
        /// 3251 Postcode identification
        /// </summary>
        public string FreightForwarder_Postcode { get; set; }

        /// <summary>
        /// 
        /// 33207 Country, coded C an..3
        /// </summary>
        public string FreightForwarder_CountryCode { get; set; }

        public NAD generateFreightForwarder();
        public void initFreightForwarder(NAD nad);
    }
}
