using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EDI.DataAccess.Entities.Codes
{
    public class CodeTypePeriodCode : BaseCodeEntity<CodeTypePeriodCode>
    {

        public override string CodeDefinitionText => "";

        public override string StringCodeDefinitionText => @"
    3M    Quarter

|    6M    Half-year

     AA    Air hour

     AD    Air day

     CD    Calendar day (includes weekends and holidays)

     CW    Calendar week (7day)

|    D     Day

     DC    Ten days period

     DW    Work day

     F     Period of two weeks

|    H     Hour

|    HM    Half month

|    M     Month

|    MN    Minute

|    P     Four month period

|    S     Second

|    SD    Surface day

     SI    Indefinite

     W     Week

     WD    Working days

     WW    5 day work week

|    Y     Year

ZZZ   Mutually defined";
    }
}
