using System.Linq;

namespace Euler.Solutions
{
    class Euler010 : Euler
    {
        public override long Exec()
        {
            SievePrimes(2000000);
            return NotPrime.AsEnumerable()
                .Select((np, i) => new { np, i })
                .Where(n => n.np == false)
                .Select(x => (long)x.i)
                .Sum();
        }
    }
}
