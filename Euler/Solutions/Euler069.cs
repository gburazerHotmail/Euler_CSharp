using System;

namespace Euler.Solutions
{
    class Euler069 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(SqrN);
            var oldMax = 1;
            var max = 1;
            foreach (var p in Primes)
            {
                max *= p;
                if (max > N)
                    return oldMax;
                oldMax = max;
            }
            throw new InvalidOperationException();
        }

        private const int SqrN = 1000;
        private const int N = SqrN*SqrN;
    }
}
