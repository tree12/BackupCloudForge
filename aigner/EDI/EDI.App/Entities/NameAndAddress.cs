using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class NameAndAddress : BaseEntity
    {
        /// <summary>
        /// 3035 Party qualifier M an..3 M an..3
        /// 
        /// BY Buyer
        /// </summary>
        public string PartyQualifier { get; set; }

        /// <summary>
        /// C082 Party identification details C  - 3039 Party id. identification M an..35
        ///
        /// Buyer organisation number assigned by KTM. You can find
        /// the list here: https://ecosio.com/ktm/
        /// </summary>
        public string PartyId { get; set; }
        /// <summary>
        /// 0210 SG5 C 5 2 CTA-COM
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
		/// 
		/// C082 Party identification details C  3055 Code list responsible agency,coded C an..3
		/// </summary>
		public string ResponsibleAgency { get; set; }
        /// <summary>
        /// 
        /// C080 Party name C  3036 Party name M an..35
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 
        /// C059 Street C  3042 Street and number/p.o. box M an..35
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 
        /// 3164 City name
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 
        /// 3251 Postcode identification
        /// </summary>
        public string Postcode { get; set; }
        /// <summary>
        /// 
        /// 33207 Country, coded C an..3
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// 0110 SG2 C 99 1 NAD-LOC
        /// </summary>
        public PlaceLocation Location { get; set; }

        public FinancialInstitution FinancialInstitution { get; set; }
        /// <summary>
        /// 0150 SG3 D 9999 2 RFF
        /// 
        /// 0160 14 RFF M 1 2 Reference
        /// </summary>
        public string VATRegistrationNumber { get; set; }


        public void init(Loop_NAD_ORDERS nadOrders)
        {
            PartyId = nadOrders.Id.ToString();
            ResponsibleAgency = nadOrders.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadOrders.NAD.Partyqualifier_01;
            if (nadOrders.CTALoop != null && nadOrders.CTALoop.Any())
            {
                if (nadOrders.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadOrders.CTALoop.First());
            }
            if (nadOrders.LOC != null && nadOrders.LOC.Any())
            {
                if (nadOrders.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadOrders.LOC.First());
            }

        }
        public void init(Loop_NAD_INVOIC nadInvoices)
        {
            PartyId = nadInvoices.NAD.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
            ResponsibleAgency = nadInvoices.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadInvoices.NAD.Partyqualifier_01;

            CompanyName = nadInvoices.NAD.PARTYNAME_04?.Partyname_01;
            Street = nadInvoices.NAD.STREET_05?.Streetandnumberpobox_01;
            CityName = nadInvoices.NAD.Cityname_06;
            Postcode = nadInvoices.NAD.Postcodeidentification_08;
            CountryCode = nadInvoices.NAD.Countrycoded_09;

            if (nadInvoices.CTALoop != null && nadInvoices.CTALoop.Any())
            {
                if (nadInvoices.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadInvoices.CTALoop.First());
            }
            if (nadInvoices.LOC != null && nadInvoices.LOC.Any())
            {
                if (nadInvoices.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadInvoices.LOC.First());
            }

        }
        public void init(Loop_NAD_ORDCHG nadOrders)
        {
            PartyId = nadOrders.NAD.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
            ResponsibleAgency = nadOrders.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadOrders.NAD.Partyqualifier_01;
            if (nadOrders.CTALoop != null && nadOrders.CTALoop.Any())
            {
                if (nadOrders.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadOrders.CTALoop.First());
            }
            if (nadOrders.LOC != null && nadOrders.LOC.Any())
            {
                if (nadOrders.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadOrders.LOC.First());
            }

        }
        public void init(Loop_NAD_DELFOR nadOrdchg)
        {
            PartyId = nadOrdchg.NAD.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
            ResponsibleAgency = nadOrdchg.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadOrdchg.NAD.Partyqualifier_01;
            if (nadOrdchg.CTALoop != null && nadOrdchg.CTALoop.Any())
            {
                if (nadOrdchg.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadOrdchg.CTALoop.First());
            }
            if (nadOrdchg.LOC != null && nadOrdchg.LOC.Any())
            {
                if (nadOrdchg.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadOrdchg.LOC.First());
            }

        }
        public void init(Loop_NAD_DELFOR_2 nadOrdchg)
        {
            PartyId = nadOrdchg.NAD.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
            ResponsibleAgency = nadOrdchg.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadOrdchg.NAD.Partyqualifier_01;

            CompanyName = nadOrdchg.NAD.PARTYNAME_04?.Partyname_01;
            Street = nadOrdchg.NAD.STREET_05?.Streetandnumberpobox_01;
            CityName = nadOrdchg.NAD.Cityname_06;
            Postcode = nadOrdchg.NAD.Postcodeidentification_08;
            CountryCode = nadOrdchg.NAD.Countrycoded_09;
            if (nadOrdchg.CTALoop != null && nadOrdchg.CTALoop.Any())
            {
                if (nadOrdchg.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadOrdchg.CTALoop.First());
            }
            if (nadOrdchg.LOC != null && nadOrdchg.LOC.Any())
            {
                if (nadOrdchg.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadOrdchg.LOC.First());
            }

        }
        public void init(Loop_NAD_ORDRSP nadOrdrsps)
        {
            PartyId = nadOrdrsps.NAD.PARTYIDENTIFICATIONDETAILS_02.Partyididentification_01;
            ResponsibleAgency = nadOrdrsps.NAD.PARTYIDENTIFICATIONDETAILS_02.Codelistresponsibleagencycoded_03;
            PartyQualifier = nadOrdrsps.NAD.Partyqualifier_01;
            if (nadOrdrsps.CTALoop != null && nadOrdrsps.CTALoop.Any())
            {
                if (nadOrdrsps.CTALoop.Count > 1) throw new EdiException("Only expedted 1 contact");
                Contact = new Contact();
                Contact.init(nadOrdrsps.CTALoop.First());
            }
            if (nadOrdrsps.LOC != null && nadOrdrsps.LOC.Any())
            {
                if (nadOrdrsps.LOC.Count > 1) throw new EdiException("Only expedted 1 contact");
                Location = new PlaceLocation();
                Location.init(nadOrdrsps.LOC.First());
            }

        }
    }
}

