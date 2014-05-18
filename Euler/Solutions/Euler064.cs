using System;
using System.Linq;

namespace Euler.Solutions
{
    class Euler064 : IEuler
    {
        public long Exec()
        {
            const int limit = 10000;
            return Enumerable.Range(1, limit).Count(n => PeriodLen(n) % 2 == 1);
        }

        // http://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
        private static int PeriodLen(int n)
        {
            var sqrt = Math.Sqrt(n);
            if (!(sqrt%1 > 0)) return 0; // perfect square
            var periodLen = 0;
            double m = 0, d = 1;
            var a0 = Math.Floor(sqrt);
            var a = a0;
            while (2*a0 - a > double.Epsilon)
            {
                m = d*a - m;
                d = (n - m*m)/d;
                a = Math.Floor((a0 + m)/d);
                periodLen++;
            }
            return periodLen;
        }
    }
}
