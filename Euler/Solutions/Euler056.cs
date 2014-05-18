using System.Numerics;

namespace Euler.Solutions
{
    class Euler056 : Euler
    {
        public override long Exec()
        {
            var sol = 0;
            for (var a = 1; a < 100; a++)
            {
                BigInteger test = 1;
                for (var b = 1; b < 100; b++)
                {
                    test *= a;
                    var ds = DigitSum(test);
                    if (ds > sol)
                        sol = ds;
                }
            }
            return sol;
        }
    }
}
