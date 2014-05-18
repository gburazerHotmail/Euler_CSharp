using System.Linq;

namespace Euler.Solutions
{
    class Euler035 : Euler
    {
        public override long Exec()
        {
            SievePrimes(10 * Limit);
            var count = 1; // 2
            for (var n = 3; n < Limit; n += 2)
                if (!NotPrime[n])
                {
                    var digits = n.ToString()
                        .Select(c => int.Parse(c.ToString()))
                        .ToArray();
                    if (digits.Where(d => d%2 == 0).Any() || (digits.Length > 2 && digits.Where(d => d == 5).Any()))
                        continue;
                    if (AllRotationsPrime(n, digits.Length))
                        count++;
                }
            return count;
        }

        private const int Limit = 1000000;

        private static bool AllRotationsPrime(int n, int digitCount)
        {
            var newn = n;
            for (var rot = 1; rot < digitCount; rot++)
            {
                newn = MyPow10(digitCount - 1)*(newn%10) + newn/10;
                if (NotPrime[newn])
                    return false;
            }
            return true;
        }

        private static int MyPow10(int n)
        {
            return Enumerable.Range(1, n).Aggregate(1, (p, i) => 10*p);
        }
    }
}
