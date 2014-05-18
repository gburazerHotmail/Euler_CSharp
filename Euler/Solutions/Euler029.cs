using System.Collections.Generic;
using System.Numerics;

namespace Euler.Solutions
{
    class Euler029 : IEuler
    {
        public long Exec()
        {
            const int limit = 100;
            var res = new HashSet<BigInteger>();
            for (var a = 2; a <= limit; a++)
                for (var b = 2; b <= limit; b++)
                    res.Add(Pow(a, b));
            return res.Count;
        }

        static BigInteger Pow(int a, int b)
        {
            var res = new BigInteger(a);
            for (var i = 1; i < b; i++)
                res *= a;
            return res;
        }
    }
}
