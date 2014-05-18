using System.Linq;

namespace Euler.Solutions
{
    class Euler034 : IEuler
    {
        public long Exec()
        {
            var f = new[] {1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880};
            return Enumerable.Range(10, 1000000 - 10)
                .Where(n => n == n.ToString()
                    .Select(d => f[int.Parse(d.ToString())])
                    .Sum())
                .Sum();
        }
    }
}
