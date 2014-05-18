using System.Linq;

namespace Euler.Solutions
{
    class Euler006 : IEuler
    {
        public long Exec()
        {
            const int limit = 100;
            var sum = Enumerable.Range(1, limit).Sum();
            return sum * sum - Enumerable.Range(1, limit).Aggregate(0, (s, n) => s + n * n);
        }
    }
}
