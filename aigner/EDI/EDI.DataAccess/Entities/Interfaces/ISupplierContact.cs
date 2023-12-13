using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface ISupplierContact
    {
        public string Supplier_ContactCode { get; set; }
        public string Supplier_Name { get; set; }

        public string Supplier_Email { get; set; }

        public string Supplier_Phone { get; set; }

        public void initCTASU(CTA cta);

        public void initContactSU(List<COM> coms);

        public CTA generateSupplierCTA();
        public COM generateSupplierPhone();
        public COM generateSupplierEmail();
    }
}
