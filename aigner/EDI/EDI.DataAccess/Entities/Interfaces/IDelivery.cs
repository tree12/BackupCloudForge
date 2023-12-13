using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IDelivery
    {
		/// <summary>
		/// 3035 Party qualifier M an..3 M an..3
		/// 
		/// SU Supplier
		/// </summary>
		public string Delivery_PartyQualifier { get; set; }

		/// <summary>
		/// C082 Party identification details C  - 3039 Party id. identification M an..35
		///
		/// Plant number assigned by KTM. You can find the list here: https://ecosio.com/ktm/
		/// </summary>
		public string Delivery_PartyId { get; set; }

		/// <summary>
		/// 
		/// C082 Party identification details C  3055 Code list responsible agency,coded C an..3
		/// </summary>
		public string Delivery_ResponsibleAgency { get; set; }

		/// <summary>
		/// 
		/// C080 Party name C  3036 Party name M an..35
		/// </summary>
		public string Delivery_CompanyName { get; set; }

		/// <summary>
		/// 0110 SG2 C 99 1 NAD-LOC - 0120 14 NAD M 1 1 Name and address
		/// C080 Party name C -3036 Party name M an..35
		/// </summary>
		//public string Delivery_PartyName1 { get; set; }

		///// <summary>
		///// 0110 SG2 C 99 1 NAD-LOC - 0120 14 NAD M 1 1 Name and address
		///// C080 Party name C -3036 Party name C an..35
		///// </summary>
		//public string Delivery_PartyName2 { get; set; }

		/// <summary>
		/// 
		/// C059 Street C  3042 Street and number/p.o. box M an..35
		/// </summary>
		public string Delivery_Street { get; set; }

		/// <summary>
		/// 
		/// 3164 City name
		/// </summary>
		public string Delivery_CityName { get; set; }

		/// <summary>
		/// 
		/// 3251 Postcode identification
		/// </summary>
		public string Delivery_Postcode { get; set; }

		/// <summary>
		/// 
		/// 33207 Country, coded C an..3
		/// </summary>
		public string Delivery_CountryCode { get; set; }

        public NAD generateDelivery();
	}
}
