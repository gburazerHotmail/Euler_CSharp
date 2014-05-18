namespace Euler.Solutions
{
    class Euler058 : Euler
    {
        public override long Exec()
        {
            int cur = 0, primes = 0, total = 1, skip = 1;
            do
            {
                skip += 2;
                total += 4;
                for (var i = 0; i < 4; i++, cur += skip - 1)
                    if (IsPrime(cur + skip))
                        primes++;
            } while ((double) primes/total > 0.1);
            return skip;
        }
    }
}
