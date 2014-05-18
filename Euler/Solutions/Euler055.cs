using System;
using System.Linq;
using System.Numerics;

namespace Euler.Solutions
{
    class Euler055 : IEuler
    {
        public long Exec()
        {
            return Enumerable.Range(1, 10000).Count(n => IsLychrel(n));
        }

        private static bool IsLychrel(BigInteger n)
        {
            var test = n;
            for (var it = 1; it <= 50; it++)
            {
                var arrrev = test.ToString().ToCharArray();
                Array.Reverse(arrrev);
                var nrev = BigInteger.Parse(new string(arrrev));
                if (it != 1 && test == nrev)
                    return false;
                test += nrev;
            }
            return true;
        }
    }
}
