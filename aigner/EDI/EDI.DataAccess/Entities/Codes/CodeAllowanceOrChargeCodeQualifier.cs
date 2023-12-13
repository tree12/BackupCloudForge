using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeAllowanceOrChargeCodeQualifier : BaseCodeEntity<CodeAllowanceOrChargeCodeQualifier>
    {

        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @"|    A     Allowance

     B     Total other

|    C     Charge

|   D     Allowance per call off

|   E     Charge per call off

     F     Allowance message

     G     Allowance line items

     H     Line item allowance

|    J     Adjustment

     K     Charge message

     L     Charge line items

     M     Line item charge

     N     No allowance or charge

     O     About

     P     Minus (percentage)

     Q     Minus (amount)

     R     Plus (percentage)

     S     Plus (amount)

     T     Plus/minus (percentage)

     U     Plus/minus (amount)

|    V     No allowance

|    W     No charge

     X     Maximum

     Y     Exact ";
    }
}
