using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EdiFabric.Core.Model.Edi.Edifact;
using EdiFabric.Core.Model.Edi.ErrorContexts;
using EdiFabric.Templates.EdifactD96A;
using Microsoft.EntityFrameworkCore;

namespace EDI.DataAccess.Entities
{
    public static class EdiExtensions
    {
        public static NumberFormatInfo NumberFormat = new NumberFormatInfo { NumberDecimalSeparator = "." };

        public static string EscapeForEdi(this string str)
        {
            return Regex.Replace(str, "(\\n)|(\\s{2,})|[^ a-zA-Z0-9,\\.\\-]", "");
        }
        public static DateTime asDateTime(this S004 soo4)
        {
            return DateTime.ParseExact(soo4.Date_1 + soo4.Time_2,"yyMMddHHmm", CultureInfo.InvariantCulture);
        }
        public static DateTime asDateTime(this EdiFabric.Templates.EdifactD96A.C507 c507)
        {
            return DateTime.ParseExact(c507.Datetimeperiod_02, c507.Datetimeperiodformatqualifier_03=="203"? "yyyyMMddHHmm": "yyyyMMdd", CultureInfo.InvariantCulture);
        }
        private static string AsString(this DataElementErrorContext dataElementErrorContext)
        {
            return $"Code: {dataElementErrorContext.Code} ComponentPosition: {dataElementErrorContext.ComponentPosition} Name: {dataElementErrorContext.Name} Value: {dataElementErrorContext.Value}";

        }
        public static string AsString(this SegmentErrorContext segmentErrorContext)
        {
            return $"Name: {segmentErrorContext.Name} Value: {segmentErrorContext.Value} Position: {segmentErrorContext.Position} Error: {string.Join("\n",(segmentErrorContext.Errors.Select(x=>x.AsString())))}";
        }
        public static string LimitStringLength(this string inputText, int length, int initIndex=0)
        {
            if (inputText == null) return string.Empty;
            return inputText.Trim().Length > length ? inputText.Trim().Substring(initIndex, length) : inputText.Trim();
        }
        
        public static void GenC080FromText(this C080 c080, string inputMessage)
        {

            string[] outputFields = { c080.Partyname_01, c080.Partyname_02, c080.Partyname_03, c080.Partyname_04, c080.Partyname_05 };
            AssignSplitString(ref inputMessage, ref outputFields);
            c080.Partyname_01 = outputFields[0];
            c080.Partyname_02 = outputFields[1];
            c080.Partyname_03 = outputFields[2];
            c080.Partyname_04 = outputFields[3];
            c080.Partyname_05 = outputFields[4];
        }
        public static void GenC059FromText(this C059 c059, string inputMessage)
        {

            string[] outputFields = { c059.Streetandnumberpobox_01, c059.Streetandnumberpobox_02, c059.Streetandnumberpobox_03, c059.Streetandnumberpobox_04 };
            AssignSplitString(ref inputMessage, ref outputFields);
            c059.Streetandnumberpobox_01 = outputFields[0];
            c059.Streetandnumberpobox_02 = outputFields[1];
            c059.Streetandnumberpobox_03 = outputFields[2];
            c059.Streetandnumberpobox_04 = outputFields[3];
        }

        public static void GenC058FromText(this C058 c058, string inputMessage)
        {
            string[] outputFields = {c058.Nameandaddressline_01, c058.Nameandaddressline_02, c058.Nameandaddressline_03, c058.Nameandaddressline_04, c058.Nameandaddressline_05 };
            AssignSplitString(ref inputMessage, ref outputFields);
            c058.Nameandaddressline_01 = outputFields[0];
            c058.Nameandaddressline_02 = outputFields[1];
            c058.Nameandaddressline_03 = outputFields[2];
            c058.Nameandaddressline_04 = outputFields[3];
            c058.Nameandaddressline_05 = outputFields[4];
        }

        public static void GenC273FromText(this C273 c273, string inputMessage)
        {
            string[] outputFields = { c273.Itemdescription_04, c273.Itemdescription_05 };
            AssignSplitString(ref inputMessage, ref outputFields);
            c273.Itemdescription_04 = outputFields[0];
            c273.Itemdescription_05 = outputFields[1];
        }
        public static void GenC110FromText(this C110 c110, string inputMessage)
        {
            string[] outputFields = { c110.Termsofpayment_04, c110.Termsofpayment_05 };
            AssignSplitString(ref inputMessage, ref outputFields);
            c110.Termsofpayment_04 = outputFields[0];
            c110.Termsofpayment_05 = outputFields[1];
        }
        //not use now but I want to keep
        public static void GenC108FromText(this C108 c108, string inputMessage)
        {
            string[] outputFields = { c108.Freetext_01, c108.Freetext_02, c108.Freetext_03, c108.Freetext_04, c108.Freetext_05 };
            AssignSplitString(ref inputMessage, ref outputFields,70);
            c108.Freetext_01 = outputFields[0];
            c108.Freetext_02 = outputFields[1];
            c108.Freetext_03 = outputFields[2];
            c108.Freetext_04 = outputFields[3];
            c108.Freetext_05 = outputFields[4];
        }

