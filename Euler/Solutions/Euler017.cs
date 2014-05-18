using System.Text;

namespace Euler.Solutions
{
    class Euler017 : IEuler
    {
        public long Exec()
        {
            var res = new StringBuilder();
            for (var i = 1; i <= 1000; i++)
                res.Append(Text(i));
            return res.Length;
        }

        private static readonly string[] One = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] Teen = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] Ten = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        private static string Text(int n)
        {
            if (n == 1000)
                return "onethousand";

            if (n < 10)
                return TextOne(n);

            if (n >= 100)
                return TextOne(n / 100) + "hundred" + (n % 100 > 0 ? ("and" + Text(n % 100)) : "");

            if (n % 10 == 0)
                return TextTen(n / 10);

            if (n < 20)
                return TextTeen(n);

            return TextTen(n / 10) + TextOne(n % 10);
        }

        private static string TextOne(int n)
        {
            return One[n];
        }

        private static string TextTeen(int n)
        {
            return Teen[n - 11];
        }

        private static string TextTen(int n)
        {
            return Ten[n - 1];
        }
    }
}
