using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler032 : IEuler
    {
        public long Exec()
        {
            for (var d1 = 1; d1 <= 9; d1++)
                for (var d2 = 1; d2 <= 9; d2++)
                    if (d2 != d1)
                        for (var d3 = 1; d3 <= 9; d3++)
                            if (d3 != d1 && d3 != d2)
                                for (var d4 = 1; d4 <= 9; d4++)
                                    if (d4 != d1 && d4 != d2 && d4 != d3)
                                        for (var d5 = 1; d5 <= 9; d5++)
                                            if (d5 != d1 && d5 != d2 && d5 != d3 && d5 != d4)
                                                for (var d6 = 1; d6 <= 9; d6++)
                                                    if (d6 != d1 && d6 != d2 && d6 != d3 && d6 != d4 && d6 != d5)
                                                        for (var d7 = 1; d7 <= 9; d7++)
                                                            if (d7 != d1 && d7 != d2 && d7 != d3 && d7 != d4 && d7 != d5 && d7 != d6)
                                                                for (var d8 = 1; d8 <= 9; d8++)
                                                                    if (d8 != d1 && d8 != d2 && d8 != d3 && d8 != d4 && d8 != d5 && d8 != d6 && d8 != d7)
                                                                        for (var d9 = 1; d9 <= 9; d9++)
                                                                            if (d9 != d1 && d9 != d2 && d9 != d3 && d9 != d4 && d9 != d5 && d9 != d6 && d9 != d7 && d9 != d8)
                                                                                AddPandigitalProducts(new[] {d1, d2, d3, d4, d5, d6, d7, d8, d9});
            return Prods.Sum();
        }

        private static readonly HashSet<int> Prods = new HashSet<int>();

        private static void AddPandigitalProducts(IList<int> d)
        {
            // 1 * 2345 = 6789
            var f1 = d[0];
            var f2 = 1000 * d[1] + 100 * d[2] + 10 * d[3] + d[4];
            var prod = 1000 * d[5] + 100 * d[6] + 10 * d[7] + d[8];
            if (f1 * f2 == prod)
                Prods.Add(prod);

            // 12 * 345 = 6789
            f1 = 10 * d[0] + d[1];
            f2 = 100 * d[2] + 10 * d[3] + d[4];
            prod = 1000 * d[5] + 100 * d[6] + 10 * d[7] + d[8];
            if (f1 * f2 == prod)
                Prods.Add(prod);
        }
    }
}
