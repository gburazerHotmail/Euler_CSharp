using System.Linq;

namespace Euler.Solutions
{
    class Euler387 : Euler
    {
        public override long Exec()
        {
            return Enumerable.Range(1, 9).AsParallel().Select(n => Solve(n, 1, n)).Sum();
        }

        protected long Solve(long n, int digitCount, int digitSum)
        {
            if (digitCount + 1 > DigitCountLimit || n % digitSum > 0)
                return 0L;

            var res = 0L;
            if (IsPrime(n / digitSum))
                for (var lastDigit = 1; lastDigit <= 9; lastDigit += 2)
                {
                    var candidate = n * 10 + lastDigit;
                    if (IsPrime(candidate))
                        res += candidate;
                }

            for (var d = 0; d < 10; d++)
                res += Solve(10 * n + d, digitCount + 1, digitSum + d);
            return res;
        }

        protected const int DigitCountLimit = 14;
    }
}
