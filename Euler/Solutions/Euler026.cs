using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler026 : IEuler
    {
        public long Exec()
        {
            var maxLen = 0;
            var res = 0;
            for (var den = 2; den < 1000; den++)
            {
                var len = RecLen(den);
                if (len < maxLen) continue;
                maxLen = len;
                res = den;
            }
            return res;
        }

        private static int RecLen(int den)
        {
            var len = 0;
            var nomList = new List<int>();
            for (var nom = 10; nom > 0 && len < 10000; nom = 10 * (nom % den), len++)
            {
                for (var ind = 0; ind < nomList.Count; ind++)
                    if (nomList.ElementAt(ind) == nom)
                        return nomList.Count - ind;
                nomList.Add(nom);
            }
            return 0;
        }
    }
}
