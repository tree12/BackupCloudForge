using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
   public class CodeItemDescriptionType : BaseCodeEntity<CodeItemDescriptionType>
    {
        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @"
    A	Free-form long description
    B	Code and text
    C	Code (from industry code list)
	D	Free-form price look up
	E   Free-form short description
    F	Free-form
    S	Structured (from industry code list)
    X	Semi-structured (code + text)";
    }
}
