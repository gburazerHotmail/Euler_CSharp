using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
    class Euler062 : IEuler
    {
        public long Exec()
        {
            var cubeCountByPerm = new Dictionary<long, Tuple<long, int>>();
            const int n = 5;
            for (var i = 1;; i++)
            {
                var cube = (long) i*i*i;
                var perm = CalcPerm(cube);
                if (cubeCountByPerm.ContainsKey(perm))
                {
                    var t = cubeCountByPerm[perm];
                    if (t.Item2 == n - 1)
                        return t.Item1;
                    cubeCountByPerm[perm] = new Tuple<long, int>(t.Item1, t.Item2 + 1);
                }
                else
                    cubeCountByPerm.Add(perm, new Tuple<long, int>(cube, 1));
            }
        }

        private static long CalcPerm(long n)
        {
            long ret = 0;
            while (n > 0)
            {
                ret += Pow10[n%10];
                n /= 10;
            }
            return ret;
        }

        private static readonly long[] Pow10 =
        {
            1,
            10,
            100,
            1000,
            10000,
            100000,
            1000000,
            10000000,
            100000000,
            1000000000
        };
    }
}
