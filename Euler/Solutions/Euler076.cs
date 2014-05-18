using System;

namespace Euler.Solutions
{
    class Euler076 : IEuler
    {
        private const int Limit = 100;
        private static readonly long[,] CalcCache = new long[Limit + 1, Limit + 1];

        public long Exec()
        {
            return Calc(Limit, Limit - 1);
        }

        private static long Calc(int m, int n)
        {
            if (m <= 1 || n <= 1)
                return 1;
            if (CalcCache[m, n] > 0)
                return CalcCache[m, n];

            long res = 0;
            for (var i = Math.Min(m, n); i > 0; i--)
                res += Calc(m - i, Math.Min(n, i));
            CalcCache[m, n] = res;
            return res;
        }
    }
}
