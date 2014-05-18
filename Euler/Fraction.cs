using System;
using System.Numerics;

namespace Euler
{
    public class Fraction<T> : Tuple<T, T>
    {
        protected Fraction(T n, T d)
            : base(n, d)
        {
        }

        public Fraction<T> Reciprocal()
        {
            return new Fraction<T>(Item2, Item1);            
        }

    }

    public class IntFraction : Fraction<int>
    {
        public IntFraction(int n, int d) : base(n, d)
        {
        }

        public IntFraction(int n) : base(n, 1)
        {
        }

        public static IntFraction Sum(Fraction<int> f1, Fraction<int> f2)
        {
            var res = new IntFraction(f1.Item1 * f2.Item2 + f1.Item2 * f2.Item1, f1.Item2 * f2.Item2);
            var gcd = Euler.Gcd(res.Item2, res.Item1);
            return new IntFraction(res.Item1 / gcd, res.Item2 / gcd);
        }
    }

    public class BigIntegerFraction : Fraction<BigInteger>
    {
        private BigIntegerFraction(BigInteger n, BigInteger d) : base(n, d)
        {
        }

        public BigIntegerFraction(BigInteger n) : base(n, 1)
        {
        }

        public static BigIntegerFraction Sum(Fraction<BigInteger> f1, Fraction<BigInteger> f2)
        {
            var res = new BigIntegerFraction(f1.Item1 * f2.Item2 + f1.Item2 * f2.Item1, f1.Item2 * f2.Item2);
            var gcd = Euler.Gcd(res.Item2, res.Item1);
            return new BigIntegerFraction(res.Item1 / gcd, res.Item2 / gcd);
        }
    }
}
