using System.Linq;

namespace Euler.Solutions
{
    class Euler023 : IEuler
    {
        public long Exec()
        {
            const int limit = 28123;
            var a = Enumerable.Range(1, limit).Where(IsAbundant).ToArray();
            var sieve = new bool[limit + 1];
            for (var n1 = 0; n1 < a.Length - 1; n1++)
                for (var n2 = n1; n2 < a.Length; n2++)
                {
                    var sum = a[n1] + a[n2];
                    if (sum <= limit)
                        sieve[sum] = true;
                }
            return sieve.Select((b, i) => !b ? i : 0).Sum();
        }

        private static bool IsAbundant(int n)
        {
            var divsum = 1;
            for (var i = 2; i <= n / 2; i++)
                if (n % i == 0)
                    divsum += i;
            return divsum > n;
        }
    }
}
