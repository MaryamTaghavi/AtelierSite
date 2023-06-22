namespace Atelier.Application.Converters
{
    public static class ChangeNumber
    {
        public static string ToEnglishNumber(this string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return number;

            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            for (int j = 0; j < persian.Length; j++)
                number = number.Replace(persian[j], j.ToString());

            return number;

        }

        public static string ToPersianNumber(this string input)
        {
            string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int j = 0; j < persian.Length; j++)
            {
                input = input.Replace(j.ToString(), persian[j]);
            }
            return input;
        }

        public static bool IsNumber(this string stringNumber)
        {
            int numericValue;
            return int.TryParse(stringNumber, out numericValue);
        }

    }
}
