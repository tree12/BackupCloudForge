using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IFinancialInstitution
    {
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank1Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank1Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank1InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank1InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank1InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank1Country { get; set; }

        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank2Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank2Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank2InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank2InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank2InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank2Country { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        /// 
        /// 3194 Account holder number C an..35 M an..35
        /// </summary>
        public string Bank3Iban { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C078 Account identification C
        ///
        /// 3192 Account holder name C an..35
        /// </summary>
        public string Bank3Name { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        /// 
        /// 3433 Institution name identification C an..11
        /// </summary>
        public string Bank3InstitutionNameId { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3434 Institution branch number C an..17
        /// </summary>
        public string Bank3InstitutionBranchNumber { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        /// C088 Institution identification C
        ///
        /// 3432 Institution name C an..70
        /// </summary>
        public string Bank3InstitutionName { get; set; }
        /// <summary>
        /// 0110 SG2 M 1 1 NAD-FII-SG3-SG5 -0140 13 FII M 5 2 Financial institution information
        ///
        /// 3207 Country, coded C an..3
        /// </summary>
        public string Bank3Country { get; set; }

        public void initFinancial(List<FII> fii);
    }
}
