using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler074 : IEuler
    {
        private const int Limit = 1000000;
        private static readonly long[] Next = new long[Limit];

        public long Exec()
        {
            return Enumerable.Range(0, Limit).AsParallel().Count(n => Len(n) == 60);
        }

        private static int Len(long n)
        {
            var visited = new HashSet<long>();
            while (!visited.Contains(n))
            {
                visited.Add(n);
                if (n < Limit)
                {
                    var lck = new object();
                    lock (lck)
                    {
                        if (Next[n] == 0)
                            Next[n] = CalcNext(n);
                        n = Next[n];
                    }
                }
                else
                    n = CalcNext(n);
            }
            return visited.Count;
        }

        private static readonly long[] Fact = {1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880};
        private static long CalcNext(long n)
        {
            var res = 0L;
            while (n > 0)
            {
                res += Fact[n%10];
                n /= 10;
            }
            return res;
        }
    }
}
