using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities.Attributes;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeFreeTextCode : BaseCodeEntity<CodeFreeTextCode>
    {
        [NotSave]
        public int? TaxCaseAigner { get; set; }
        public override string CodeDefinitionText { get; }
        public override string StringCodeDefinitionText => @"
IGL Intra-Community supply

AFL Tax-free export delivery 

ZZZ Mutally Definied

LES Reverse Charge";
    }
}
