using System.Linq;

namespace Euler.Solutions
{
    class Euler057 : Euler
    {
        public override long Exec()
        {
            return Enumerable.Range(1, 1000).Count(n =>
            {
                var fraction = IntFraction.Sum(new IntFraction(1), SeriesRek(n).Reciprocal());
                return DigitCount(fraction.Item1) > DigitCount(fraction.Item2);
            });
        }

        private static IntFraction SeriesRek(int n)
        {
            return n == 1
                ? new IntFraction(2)
                : IntFraction.Sum(new IntFraction(2), SeriesRek(n - 1).Reciprocal());
        }
    }
}