        public static string GenStringFromC080(this C080 c080)
        {
            string outputString = string.Empty;
            if (!string.IsNullOrEmpty(c080?.Partyname_01))
            {
                outputString += c080?.Partyname_01;
            }
            if (!string.IsNullOrEmpty(c080?.Partyname_02))
            {
                outputString += c080?.Partyname_02;
            }
            if (!string.IsNullOrEmpty(c080?.Partyname_03))
            {
                outputString += c080?.Partyname_03;
            }
            if (!string.IsNullOrEmpty(c080?.Partyname_04))
            {
                outputString += c080?.Partyname_04;
            }
            if (!string.IsNullOrEmpty(c080?.Partyname_05))
            {
                outputString += c080?.Partyname_05;
            }

            return outputString;
        }
        public static string GenStringFromC059(this C059 c059)
        {
            string outputString = string.Empty;
            if (!string.IsNullOrEmpty(c059?.Streetandnumberpobox_01))
            {
                outputString += c059?.Streetandnumberpobox_01;
            }
            if (!string.IsNullOrEmpty(c059?.Streetandnumberpobox_02))
            {
                outputString += c059?.Streetandnumberpobox_02;
            }
            if (!string.IsNullOrEmpty(c059?.Streetandnumberpobox_03))
            {
                outputString += c059?.Streetandnumberpobox_03;
            }
            if (!string.IsNullOrEmpty(c059?.Streetandnumberpobox_04))
            {
                outputString += c059?.Streetandnumberpobox_04;
            }

            return outputString;
        }
        public static string GenStringFromC058(this C058 c058)
        {
            string outputString = string.Empty;
            if (!string.IsNullOrEmpty(c058?.Nameandaddressline_01))
            {
                outputString += c058?.Nameandaddressline_01;
            }
            if (!string.IsNullOrEmpty(c058?.Nameandaddressline_02))
            {
                outputString += c058?.Nameandaddressline_02;
            }
            if (!string.IsNullOrEmpty(c058?.Nameandaddressline_03))
            {
                outputString += c058?.Nameandaddressline_03;
            }
            if (!string.IsNullOrEmpty(c058?.Nameandaddressline_04))
            {
                outputString += c058?.Nameandaddressline_04;
            }
            if (!string.IsNullOrEmpty(c058?.Nameandaddressline_05))
            {
                outputString += c058?.Nameandaddressline_05;
            }

            return outputString;
        }
        //not use now but I want to keep
        public static string GenStringFromC108(this C108 c108)
        {
            string outputString = string.Empty;
            if (!string.IsNullOrEmpty(c108?.Freetext_01))
            {
                outputString += c108?.Freetext_01;
            }
            if (!string.IsNullOrEmpty(c108?.Freetext_02))
            {
                outputString += c108?.Freetext_02;
            }
            if (!string.IsNullOrEmpty(c108?.Freetext_03))
            {
                outputString += c108?.Freetext_03;
            }
            if (!string.IsNullOrEmpty(c108?.Freetext_04))
            {
                outputString += c108?.Freetext_04;
            }
            if (!string.IsNullOrEmpty(c108?.Freetext_05))
            {
                outputString += c108?.Freetext_05;
            }

            return outputString;
        }


        private static void AssignSplitString(ref string inputMessage, ref string[] outputFields, int length = 35)
        {
            if (!string.IsNullOrEmpty(inputMessage))
            {
                for (int i=0; i< outputFields.Length; ++i)
                {
                    //if the message chunks are less than the outputFields containers, we stop processing.
                    if (inputMessage.Length <= length * i) break;

                    if (outputFields.Length <= (i + 1))
                    {
                        outputFields[i] = inputMessage.LimitStringLength(inputMessage.Length - (length * i), length * i);
                    }
                    else
                    {
                        outputFields[i] = inputMessage.LimitStringLength((inputMessage.Length - (length * i) < length ? inputMessage.Length - (length * i) : length), length * i);
                    }
                }
                
            }
            
        }

    }
    public static class DbSetExtensions
    {
        public static bool AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return exists;//!exists ? dbSet.Add(entity) : null;
        }

    }
    public class EdiException : Exception
    {
        public EdiException()
        {
        }

        protected EdiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EdiException(string? message) : base(message)
        {
        }

        public EdiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
