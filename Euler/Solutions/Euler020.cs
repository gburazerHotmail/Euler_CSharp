using System.Linq;
using System.Numerics;

namespace Euler.Solutions
{
    class Euler020 : IEuler
    {
        public long Exec()
        {
            var res = new BigInteger(1);
            for (var i = 2; i <= 100; i++)
                res *= i;
            return res.ToString().Sum(c => int.Parse(c.ToString()));
        }
    }
}
