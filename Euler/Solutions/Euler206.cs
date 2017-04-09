using System;
using System.Linq;

namespace Euler.Solutions
{
    class Euler206 : IEuler
    {
        public long Exec()
        {
            return Enumerable.Range(Min, int.MaxValue - Min).First(n => IsMatch((long)n * n));
        }

        private static bool IsMatch(long n)
        {
            for (var i = 0; i < Digits.Length - 1; i++, n /= 100)
                if (n % 10 != Digits[i])
                    return false;

            return n == Digits[Digits.Length - 1];
        }

        private static readonly string Mask = "1_2_3_4_5_6_7_8_9_0";
        private static readonly int Min = (int) Math.Floor(Math.Sqrt(long.Parse(Mask.Replace("_", "0"))));
        private static readonly long[] Digits = Mask.Split('_').Select(d => long.Parse(d)).Reverse().ToArray();
    }
}
