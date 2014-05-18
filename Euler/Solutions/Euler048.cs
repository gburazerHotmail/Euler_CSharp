namespace Euler.Solutions
{
    class Euler048 : IEuler
    {
        public long Exec()
        {
            const int limit = 1000;
            const long mod = 10000000000;
            long sol = 0;
            for (long n = 1; n <= limit; n++)
            {
                long pow = 1;
                for (long exp = 1; exp <= n; exp++)
                    pow = (pow * n) % mod;
                sol = (sol + pow) % mod;
            }
            return sol;
        }
    }
}
