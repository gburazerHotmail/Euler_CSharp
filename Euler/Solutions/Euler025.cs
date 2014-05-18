using System.Numerics;

namespace Euler.Solutions
{
    class Euler025 : IEuler
    {
        public long Exec()
        {
            BigInteger prev = 1,
                cur = 1;
            var sol = 2;
            for (; cur.ToString().Length < 1000; sol++)
            {
                var tmp = cur;
                cur += prev;
                prev = tmp;
            }
            return sol;
        }
    }
}
