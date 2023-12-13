using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeActionRequest : BaseCodeEntity<CodeActionRequest>
    {
        public override string CodeDefinitionText => @"
1	Added
	This line item is added to the referenced message.
2	Deleted
	This line item is deleted from the referenced message.
3	Changed
	This line item is changed in the referenced message.
4	No action
	This line item is not affected by the actual message.
5	Accepted without amendment
	This line item is entirely accepted by the seller.
6	Accepted with amendment
	This line item is accepted but amended by the seller.
7	Not accepted
	This line item is not accepted by the seller.
8	Schedule only
	Self explanatory.
9	Amendments
	Self explanatory.
10	Not found
	This line item is not found in the referenced message.
11	Not amended
	This line is not amended by the buyer.
12	Line item numbers changed
	Self explanatory.
13	Buyer has deducted amount
	Buyer has deducted amount from payment.
14	Buyer claims against invoice
	Buyer has a claim against an outstanding invoice.
15	Charge back by seller
	Factor has been requested to charge back the outstanding item.
16	Seller will issue credit note
	Seller agrees to issue a credit note.
17	Terms changed for new terms
	New settlement terms have been agreed.
18	Abide outcome of negotiations
	Factor agrees to abide by the outcome of negotiations between seller and buyer.
19	Seller rejects dispute
	Seller does not accept validity of dispute.
20	Settlement
	The reported situation is settled.
21	No delivery
	Code indicating that no delivery will be required.
22	Call-off delivery
	A request for delivery of a particular quantity of goods to be delivered on a particular date (or within a particular period).
23	Proposed amendment
	A code used to indicate an amendment suggested by the sender.
24	Accepted with amendment, no confirmation required
	Accepted with changes which require no confirmation.";
        public override string StringCodeDefinitionText { get; }

	}
}
