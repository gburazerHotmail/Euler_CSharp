using System;
using System.Linq;

namespace Euler.Solutions
{
    class Euler357 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(100000000);
            return 1 + Primes.AsParallel().Select(p => Satisfies(p - 1) ? p - 1 : 0L).Sum();
        }

        private bool Satisfies(int n)
        {
            if (n % 4 != 2)
                return false;

            for (var d = 2; d * d <= n; d++)
                if (n % d == 0 && !IsPrimeUsingPrimes(d + n / d))
                    return false;

            return true;
        }
    }
}
