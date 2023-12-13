using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeProductIdFunctionQualifier : BaseCodeEntity<CodeProductIdFunctionQualifier>
    {
        public override string CodeDefinitionText => @"
1	Additional identification
	Information which specifies and qualifies product identifications.
2	Identification for potential substitution
    The given item number(s) describe(s) a substituting product if the original product is not available.
3	Substituted by
    The given item number is the number of the product that substitutes another one.
4	Substituted for
    The given item number is the number of the original product substituted by another.
5	Product identification
    Self explanatory.
6	Successor product id
    Product id of the product that will follow the one currently in production/trade.
7	Predecessor product id
    Product id of the predecessor of the product currently in production/trade.
8	Expired/out of production
    The given item number is the expired item number of the product. It has been replaced.";
		public override string StringCodeDefinitionText { get; }
    }
}
