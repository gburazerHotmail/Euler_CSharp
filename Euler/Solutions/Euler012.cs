namespace Euler.Solutions
{
    class Euler012 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(100);

            long t = 3;
            for (int n = 3, d = 0; d <= 500; t += n++, d = NumDivisors(t))
            {
            }
            return t;
        }

        private static int NumDivisors(long n)
        {
            var multExp = 1;
            foreach (var prime in Primes)
                if (n%prime == 0)
                {
                    var exp = 1;
                    long candidate = prime*prime;
                    while (n%candidate == 0)
                    {
                        candidate *= prime;
                        exp++;
                    }
                    multExp *= exp + 1;
                }
            return multExp;
        }
    }
}
