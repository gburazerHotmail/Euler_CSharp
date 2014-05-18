using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler092 : IEuler
    {
        public long Exec()
        {
            return Enumerable.Range(1, 10000000).Count(ArrivesAt89);
        }

        private static readonly Dictionary<int, int> Map = new Dictionary<int, int>();

        private static bool ArrivesAt89(int n)
        {
            if (!Map.ContainsKey(n))
                Map[n] = Calc(n);
            var res = Map[n];
            while (res != 1 && res != 89 && Map.ContainsKey(res))
                res = Map[res];
            Map[n] = res;
            return res != 1 && ((res == 89) || ArrivesAt89(res));
        }

        private static int Calc(int n)
        {
            var res = 0;
            while (n > 0)
            {
                var digit = n%10;
                res += digit*digit;
                n /= 10;
            }
            return res;
        }
    }
}
