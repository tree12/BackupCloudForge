using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ATom.CommonBasics.Extension { 
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string str, string str2) {
            if (str == null && str2 == null) return true;
            if ((str == null && str2 != null) || (str !=null && str2==null)) return false;
            return str.ToLower().Equals(str2.ToLower());
        }

        public static bool EqualsNullsafe(this string str, string str2) {
            if (str == str2) return true;
            if (str == null || str2 == null) return false;
            return str.Equals(str2);
        }

        public static string FormatWithCulture(this object value,string format)
        { 
            return string.Format(CultureInfo.GetCultureInfo("de-DE"), format,value);
        }

        public static string Fields(this string strString, params object[] objParameters)
        {
            return string.Format(strString, objParameters);
        }

		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsFilled(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string ReplaceCharAt(this string str,int index, char c) {
            char[] ca = str.ToCharArray();
            ca[index] = c;
            return new string(ca);
        }

        public static string Format(this string text,object arg)
        {
            return string.Format(text, arg);
        }
        public static string Format(this string text, object arg,object arg2)
        {
            return string.Format(text, arg,arg2);
        }

        public static string Format(this string text, object arg, object arg2,object arg3)
        {
            return string.Format(text, arg, arg2,arg3);
        }

        public static string[] ExtractBetweenParenthesis(this string str, char openPar, char closingPar) {
            int firstOpenPar = -1;
            int nesting = 0;
            List<string> retList=new List<string>();
            for (int i = 0; i < str.Length; i++) {
                if (openPar == str[i]) {
                    if (firstOpenPar == -1) firstOpenPar = i;
                    else nesting++;
                } else if (closingPar == str[i]) {
                    if (nesting > 0) nesting--;
                    else if (firstOpenPar >= 0) {
                        retList.Add(str.Substring(firstOpenPar+1, i - firstOpenPar-1));
                        firstOpenPar = -1;
                    }                 
                }
            }                            
            return retList.ToArray();
        }

        public static string TruncateAtWord(this string input, int length,bool putDots=true)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = input.LastIndexOf(" ", length);
            return string.Format(putDots?"{0}...":"{0}"
        , input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }

        public static string TruncateAt(this string input, int length, bool putDots = true)
        {
            if (input == null || input.Length < length)
                return input;
            int iNextSpace = putDots ? length : length - 3;
            return string.Format(putDots ? "{0}..." : "{0}"
        , input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }

        public static string TruncateAtChar(this string input, char c) {
            char[] a = input.ToCharArray();
            int i = Array.IndexOf<char>(a,c);
            if (i < 0) return input;
            else return input.Substring(0, i);
        }

    }
}
