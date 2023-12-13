using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeTextFunctionCode : BaseCodeEntity<CodeTextFunctionCode>
    {
        public override string CodeDefinitionText => @"
1	Text for subsequent use
	The occurrence of this text does not affect message processing.

2	Text replacing missing code
	Text description of a coded data item for which there is no currently available code.

3	Text for immediate use
	Text must be read before actioning message.

4	No action required
	Pass text on to later recipient.";
        public override string StringCodeDefinitionText { get; }
    }
}
