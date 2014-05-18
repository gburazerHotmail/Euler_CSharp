using System.Numerics;

namespace Euler.Solutions
{
    class Euler053 : IEuler
    {
        public long Exec()
        {
            const int limit = 100;
            var fact = new BigInteger[limit + 1];
            fact[0] = 1;
            for (var i = 1; i <= limit; i++)
                fact[i] = i*fact[i - 1];

            var sol = 0;
            for (var n = 1; n <= 100; n++)
                for (var r = 1; r <= n; r++)
                {
                    var c = fact[n]/(fact[r]*fact[n - r]);
                    if (c > 1000000)
                        sol++;
                }
            return sol;
        }
    }
}
