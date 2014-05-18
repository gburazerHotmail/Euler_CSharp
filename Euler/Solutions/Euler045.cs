using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler045 : IEuler
    {
        public long Exec()
        {
            var tri = new HashSet<long>();
            var pet = new HashSet<long>();
            var hex = new HashSet<long>();
            for (long n = 1; n <= 100000; n++)
            {
                tri.Add(n*(n + 1)/2);
                pet.Add(n*(3*n - 1)/2);
                hex.Add(n*(2*n - 1));
            }
            return tri.First(t => t > 40755 && pet.Contains(t) && hex.Contains(t));
        }
    }
}
