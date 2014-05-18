namespace Euler.Solutions
{
    class Euler037 : Euler
    {
        public override long Exec()
        {
            const int limit = 1000000;
            SievePrimes(limit);
            var sum = 0;
            for (var n = 10; n < limit; n++)
                if (IsTruncatable(n))
                    sum += n;
            return sum;
        }

        private static readonly int[] Pow10 = {1, 10, 100, 1000, 10000, 100000, 1000000};

        private static bool IsTruncatable(int p)
        {
            var newp = p;
            while (newp > 0)
            {
                if (NotPrime[newp])
                    return false;
                newp /= 10;
            }

            for (newp = p; newp > 0; newp = newp%Pow10[newp.ToString().Length - 1])
                if (NotPrime[newp])
                    return false;

            return true;
        }

    }
}
