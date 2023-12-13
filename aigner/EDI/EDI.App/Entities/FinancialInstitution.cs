using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.App.Entities
{
    public class FinancialInstitution
    {
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3035 Party qualifier M an..3 M an..3 RB Receiving financial institution
        /// </summary>
        public string PartyQualifier { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string AccountHolderNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string AccountHolderName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string InstitutionIdentification { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string CountryCode { get; set; }
    }
}
