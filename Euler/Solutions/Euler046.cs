using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
    class Euler046 : Euler
    {
        public override long Exec()
        {
            SievePrimes(Limit);
            FindSquares();

            for (var n = 9; n < Limit; n += 2)
                if (NotPrime[n])
                {
                    var isSol = true;
                    for (var i = 3; i < n; i += 2)
                        if (!NotPrime[i] && Squares.Contains((n - i)/2))
                        {
                            isSol = false;
                            break;
                        }
                    if (!isSol) continue;
                    return n;
                }
            throw new NotImplementedException();
        }

        private const int Limit = 10000;
        private static readonly HashSet<int> Squares = new HashSet<int>();

        private static void FindSquares()
        {
            for (var i = 1; ; i++)
            {
                var sq = i * i;
                if (sq >= Limit)
                    break;
                Squares.Add(sq);
            }
        }
    }
}
