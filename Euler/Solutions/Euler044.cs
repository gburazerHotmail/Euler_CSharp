using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler044 : IEuler
    {
        public long Exec()
        {
            var set = new HashSet<int>(Enumerable.Range(1, 2500).Select(n => n*(3*n - 1)/2));
            var D = int.MaxValue;
            foreach (var p1 in set)
                foreach (var p2 in set)
                {
                    var d = Math.Abs(p1 - p2);
                    if (set.Contains(d) && set.Contains(p1 + p2) && d < D)
                        D = d;
                }
            return D;
        }
    }
}
