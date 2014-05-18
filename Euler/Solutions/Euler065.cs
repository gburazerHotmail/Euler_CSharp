using System.Numerics;

namespace Euler.Solutions
{
    class Euler065 : Euler
    {
        public override long Exec()
        {
            return DigitSum(ConvergentE(100).Item1);
        }

        private static BigIntegerFraction ConvergentE(int n)
        {
            return BigIntegerFraction.Sum(new BigIntegerFraction(2), ConvergentERek(1, n));
        }

        private static Fraction<BigInteger> ConvergentERek(int n, int limit)
        {
            return n >= limit
                ? new BigIntegerFraction(0)
                : BigIntegerFraction.Sum(
                    new BigIntegerFraction(n%3 == 2 ? 2*(1 + (n - 1)/3) : 1),
                    ConvergentERek(n + 1, limit)
                    ).Reciprocal();
        }
    }
}
