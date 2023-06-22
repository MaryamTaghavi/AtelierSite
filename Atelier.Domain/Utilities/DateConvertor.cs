using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Domain.Utilities
{
    public static class DateConvertor

    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00") + " " + pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0");
        }

        public static string ToShamsiLabel(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0") + " " +
                   pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00");
        }

        public static string ToShamsiDate(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" +
                   pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("0");
        }



        public static DateTime ToDateTime(this string dateTime)
        {
            var p = new PersianCalendar();
            string[] parts = dateTime.Split(new[] { '/', '-' });
            return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0, 0,
                0, 0);
        }


        public static DateTime ToDateTime(this string dateTime, string time)
        {
            var p = new PersianCalendar();
            string[] parts = dateTime.Split(new[] { '/', '-' });
            string[] times = time.Split(":");
            return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), Convert.ToInt32(times[0]), Convert.ToInt32(times[1]),
                Convert.ToInt32(times[2]), 0);
        }



        public static DateTime ToDateTime(this DateTime dateTime, TimeSpan? timeSpan)
        {
            var finalDateTime = timeSpan == null ? dateTime : new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, timeSpan.Value.Hours, timeSpan.Value.Minutes, 0);

            return finalDateTime;
        }




        public static string ToMiladi(this DateTime value)
        {
            GregorianCalendar pc = new GregorianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00") + " " +
                   pc.GetHour(value) + ":" + pc.GetMinute(value).ToString("00") + ":" +
                   pc.GetSecond(value).ToString("00");
            ;
        }

        public static DateTime? ToGregorianDate(this string dateTime)
        {
            try
            {
                if (string.IsNullOrEmpty(dateTime))
                    return null;

                PersianCalendar p = new PersianCalendar();

                string[] parts = dateTime.Split(new[] { '/', '-' });
                return p.ToDateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]), 0,
                    0, 0, 0);
            }
            catch (Exception e)
            {
                var date = Convert.ToDateTime(dateTime);
                var change = date.ToString("yyyy/MM/dd");
                var day1 = Convert.ToInt32(change.Substring(8, 2));
                var mon1 = Convert.ToInt32(change.Substring(5, 2));
                var year1 = Convert.ToInt32(change.Substring(0, 4));
                var pc = new PersianCalendar();
                change = (pc.ToDateTime(year1, mon1, day1, 0, 0, 0, 0).ToString("yyyy/MM/dd").Substring(0, 10));
                return Convert.ToDateTime(change);
            }
        }

        public static string GetDay(this DateTime date)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    {
                        return "جمعه";
                    }
                case DayOfWeek.Monday:
                    {
                        return "دوشنبه";
                    }
                case DayOfWeek.Saturday:
                    {
                        return "شنبه";
                    }
                case DayOfWeek.Sunday:
                    {
                        return "یکشنبه";
                    }
                case DayOfWeek.Thursday:
                    {
                        return "پنچشنبه";
                    }
                case DayOfWeek.Wednesday:
                    {
                        return "چهارشنبه";
                    }
                case DayOfWeek.Tuesday:
                    {
                        return "سه شنبه";
                    }
                default:
                    {
                        return "هیچ";
                    }
            }

        }

        public static string GetMonth(this int month, int year)
        {
            return month switch
            {
                1 => "فروردین" + year,
                2 => "اردیبهشت" + year,
                3 => "خرداد" + year,
                4 => "تیر" + year,
                5 => "مرداد" + year,
                6 => "شهریور" + year,
                7 => "مهر" + year,
                8 => "آبان" + year,
                9 => "آذر" + year,
                10 => "دی" + year,
                11 => "بهمن" + year,
                12 => "اسفند" + year,
                _ => ""
            };
        }

        public static ValueTuple<DateTime, DateTime, string> GetRangeDate(this int month, int year)
        {

            switch (month)
            {
                case 1:
                    {
                        var startDate = year + "/01/01";
                        var endDate = year + "/02/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "فروردین" + year);
                    }
                case 2:
                    {
                        var startDate = year + "/02/01";
                        var endDate = year + "/03/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "اردیبهشت" + year);
                    }
                case 3:
                    {
                        var startDate = year + "/03/01";
                        var endDate = year + "/04/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "خرداد" + year);
                    }
                case 4:
                    {
                        var startDate = year + "/04/01";
                        var endDate = year + "/05/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "تیر" + year);
                    }
                case 5:
                    {
                        var startDate = year + "/05/01";
                        var endDate = year + "/06/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "مرداد" + year);
                    }
                case 6:
                    {
                        var startDate = year + "/05/01";
                        var endDate = year + "/06/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "شهریور" + year);
                    }
                case 7:
                    {
                        var startDate = year + "/06/01";
                        var endDate = year + "/07/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "مهر" + year);
                    }
                case 8:
                    {
                        var startDate = year + "/08/01";
                        var endDate = year + "/09/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "آبان" + year);
                    }
                case 9:
                    {
                        var startDate = year + "/09/01";
                        var endDate = year + "/10/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "آذر" + year);
                    }
                case 10:
                    {
                        var startDate = year + "/10/01";
                        var endDate = year + "/11/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "دی" + year);
                    }
                case 11:
                    {
                        var startDate = year + "/11/01";
                        var endDate = year + "/12/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "بهمن" + year);
                    }
                case 12:
                    {
                        var startDate = year + "/12/01";
                        var endDate = year + 1 + "" + "/01/01";
                        return ValueTuple.Create(startDate.ToDateTime(), endDate.ToDateTime().AddDays(-1), "اسفند" + year);
                    }
                default:
                    return ValueTuple.Create(DateTime.Now, DateTime.Now, "");
            }
        }
    }
}
