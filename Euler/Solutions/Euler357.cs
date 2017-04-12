using System.Linq;

namespace Euler.Solutions
{
    class Euler357 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(100000000);
            return Primes.Aggregate(0L, (res, p) => res + (Satisfies(p - 1) ? p - 1 : 0));
        }

        private bool Satisfies(int n)
        {
            for (var d = 2; d * d <= n; d++)
                if (n % d == 0 && !IsPrimeUsingPrimes(d + n / d))
                    return false;

            return true;
        }
    }
}
