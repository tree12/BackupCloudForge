using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace ATom.CommonBasics.Extension
{
    public static class DateTimeExtension
    {        

       

        public static DateTime Truncate(this DateTime dateTime, TimeSpan timeSpan)
        {
            if (timeSpan == TimeSpan.Zero) return dateTime; // Or could throw an ArgumentException
            return dateTime.AddTicks(-(dateTime.Ticks % timeSpan.Ticks));
        }

        /// <summary>
        /// 
        /// </summary> 
        public static int GetWeek(DateTime time)
        {
            System.Globalization.Calendar objCal = CultureInfo.CurrentCulture.Calendar;
            if (time.Day == 31 && time.Month == 12 && time.Year == 2007)
            {
                return 1;
            }
            if ((time.Day == 29 || time.Day == 30 || time.Day == 31) && time.Month == 12 && time.Year == 2008)
            {
                return 1;
            }
            if (time.Day == 31 && time.Month == 12 && time.Year == 2012)
            {
                return 1;
            }
            if (time.Day >= 30 && time.Month == 12 && time.Year == 2013)
            {
                return 1;
            }
            if (time.Day >= 29 && time.Month == 12 && time.Year == 2014)
            {
                return 1;
            }


            return objCal.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static bool EqualsNullSafe(this DateTime? date1, DateTime? date2)
        {
            if (date1 == null && date2 == null) return true;
            if (date1 == null || date2 == null) return false;
            return date1.Value.Equals(date2.Value);
        }

        public static bool EqualsNullSafe(this TimeSpan? date1, TimeSpan? date2)
        {
            if (date1 == null && date2 == null) return true;
            if (date1 == null || date2 == null) return false;
            return date1.Value.Equals(date2.Value);
        }

        public static DateTime GetDateOfWeek(int nWeek, int year)
        {
            DateTime dStart = new DateTime(year, 1, 4);
            int nDay = ((int)dStart.DayOfWeek + 6) % 7 + 1;
            DateTime dFirst = dStart.AddDays(1 - nDay);
            return dFirst.AddDays((nWeek - 1) * 7);
        }

        public static DateTime? GetWorkingDay(DateTime? now, bool next)
        {
            if (now.HasValue)
            {
                while (now.Value.DayOfWeek == DayOfWeek.Saturday || now.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    now = now.Value.AddDays(next ? 1 : -1);
                }
                return now;
            }
            return null;
        }

        public static int GetWeekCount(int year)
        {
            return GetDateOfWeek(1, year + 1).Subtract(GetDateOfWeek(1, year)).Days / 7;
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime GetDateTime(int year)
        {
            return new DateTime(year, 1, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime GetDateTime(int year, int week)
        {
            if (year > 2100)
            {
                year = DateTime.Now.Year;
            }
            double firstmonday = Monday(new DateTime(year, 1, 4));
            double dayofyear = (week - 1) * 7 + firstmonday + 1;

            DateTime t = new DateTime(year, 1, 1).AddDays(dayofyear);
            if (year == 2009 || year == 2015)
            {
                t = t.AddDays(-7);
            }
            int currentWeek = GetWeek(t);
            if (currentWeek == 1 && year != t.Year) return t;
            if (currentWeek > week)
            {
                while (currentWeek > week)
                {
                    t = t.AddDays(-7);
                    currentWeek--;
                }
            }
            else if (currentWeek < week)
            {
                while (currentWeek < week)
                {
                    t = t.AddDays(7);
                    currentWeek++;
                }
            }
            return t;

        }

        public static string GetWeekAndYear(DateTime? actualDeliveryDate)
        {
            if (actualDeliveryDate.HasValue)
            {
                return GetWeek(actualDeliveryDate.Value).ToString().PadLeft(2, '0') + "/" +
                       actualDeliveryDate.Value.Year;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime GetDateTime(int year, int week, DayOfWeek day)
        {
            if (year > 2100)
            {
                year = DateTime.Now.Year;
            }
            double firstmonday = Monday(new DateTime(year, 1, 4));
            double dayofyear = (week - 1) * 7 + firstmonday + 1;

            DateTime t = new DateTime(year, 1, 1).AddDays(dayofyear);
            if (year == 2009)
            {
                t = t.AddDays(-7);
            }
            if (year == 2015)
            {
                t = t.AddDays(-7);
            }




            return t.AddDays(GetIndex(day));

        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime GetDateTime(int year, int week, DayOfWeek day, int hour, int minute)
        {
            if (year > 2100)
            {
                year = DateTime.Now.Year;
            }
            double firstmonday = Monday(new DateTime(year, 1, 4));
            double dayofyear = (week - 1) * 7 + firstmonday + 1;

            DateTime t = new DateTime(year, 1, 1, hour, minute, 0).AddDays(dayofyear);
            if (year == 2009)
            {
                t = t.AddDays(-7);
            }
            if (year == 2015)
            {
                t = t.AddDays(-7);
            }
            return t.AddDays(GetIndex(day));

        }

        /// <summary>
        /// 
        /// </summary>
        public static int Monday(DateTime dt)
        {
            return dt.DayOfYear - (int)dt.DayOfWeek - 1;
        }


        /// <summary>
        /// 
        /// </summary>
        public static int GetMaxWeekCount(int year)
        {
            System.DateTime DateSearched = new DateTime(year, 12, 31, new GregorianCalendar());
            int weeksInYear;
            do
            {
                int week = GetWeek(DateSearched);
                switch (week)
                {
                    case 1:
                        DateSearched = DateSearched.AddDays(-1);
                        break;
                    case 53:
                        if (GetWeek(DateSearched.AddDays(7)) == 2)
                        {
                            weeksInYear = 52;
                        }
                        else
                        {
                            weeksInYear = 53;
                        }
                        return weeksInYear;
                    case 52:
                        weeksInYear = 52;
                        return weeksInYear;
                }
            }
            while (true);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetDayText(System.DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "Montag";
                case DayOfWeek.Tuesday: return "Dienstag";
                case DayOfWeek.Wednesday: return "Mittwoch";
                case DayOfWeek.Thursday: return "Donnerstag";
                case DayOfWeek.Friday: return "Freitag";
                case DayOfWeek.Saturday: return "Samstag";
                case DayOfWeek.Sunday: return "Sonntag";
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        public static DayOfWeek GetDayOfWeek(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Montag": return DayOfWeek.Monday;
                case "Dienstag": return DayOfWeek.Tuesday;
                case "Mittwoch": return DayOfWeek.Wednesday;
                case "Donnerstag": return DayOfWeek.Thursday;
                case "Freitag": return DayOfWeek.Friday;
                case "Samstag": return DayOfWeek.Saturday;
                case "Sonntag": return DayOfWeek.Sunday;
            }
            return DayOfWeek.Sunday;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int GetIndex(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return 0;
                case DayOfWeek.Tuesday: return 1;
                case DayOfWeek.Wednesday: return 2;
                case DayOfWeek.Thursday: return 3;
                case DayOfWeek.Friday: return 4;
                case DayOfWeek.Saturday: return 5;
                case DayOfWeek.Sunday: return 6;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static DayOfWeek GetDayOfWeek(int index)
        {
            switch (index)
            {
                case 0: return DayOfWeek.Monday;
                case 1: return DayOfWeek.Tuesday;
                case 2: return DayOfWeek.Wednesday;
                case 3: return DayOfWeek.Thursday;
                case 4: return DayOfWeek.Friday;
                case 5: return DayOfWeek.Saturday;
                case 6: return DayOfWeek.Sunday;
            }
            return 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public static DateTime Parse(string p)
        {
            try
            {
                return DateTime.Parse(p);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GetWeekAndYear(int oldYear, int oldWeek, ref int year, ref int week, int add)
        {
            DateTime d = GetDateTime(oldYear, oldWeek);
            d = d.AddDays(add * 7);
            year = d.Year;
            if (add > 0 && oldWeek > GetWeek(d) && GetWeek(d) == 1)
            {
                year++;
            }
            week = GetWeek(d);
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetDiffInDays(DateTime dateTime, DateTime dateTime_2)
        {
            long ticks1 = dateTime.Ticks;
            long ticks2 = dateTime_2.Ticks;
            ticks1 = ticks1 / 1000 / 10000 / 60;
            ticks2 = ticks2 / 1000 / 10000 / 60;
            double days = (ticks1 - ticks2) / 60 / (double)24;
            return Math.Round((double)days, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetDiffInDaysWithoutTime(DateTime dateTime, DateTime dateTime_2)
        {
            DateTime d1 = dateTime.Date;
            DateTime d2 = dateTime_2.Date;
            long ticks1 = d1.Ticks;
            long ticks2 = d2.Ticks;
            ticks1 = ticks1 / 1000 / 10000 / 60;
            ticks2 = ticks2 / 1000 / 10000 / 60;
            double days = (ticks1 - ticks2) / 60 / (double)24;
            return Math.Round((double)days, 2);
        }

        public static int CountDays(DateTime first, DateTime second)
        {
            DateTime d1 = new DateTime(first.Year, first.Month, first.Day, 0, 0, 0, 0);
            DateTime d2 = new DateTime(second.Year, second.Month, second.Day, 0, 0, 0, 0);

            return Math.Abs(d1.Subtract(d2).Days) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime? GetTime(string time)
        {
            try
            {
                return new Nullable<DateTime>(DateTime.ParseExact(time, "HH:mm", null));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool EqualsDay(DateTime? nullable, DateTime dateTime)
        {
            if (nullable.HasValue)
            {
                int y = nullable.Value.Year;
                int m = nullable.Value.Month;
                int d = nullable.Value.Day;
                if (y == dateTime.Year && m == dateTime.Month && d == dateTime.Day)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool EqualsDay(DateTime? first, DateTime? second)
        {
            if (first.HasValue && second.HasValue)
            {
                int y = first.Value.Year;
                int m = first.Value.Month;
                int d = first.Value.Day;
                if (y == second.Value.Year && m == second.Value.Month && d == second.Value.Day)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool EqualsDay(DateTime d1, DateTime d2)
        {
            int y = d1.Year;
            int m = d1.Month;
            int d = d1.Day;
            if (y == d2.Year && m == d2.Month && d == d2.Day)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int GetDayOfWeek(DayOfWeek wDay)
        {
            if (wDay == DayOfWeek.Monday)
            {
                return 1;
            }
            if (wDay == DayOfWeek.Tuesday)
            {
                return 2;
            }
            if (wDay == DayOfWeek.Wednesday)
            {
                return 3;
            }
            if (wDay == DayOfWeek.Thursday)
            {
                return 4;
            }
            if (wDay == DayOfWeek.Friday)
            {
                return 5;
            }
            if (wDay == DayOfWeek.Saturday)
            {
                return 6;
            }
            if (wDay == DayOfWeek.Sunday)
            {
                return 7;
            }
            return 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public static int GetDiffInMilliSecond(DateTime? dateTime, DateTime? dateTime_2)
        {
            if (dateTime.HasValue && dateTime_2.HasValue)
            {
                long ticks1 = dateTime.Value.Ticks;
                long ticks2 = dateTime_2.Value.Ticks;
                double t1 = ticks1 / 10000;
                double t2 = ticks2 / 10000;
                double days = (t1 - t2);
                return (int)Math.Round((double)days, 0);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetNeededTime(DateTime start)
        {
            return GetDiffInMilliSecond(DateTime.Now, start) + "";
        }

        public static DateTime? GetDateOfWeek(string value)
        {
            if (value.IsFilled())
            {
                if (value.IndexOf("/") > -1)
                {
                    string[] v = value.Split(new char[] { '/' });
                    if (v.Length == 2)
                    {
                        int week = 0;
                        int year = 0;
                        if (Int32.TryParse(v[0], out week))
                        {
                            if (Int32.TryParse(v[1], out year))
                            {
                                if (year < 100) year += 2000;
                                return GetDateOfWeek(week, year);
                            }
                        }
                    }
                }
                else
                {
                    int week = 0;
                    int year = DateTime.Now.Year;
                    if (Int32.TryParse(value, out week))
                    {
                        return GetDateOfWeek(week, year);
                    }
                }
            }
            return null;
        }


        /**
         * Überprüft ob ein Datum zwischen 2 anderen liegt. Das zweite Datum ist dabei nicht inklusive
         * */
        /// <summary>
        /// 
        /// </summary>
        public static bool IsDateBetween(DateTime toTest, DateTime first, DateTime second)
        {
            int toT = toTest.Year * 365 + toTest.DayOfYear;
            int f = first.Year * 365 + first.DayOfYear;
            int s = second.Year * 365 + second.DayOfYear;
            if (toT >= f && toT < s)
            {
                return true;
            }
            return false;
        }

        public static bool IsDateBetweenInclusive(DateTime toTest, DateTime first, DateTime second)
        {
            int toT = toTest.Year * 365 + toTest.DayOfYear;
            int f = first.Year * 365 + first.DayOfYear;
            int s = second.Year * 365 + second.DayOfYear;
            if (toT >= f && toT <= s)
            {
                return true;
            }
            return false;
        }

        public static bool IsTimeBetweenInclusive(DateTime toTest, DateTime first, DateTime second)
        {
            return (toTest.Ticks >= first.Ticks && toTest.Ticks <= second.Ticks);
        }

        public static int GetDiffInHours(DateTime dateTime, DateTime dateTime_2)
        {
            long ticks1 = dateTime.Ticks;
            long ticks2 = dateTime_2.Ticks;
            double t1 = ticks1 / 1000 / 10000 / 60;
            double t2 = ticks2 / 1000 / 10000 / 60;
            double days = (t1 - t2) / 60;
            return (int)Math.Round((double)days, 0);
        }

        public static double GetDiffInHoursWithHalf(DateTime dateTime, DateTime dateTime_2)
        {
            long ticks1 = dateTime.Ticks;
            long ticks2 = dateTime_2.Ticks;
            double t1 = ticks1 / 1000 / 10000 / 60;
            double t2 = ticks2 / 1000 / 10000 / 60;
            double days = (t1 - t2) / 60;
            double hours = Math.Round(days, 1);

            return hours;
        }

        public static double GetDiffInHoursDouble(DateTime dateTime, DateTime dateTime_2)
        {
            long ticks1 = dateTime.Ticks;
            long ticks2 = dateTime_2.Ticks;
            double t1 = ticks1 / 1000 / 10000 / 60;
            double t2 = ticks2 / 1000 / 10000 / 60;
            double days = (t1 - t2) / 60;
            return Math.Round((double)days, 2);
        }

        /// <summary>
        /// Berücksichtigt nur die Uhrzeit, NICHT den Tag!
        /// </summary>
        public static double GetDiffInHoursDouble_TimeOnly(DateTime dateFrom, DateTime dateTo)
        {
            DateTime from = new DateTime(1, 1, 1, dateFrom.Hour, dateFrom.Minute, dateFrom.Second);
            DateTime to = new DateTime(1, 1, 1, dateTo.Hour, dateTo.Minute, dateTo.Second);

            return GetDiffInHoursDouble(from, to) * -1;
        }

        public static double GetDiffInHoursDouble_TimeOnly(TimeSpan from, TimeSpan to)
        {
            DateTime dateFrom = new DateTime(1, 1, 1, from.Hours, from.Minutes, from.Seconds);
            DateTime dateTo = new DateTime(1, 1, 1, to.Hours, to.Minutes, to.Seconds);
            return GetDiffInHoursDouble(dateFrom, dateTo) * -1;
        }



        public static void WriteNeededTime(string p, DateTime now)
        {
            Console.WriteLine(p + ":" + GetDiffInMilliSecond(DateTime.Now, now));
        }

        public static DateTime GetWeekStart(DateTime dt)
        {
            int diff = dt.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime GetOnlyDayDate(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0, 0);
        }



        public static bool EqualsMonth(DateTime? validFrom, DateTime? receiptDate)
        {
            if (validFrom.HasValue && receiptDate.HasValue)
            {
                return validFrom.Value.Month == receiptDate.Value.Month &&
                       validFrom.Value.Year == receiptDate.Value.Year;
            }
            return false;
        }

        public static int CompareDays(DateTime dateTime, DateTime? dateTime2)
        {
            DateTime dt = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            if (dateTime2.HasValue)
            {
                DateTime dt2 = new DateTime(dateTime2.Value.Year, dateTime2.Value.Month, dateTime2.Value.Day, 0, 0, 0);
                return dt.CompareTo(dt2);
            }
            return -1;
        }

        public static DateTime Clone(DateTime end)
        {
            return new DateTime(end.Ticks);
        }

        public static int GetDaysInMonth(DateTime d)
        {
            return GetDaysInMonth(d.Year, d.Month);
        }

        public static int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static int GetDaysInYear(int year)
        {
            int days = 0;
            for (int i = 1; i <= 12; i++)
            {
                days += GetDaysInMonth(year, i);
            }
            return days;
        }

        public static bool IsOverlapping(DateTime? firstStart, DateTime? firstEnd, DateTime? secondStart, DateTime? secondEnd)
        {
            if (secondEnd.HasValue && secondStart.HasValue)
            {
                return firstStart.Value.CompareTo(secondEnd.Value) < 0 && firstEnd.Value.CompareTo(secondStart.Value) > 0;
            }
            return false;
        }

      

        internal static int GetFirstDayOfWeek(DateTime d)
        {
            while (d.DayOfWeek != DayOfWeek.Monday)
            {
                d = d.AddDays(-1);
            }
            return d.Day;
        }


        /// <summary>
        /// Gets the first day of week.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>the first day of the week</returns>
        public static DateTime GetFirstDayOfWeekDateTime(this DateTime dateTime)
        {
            while (dateTime.DayOfWeek != DayOfWeek.Monday)
                dateTime = dateTime.Subtract(new TimeSpan(1, 0, 0, 0));
            return dateTime.Date;
        }

        public static string[] GetMonthTexts()
        {
            string[] m = new string[12];

            for (int i = 0; i < 12; i++)
            {
                m[i] = string.Format("{0:MMMM}", new DateTime(2011, i + 1, 1));
            }
            return m;
        }


        public static int GetQuarter(this DateTime start)
        {
            if (start.Month < 4) return 1;
            else if (start.Month < 7) return 2;
            else if (start.Month < 10) return 3;
            else if (start.Month < 13) return 4;
            return 0;
        }
       

        public static string GetMonthText(DateTime dateTime)
        {
            return GetMonthTexts()[dateTime.Month - 1];
        }

        public static int GetAgeInYears(this DateTime dateTime)
        {
            int alter = DateTime.Now.Year - dateTime.Year;

            if (DateTime.Now.Month < dateTime.Month)
            {
                alter--;
            }
            else if (DateTime.Now.Month == dateTime.Month)
            {
                if (DateTime.Now.Day < dateTime.Day)
                    alter--;

            }
            return alter;
        }        

        public static DateTime GetLastDayDate(this DateTime dt)
        {
            int days = GetDaysInMonth(dt);
            return new DateTime(dt.Year, dt.Month, days);
        }

        /// <summary>
        /// Gets the last day of week.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>the last day of the week</returns>
        public static DateTime GetLastDayOfWeek(this DateTime dateTime)
        {
            while (dateTime.DayOfWeek != DayOfWeek.Sunday)
                dateTime = dateTime.AddDays(1);
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

   

        public static int GetPeriodAsInt(DateTime dateTime)
        {
            return int.Parse(dateTime.Year + "" + dateTime.Month.ToString().PadLeft(2, '0'));
        }

        public static bool IsLastDayOfMonth(this DateTime startDate)
        {
            DateTime next = startDate.AddDays(1);
            return next.Month != startDate.Month;
        }        
       
       
        public static DateTime? GetFirstDayOfMonth(this DateTime? startDate)
        {
            if (startDate.HasValue)
            {
                return new DateTime(startDate.Value.Year, startDate.Value.Month, 1, 0, 0, 0);
            }
            return null;
        }

        public static DateTime? GetLastDayOfMonth(this DateTime? startDate)
        {
            if (startDate.HasValue)
            {
                return GetLastDayDate(startDate.Value);
            }
            return null;
        }

        public static DateTime GetNextWorkingDay(this DateTime date, int workingDays)
        {
            DateTime next = date;
            next = next.AddDays(1);

            if (workingDays == 5)
            {
                if (next.DayOfWeek == DayOfWeek.Saturday)
                    next = next.AddDays(2);
            }

            if (next.DayOfWeek == DayOfWeek.Sunday)
                next = next.AddDays(1);

            return next;
        }

        public static DateTime GetLastWorkingDay(this DateTime date, int workingDays)
        {
            DateTime last = date;
            last = last.AddDays(-1);

            if (workingDays == 5)
            {
                if (last.DayOfWeek == DayOfWeek.Saturday)
                    last = last.AddDays(-1);
                if (last.DayOfWeek == DayOfWeek.Sunday)
                    last = last.AddDays(-2);
            }

            if (workingDays == 6 && last.DayOfWeek == DayOfWeek.Sunday)
                last = last.AddDays(-1);

            return last;
        }


        public static DateTime GetLastDayOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31);
        }


        static public string FormatDateTime(this DateTime? date, string strIfNull = "", bool showDateAlways = false)
        {
            if (date == null) return strIfNull;
            string format;
            if (date.Value.Date == DateTime.Today)
            {
                format = (showDateAlways ? "heute " : "") + string.Format("um {0:t}", date.Value);
            }
            else if (date.Value.Date == DateTime.Today.AddDays(-1))
            {
                format = string.Format("gestern um {0:t}", date.Value);
            }
            else if (date.Value.Date == DateTime.Today.AddDays(1))
            {
                format = string.Format("morgen um {0:t}", date.Value);
            }
            else
            {
                format = (showDateAlways ? "" : "am ") + string.Format("{0:d.MMM\\'yy} um {1:t}", date.Value, date.Value);
            }
            return format;
        }

        static public string FormatDate(this DateTime? date, string strIfNull = "")
        {
            if (date == null) return strIfNull;
            string format;
            if (date.Value.Date == DateTime.Today)
            {
                format = "heute";
            }
            else if (date.Value.Date == DateTime.Today.AddDays(-1))
            {
                format = string.Format("gestern");
            }
            else if (date.Value.Date == DateTime.Today.AddDays(+1))
            {
                format = string.Format("morgen");
            }
            else
            {
                format = string.Format("{0:d}", date.Value);
            }
            return format;
        }


       
    }
}
