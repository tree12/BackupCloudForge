using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.App.Entities
{
    public class Contact
    {
        /// <summary>
        /// 0210 SG5 C 5 2 CTA-COM 0220 10 CTA M 1 2 Contact information
        /// 0220 10 CTA M 1 2 Contact information
        /// </summary>
        public string ContactCode { get; set; }
        /// <summary>
        /// 0210 SG5 C 5 2 CTA-COM 0220 10 CTA M 1 2 Contact information
        /// 3412 Department or employee C an..35
        /// </summary>
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public void init(Loop_CTA_ORDERS ctaOrders)
        {
            ContactCode = ctaOrders.CTA.Contactfunctioncoded_01;
            Email = ctaOrders.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Phone = ctaOrders.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Name = ctaOrders.CTA.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02;
        }
        public void init(Loop_CTA_INVOIC ctaInvoics)
        {
            ContactCode = ctaInvoics.CTA.Contactfunctioncoded_01;
            Email = ctaInvoics.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Phone = ctaInvoics.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Name = ctaInvoics.CTA.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02;
        }
        public void init(Loop_CTA_ORDCHG ctaOrders)
        {
            ContactCode = ctaOrders.CTA.Contactfunctioncoded_01;
            Email = ctaOrders.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Phone = ctaOrders.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Name = ctaOrders.CTA.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02;
        }
        public void init(Loop_CTA_DELFOR ctaDelFors)
        {
            ContactCode = ctaDelFors.CTA.Contactfunctioncoded_01;
            Email = ctaDelFors.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Phone = ctaDelFors.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Name = ctaDelFors.CTA.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02;
        }
        public void init(Loop_CTA_ORDRSP ctaOrdrsps)
        {
            ContactCode = ctaOrdrsps.CTA.Contactfunctioncoded_01;
            Email = ctaOrdrsps.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("EM")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Phone = ctaOrdrsps.COM.First(x => x.COMMUNICATIONCONTACT_01.Communicationchannelqualifier_02.Equals("TE")).COMMUNICATIONCONTACT_01.Communicationnumber_01;
            Name = ctaOrdrsps.CTA.DEPARTMENTOREMPLOYEEDETAILS_02.Departmentoremployee_02;
        }
    }
}
