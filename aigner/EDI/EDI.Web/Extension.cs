using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EDI.DataAccess.Entities;
using EdiFabric.Core.Model.Edi;
using Microsoft.AspNetCore.Authentication;

namespace EDI.Web
{
    public static class Extension
    {
        private static IReadOnlyDictionary<string, string> SPECIAL_DIACRITICS = new Dictionary<string, string>
        {
            { "ä".Normalize(NormalizationForm.FormD), "ae".Normalize(NormalizationForm.FormD) },
            { "Ä".Normalize(NormalizationForm.FormD), "Ae".Normalize(NormalizationForm.FormD) },
            { "ö".Normalize(NormalizationForm.FormD), "oe".Normalize(NormalizationForm.FormD) },
            { "Ö".Normalize(NormalizationForm.FormD), "Oe".Normalize(NormalizationForm.FormD) },
            { "ü".Normalize(NormalizationForm.FormD), "ue".Normalize(NormalizationForm.FormD) },
            { "Ü".Normalize(NormalizationForm.FormD), "Ue".Normalize(NormalizationForm.FormD) },
            { "ß".Normalize(NormalizationForm.FormD), "ss".Normalize(NormalizationForm.FormD) },
        };

        public static void ChangeGermanLetterEnumerable(this IEnumerable ediMessages) 
        {
            foreach (var ediMessage in ediMessages)
            {
                ChangeGermanLetterForObject(ediMessage);
            }

        }

        private static void ChangeGermanLetterForObject(object ediMessage)
        {
            PropertyInfo[] infos = ediMessage.GetType().GetProperties();
            foreach (var info in infos)
            {
                var objValue = info.GetValue(ediMessage);
                if (objValue?.GetType() == typeof(string))
                {
                    info.SetValue(ediMessage, ((string)objValue).ReplaceAndRemoveDiacritics());
                }
                else if(objValue is IList)
                    ((IList)objValue).ChangeGermanLetterEnumerable();
      
            }
        }
     

        public static string ReplaceAndRemoveDiacritics(this string s)
        {
            var stringBuilder = new StringBuilder(s.Normalize(NormalizationForm.FormD));

            // Replace certain special chars with special combinations of ascii chars (eg. german umlauts and german double s)
            foreach (KeyValuePair<string, string> keyValuePair in SPECIAL_DIACRITICS)
                stringBuilder.Replace(keyValuePair.Key, keyValuePair.Value);

            // Remove other diacritic chars eg. non spacing marks https://www.compart.com/en/unicode/category/Mn
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                char c = stringBuilder[i];

                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                    stringBuilder.Remove(i, 1);
            }

            return stringBuilder.ToString();
        }
    }
}
