using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IDocumentReference
    {
        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1153 Reference qualifier M an..3 
        ///
        /// ON Order number (purchase)
        /// </summary>
        public string ReferenceQualifier { get; set; }

        /// <summary>
        /// 080 SG1 C 10 1 RFF-DTM
        /// 0090 7 RFF M 1 1 Reference
        /// 1154 Reference number C an..35
        ///
        /// Reference Number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// 0080 SG1 C 10 1 RFF-DTM
        /// 0100 8 DTM C 5 2 Date/time/period
        ///
        /// 
        /// </summary>
        public DateTime? ReferenceDate { get; set; }

        public void initRFF(RFF reff);
        public void initRefDate(DTM dtm);
        public RFF generateRFF();
        public DTM generateReferenceDTM();
    }
}
