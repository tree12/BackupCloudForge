using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeDutyTaxFeeCategoryCode : BaseCodeEntity<CodeDutyTaxFeeCategoryCode>
    {

        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @"

|    A     Mixed tax rate

     AA    Lower rate

     AB    Exempt for resale

     AC    Value Added Tax (VAT) not now due for payment

     AD    Value Added Tax (VAT) due from a previous invoice

     B     Transferred (VAT)

     C     Duty paid by supplier

|    E     Exempt from tax

|    G     Free export item, tax not charged

|    H     Higher rate

|    O     Services outside scope of tax

|    S     Standard rate

|    Z     Zero rated goods";
    }
}
