using System.Numerics;

namespace Euler.Solutions
{
    class Euler063 : Euler
    {
        public override long Exec()
        {
            long res = 0;
            for (var n = 1; n <= 9; n++)
            {
                BigInteger candidate = 1;
                for (var pot = 1; pot < 25; pot++)
                {
                    candidate *= n;
                    if (candidate.ToString().Length == pot)
                        res++;
                }
            }
            return res;
        }
    }
}
