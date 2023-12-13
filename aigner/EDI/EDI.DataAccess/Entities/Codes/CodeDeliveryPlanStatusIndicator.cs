using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeDeliveryPlanStatusIndicator : BaseCodeEntity<CodeDeliveryPlanStatusIndicator>
    {
        public override string CodeDefinitionText => @"
1	Firm
	Indicates that the scheduling information is a firm commitment.
2	Commitment for manufacturing and material
	Authorizes the supplier to start the manufacturing of goods.
3	Commitment for material
	Authorizes the manufacturer to order material required for manufacturing specified goods.
4	Planning/forecast
	Self explanatory.
5	Short delivered on previous delivery
	Self explanatory.
9	User defined
	Self explanatory.
10	Immediate
	Indicates that the scheduling information is for immediate execution.
11	Pilot/Pre-volume
	Description to be provided.
12	Planning
	Description to be provided.
13	Potential order increase
	Description to be provided.
14	Average plant usage
	Description to be provided.
15	First time reported firm
	Description to be provided.
16	Maximum
	Description to be provided.
17	Tooling capacity
	Description to be provided.
18	Normal tooling capacity
	Description to be provided.
19	Prototype
	Description to be provided.
20	Strike protection
	Description to be provided.
21	Required tooling capacity
	Description to be provided.
22	Deliver to schedule
	Deliver to schedule separately supplied.
23	Await manual pull
	Await non-EDI instruction before shipping.
24	Reference to commercial agreement between partners
	The buyer's commitment is the one defined in the commercial agreement.
25	Reference to commercial agreement between partners
	The buyer's commitment is the one defined in the commercial agreement.
26	Proposed
	Indicates that the scheduling information is a proposal.";
        public override string StringCodeDefinitionText { get; }
    }
}
