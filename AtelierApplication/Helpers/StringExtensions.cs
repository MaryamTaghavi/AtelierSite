using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier.Application.Helpers
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string str)
        {
            return string.IsNullOrWhiteSpace(str)|| str=="null" ? 0 : decimal.Parse(str.Replace("/", "."), CultureInfo.InvariantCulture.NumberFormat);
        }
        public static decimal ToDecimal(this decimal number)
        {
            string str = number.ToString();
            return decimal.Parse(str.Replace("/" , "."), CultureInfo.InvariantCulture.NumberFormat);
        }  
        public static decimal ToDecimal(this int number)
        {
            string str = number.ToString();
            return decimal.Parse(str.Replace("/" , "."), CultureInfo.InvariantCulture.NumberFormat);
        }
        public static double ToRoundDouble(this string str)
        {
            // str = str.Replace("/", ".");
            decimal number = decimal.Parse(str, CultureInfo.InvariantCulture.NumberFormat);

            double round = (double)(Math.Round((double)number, 3));
            return round;
        }

        public static IEnumerable<string> SplitByLength(this string str, int maxLength)
        {
            for (var index = 0; index < str.Length; index += maxLength)
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }


        public static string Fa2En(this string str)
        {
            return str
                .Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str
                .Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");
        }


        public const string PrintLabelError= "خطا در چاپ لیبل (لیبل در محصول انتخاب نشده است)";
    }
}
