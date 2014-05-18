using System.Linq;
using System.Numerics;

namespace Euler.Solutions
{
    class Euler016 : IEuler
    {
        public long Exec()
        {
            var res = new BigInteger(1);
            for (var i = 1; i <= 1000; i++)
                res *= 2;
            return res.ToString().Sum(c => int.Parse(c.ToString()));
        }
    }
}
