using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IBuyerContact
    {
        /// <summary>
        /// 0210 SG5 C 5 2 CTA-COM 0220 10 CTA M 1 2 Contact information
        /// 0220 10 CTA M 1 2 Contact information
        /// </summary>
        public string Buyer_ContactCode { get; set; }

        /// <summary>
        /// 0210 SG5 C 5 2 CTA-COM 0220 10 CTA M 1 2 Contact information
        /// 3412 Department or employee C an..35
        /// </summary>
        public string Buyer_Name { get; set; }

        public string Buyer_Email { get; set; }

        public string Buyer_Phone { get; set; }

        public void initCTABY(CTA cta);

        public void initContactBY(List<COM> coms);

        public CTA generateBuyerCTA();
        public COM generateBuyerPhone();
        public COM generateBuyerEmail();
    }
}
