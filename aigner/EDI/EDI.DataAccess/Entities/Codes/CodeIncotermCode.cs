using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeIncotermCode : BaseCodeEntity<CodeIncotermCode>
    {
        public override string CodeDefinitionText { get; }

        public override string StringCodeDefinitionText => @"|    EXW     Ex-Works

     FCA     Free Carrier

|    CPT	Carriage Paid To

|    CIP	Carriage and Insurance Paid

|    DAT	Delivered at Terminal

     DAP	Delivered at Place

     DDP	Delivered Duty Paid

     FAS	Free alongside Ship

|    FOB	Free On Board

     CFR	Cost and Freight

     CIF	Cost, Insurance and Freight
";
    }
}
