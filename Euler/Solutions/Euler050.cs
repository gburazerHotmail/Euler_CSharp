namespace Euler.Solutions
{
    class Euler050 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(1000000);

            var sol = Primes[0];
            var maxLen = 0;
            var primeCount = Primes.Count;
            for (var p1 = 0; p1 < primeCount; p1++)
            {
                var sum = Primes[p1];
                for (var len = 2; len < primeCount - p1; len++)
                {
                    sum += Primes[p1 + len - 1];
                    if (sum >= PrimeSieveLimit)
                        break;
                    if (len <= maxLen || NotPrime[sum]) continue;
                    maxLen = len;
                    sol = sum;
                }
            }
            return sol;
        }
    }
}
