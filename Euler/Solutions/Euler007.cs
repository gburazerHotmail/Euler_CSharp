namespace Euler.Solutions
{
    class Euler007 : Euler
    {
        public override long Exec()
        {
            SievePrimes(1000000);
            var i = 2;
            for (var count = 1; count <= 10001; count++)
                while (NotPrime[i++])
                {
                }
            return i - 1;
        }
    }
}
