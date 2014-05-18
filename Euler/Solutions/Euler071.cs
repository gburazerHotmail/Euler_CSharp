using System;

namespace Euler.Solutions
{
    class Euler071 : IEuler
    {
        public long Exec()
        {
            var pivot = new Tuple<long, long>(3, 7);
            var res = new Tuple<long, long>(0, 1);
            for (var d = 2L; d <= 1000000L; d++)
            {
                var n = pivot.Item1*(d/pivot.Item2) - 1;
                if (n * res.Item2 > d * res.Item1)
                    res = new Tuple<long, long>(n, d);
            }
            return res.Item1;
        }
    }
}
