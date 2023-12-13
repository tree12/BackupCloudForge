using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EdiFabric.Templates.EdifactD96A;

namespace EDI.DataAccess.Entities.Interfaces
{
    public interface IFreeText
    {
        
        public string FreeTextTextSubjectQualifier { get; set; }
        public string FreeTextFreeTextCoded { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }

        public void init(FTX ftx);
        public FTX generateFTX();
        //public void initFreeTextFTX(FTX ftx)
        //{

        //    if (ftx != null)
        //    {
        //        FreeTextTextSubjectQualifier = ftx.Textsubjectqualifier_01;
        //        FreeTextFreeTextCoded = ftx.TEXTREFERENCE_03.Freetextcoded_01;
        //        FreeText1 = ftx.TEXTLITERAL_04.Freetext_01;
        //        FreeText2 = ftx.TEXTLITERAL_04.Freetext_02;
        //        FreeText3 = ftx.TEXTLITERAL_04.Freetext_03;
        //        FreeText4 = ftx.TEXTLITERAL_04.Freetext_04;
        //        FreeText5 = ftx.TEXTLITERAL_04.Freetext_05;
        //    }

        //}
        //public FTX generateFreeTextFTX()
        //{
        //    if (!string.IsNullOrEmpty(FreeTextTextSubjectQualifier))
        //    {

        //        FTX ftx = new FTX();
        //        ftx.Textsubjectqualifier_01 = FreeTextTextSubjectQualifier;
        //        ftx.TEXTREFERENCE_03 = new C107();
        //        ftx.TEXTREFERENCE_03.Freetextcoded_01 = FreeTextFreeTextCoded;
        //        ftx.TEXTLITERAL_04 = new C108();
        //        ftx.TEXTLITERAL_04.Freetext_01 = FreeText1;
        //        ftx.TEXTLITERAL_04.Freetext_02 = FreeText2;
        //        ftx.TEXTLITERAL_04.Freetext_03 = FreeText3;
        //        ftx.TEXTLITERAL_04.Freetext_04 = FreeText4;
        //        ftx.TEXTLITERAL_04.Freetext_05 = FreeText5;
        //        return ftx;
        //    }

        //    return null;
        //}


        //public void initFTXs(List<FTX> ftxList)
        //{
        //    int index = 0;
        //    foreach (var ftx in ftxList)
        //    {
        //        if (ftx != null)
        //        {
        //            ++index;
        //            PropertyInfo qualifier = this.GetType().GetProperty($"Text{index}TextSubjectQualifier");
        //            PropertyInfo freeTextCoded = this.GetType().GetProperty($"Text{index}FreeTextCoded");
        //            PropertyInfo text = this.GetType().GetProperty($"Text{index}");
        //            if (qualifier != null)
        //                qualifier.SetValue(this, ftx.Textsubjectqualifier_01);
        //            if (freeTextCoded != null)
        //                freeTextCoded.SetValue(this, ftx.Textfunctioncoded_02);
        //            if (text != null)
        //                text.SetValue(this, ftx.TEXTLITERAL_04.GenStringFromC108());

        //        }


        //    }
        //}
        //public List<FTX> generateFTXs()
        //{
        //    List<FTX> ftxList = new List<FTX>();
        //    for (int index = 0; index < 12; ++index)
        //    {

        //        FTX ftx = new FTX();
        //        PropertyInfo qualifier = this.GetType().GetProperty($"Text{(index + 1)}TextSubjectQualifier");
        //        PropertyInfo freeTextCoded = this.GetType().GetProperty($"Text{(index + 1)}FreeTextCoded");
        //        PropertyInfo text = this.GetType().GetProperty($"Text{(index + 1)}");
        //        if (qualifier != null)
        //            ftx.Textsubjectqualifier_01 = qualifier.GetValue(this)?.ToString();

        //        if (freeTextCoded != null)
        //        {
        //            ftx.TEXTREFERENCE_03 = new C107();
        //            ftx.TEXTREFERENCE_03.Freetextcoded_01 = freeTextCoded.GetValue(this)?.ToString();
        //        }

        //        if (text != null)
        //        {
        //            ftx.TEXTLITERAL_04 = new C108();
        //            string descriptions = text.GetValue(this)?.ToString().EscapeForEdi();
        //            ftx.TEXTLITERAL_04.GenC108FromText(descriptions);

        //        }

        //        if (!string.IsNullOrEmpty(ftx.Textsubjectqualifier_01))
        //            ftxList.Add(ftx);

        //    }

        //    return ftxList;
        //}

    }
}
