using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodePaymentTermsDescriptionIdentifier: BaseCodeEntity<CodePaymentTermsDescriptionIdentifier>
    {

        public override string CodeDefinitionText => @"  1     Draft(s) drawn on issuing bank
              Draft(s) must be drawn on the issuing bank.

     2     Draft(s) drawn on advising bank
              Draft(s) must be drawn on the advising bank.

     3     Draft(s) drawn on reimbursing bank
              Draft(s) must be drawn on the reimbursing bank.

     4     Draft(s) drawn on applicant
              Draft(s) must be drawn on the applicant.

     5     Draft(s) drawn on any other drawee
              Draft(s) must be drawn on any other drawee.

     6     No drafts
              No drafts required.

     7     Payment means specified in commercial account summary
              An indication that the payment means are specified in a
              commercial account summary.";

        public override string StringCodeDefinitionText { get; }
    }
}
