using System;
using System.Linq;
using System.Threading.Tasks;

namespace Euler.Solutions
{
    class Euler206 : IEuler
    {
        public long Exec()
        {
            var res = 0L;
            Parallel.For(Min, Max, (n, loopState) => 
            {
                if (IsMatch((long)n*n))
                {
                    res = n;
                    loopState.Stop();
                }
            });
            return res;
        }

        private static bool IsMatch(long n)
        {
            for (var i = 0; i < Digits.Length - 1; i++, n /= 100)
                if (n % 10 != Digits[i])
                    return false;

            return n == Digits[Digits.Length - 1];
        }

        private static readonly string Mask = "1_2_3_4_5_6_7_8_9_0";
        private static readonly long[] Digits = Mask.Split('_').Select(d => long.Parse(d)).Reverse().ToArray();

        private static Func<Func<double, double>, string, int> CalcBoundary = 
            (op, d) => (int)op(Math.Sqrt(long.Parse(Mask.Replace("_", d))));

        private static readonly int Min = CalcBoundary(Math.Floor, "0");
        private static readonly int Max = CalcBoundary(Math.Ceiling, "9");
    }
}
