using System.Linq;

namespace Euler.Solutions
{
    class Euler039 : IEuler
    {
        public long Exec()
        {
            const int limit = 1000;
            var p = new int[limit + 1];
            for (var a = 1; a <= limit / 2; a++)
                for (var b = a; b <= limit / 2; b++)
                    for (var c = 1; a + b + c <= limit; c++)
                        if (a*a + b*b == c*c)
                            p[a + b + c]++;
            return p.ToList().FindIndex(i => i == p.Max());
        }
    }
}
