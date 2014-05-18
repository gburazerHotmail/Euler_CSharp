using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler052 : IEuler
    {
        public long Exec()
        {
            for (var n = 1; ; n++)
            {
                var d2N = Digits(2*n);
                if (!AreEqual(d2N, Digits(3*n))
                    || !AreEqual(d2N, Digits(4*n))
                    || !AreEqual(d2N, Digits(5*n))
                    || !AreEqual(d2N, Digits(6*n)))
                    continue;
                return n;
            }
        }

        private static bool AreEqual(IList<int> d1, IList<int> d2)
        {
            return Enumerable.Range(0, 10).All(i => d1[i] == d2[i]);
        }

        private static int[] Digits(int n)
        {
            var d = new int[10];
            while (n > 0)
            {
                d[n % 10]++;
                n /= 10;
            }
            return d;
        }
    }
}
