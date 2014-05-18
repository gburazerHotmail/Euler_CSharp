using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
    class Euler049 : Euler
    {
        public override long Exec()
        {
            const int limit = 10000;
            SievePrimes(10000);

            for (var p1 = limit / 10; p1 < limit; p1++)
                if (!NotPrime[p1])
                    for (var p2 = p1 + 2; p2 < limit; p2++)
                        if (!NotPrime[p2])
                        {
                            var d = p2 - p1;
                            if (p1 != 1487 && p2 + d < limit && !NotPrime[p2 + d] && SameDigits(p1, d))
                                return long.Parse(p1.ToString() + p2 + (p2 + d));
                        }
            throw new NotImplementedException();
        }

        private static bool SameDigits(int p1, int d)
        {
            var dc = DigitsCount(p1);
            return EqualDigitCount(dc, DigitsCount(p1 + d)) && EqualDigitCount(dc, DigitsCount(p1 + d + d));
        }

        private static int[] DigitsCount(int n)
        {
            var ret = new int[10];
            while (n > 0)
            {
                ret[n%10]++;
                n /= 10;
            }
            return ret;
        }

        private static bool EqualDigitCount(IList<int> dc1, IList<int> dc2)
        {
            for (var i = 0; i < 10; i++)
                if (dc1[i] != dc2[i])
                    return false;
            return true;
        }
    }
}
