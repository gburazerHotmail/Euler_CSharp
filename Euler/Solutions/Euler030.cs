using System.Linq;

namespace Euler.Solutions
{
    class Euler030 : IEuler
    {
        public long Exec()
        {
            _digitPot = Enumerable.Range(0, 10).Select(n =>
                Enumerable.Range(1, 5)
                    .Aggregate(1, (p, i) => p*n))
                .ToArray();
            return Enumerable.Range(10, 600000 - 10).Where(IsSol).Sum();
        }

        private static int[] _digitPot;

        private static bool IsSol(int n)
        {
            var digitSum = 0;
            foreach (var c in n.ToString())
            {
                digitSum += _digitPot[int.Parse(c.ToString())];
                if (digitSum > n)
                    return false;
            }
            return digitSum == n;
        }
    }
}
