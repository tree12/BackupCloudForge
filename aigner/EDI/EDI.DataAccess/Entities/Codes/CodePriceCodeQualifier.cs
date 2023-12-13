using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodePriceCodeQualifier: BaseCodeEntity<CodePriceCodeQualifier>
    {

        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @" AAA   Calculation net

     AAB   Calculation gross

     AAC   Allowances and charges not included, tax included

     AAD   Average selling price

     AAE   Information price, excluding allowances or charges,including taxes

     AAF   Information price, excluding allowances or charges, and taxes

     AAG   Additive unit price component

     CAL   Calculation price

     INF   Information

     INV   Invoice price";
    }
}
