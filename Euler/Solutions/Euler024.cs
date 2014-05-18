using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    class Euler024 : IEuler
    {
        public long Exec()
        {
            return Permutation(new List<long> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, 1000000 - 1);
        }

        private static long Permutation(IList<long> list, int ind)
        {
            var sb = new StringBuilder();
            while (list.Count > 1)
            {
                var subPermCount = Fact(list.Count - 1);
                var curInd = ind/subPermCount;
                sb.Append(list.ElementAt(curInd));
                list.RemoveAt(curInd);
                ind %= subPermCount;
            }
            sb.Append(list.First());
            return long.Parse(sb.ToString());
        }

        private static int Fact(int n)
        {
            var res = 1;
            for (var i = 2; i <= n; i++)
                res *= i;
            return res;
        }
    }
}
