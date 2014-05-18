namespace Euler.Solutions
{
    class Euler047 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(500000);

            int lastFail;
            for (var n = 4; ; n = lastFail + 4)
                if (Has4(n))
                {
                    if (!Has4(n - 1))
                        lastFail = n - 1;
                    else if (!Has4(n - 2))
                        lastFail = n - 2;
                    else if (!Has4(n - 3))
                        lastFail = n - 3;
                    else
                        return n - 3; // lastFail + 1
                }
                else
                    lastFail = n;
        }

        private static bool Has4(int n)
        {
            var count = (n%2 == 0) ? 1 : 0;
            for (var i = 1; Primes[i]*2 <= n && count <= 4; i++)
                if (n%Primes[i] == 0)
                    count++;
            return (count == 4);
        }
    }
}
