using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    class Euler089 : Euler
    {
        public override long Exec()
        {
            return File.ReadAllLines(FilePath("Euler089.txt"))
                .Select(r => r.Length - Arabic2Roman(Roman2Arabic(r)).Length)
                .Sum();
        }

        private static readonly Dictionary<char, int> RomanDigits = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private static int Roman2Arabic(string r)
        {
            if (r == "")
                return 0;

            var largestDigit = 0;
            var largestDigitPos = -1;
            
            for (var pos = 0; pos < r.Length; pos++)
                if (RomanDigits[r[pos]] > largestDigit)
                {
                    largestDigit = RomanDigits[r[pos]];
                    largestDigitPos = pos;
                }

            return -Roman2Arabic(r.Substring(0, largestDigitPos)) 
                + largestDigit 
                + Roman2Arabic(r.Substring(largestDigitPos + 1, r.Length - largestDigitPos - 1));
        }

        private static string Arabic2Roman(int a)
        {
            var thousands = a/1000;
            a %= 1000;
            return new StringBuilder()
                .Append('M', thousands)
                .Append(RomanPart(100, ref a))
                .Append(RomanPart(10, ref a))
                .Append(RomanPart(1, ref a))
                .ToString();
        }

        private static string RomanPart(int unit, ref int a)
        {
            var amount = a/unit;
            a %= unit;

            var lo = unit == 100 ? 'C' : unit == 10 ? 'X' : 'I';
            var mi = unit == 100 ? 'D' : unit == 10 ? 'L' : 'V';
            var hi = unit == 100 ? 'M' : unit == 10 ? 'C' : 'X';

            if (amount >= 9)
                return new string(new[] {lo, hi});
            if (amount >= 5)
            {
                var ret = new StringBuilder(mi.ToString());
                ret.Append(lo, amount - 5);
                return ret.ToString();
            }
            return amount >= 4 ? new string(new []{lo, mi}) : new string(lo, amount);
        }
    }
}
