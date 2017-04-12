using System.Linq;

namespace Euler.Solutions
{
    class Euler060 : Euler
    {
        public override long Exec()
        {
            CalcPrimes(100000);
            return Solve(-1, 0);
        }

        private const int N = 5;
        private const int MaxPrimeInd = 1050;
        private static readonly int[] TestInd = new int[N];

        private static int Solve(int ind, int level)
        {
            if (level == N)
                return Enumerable.Range(0, N).Select(i => OddPrimes.Value[TestInd[i]]).Sum();
            for (var newInd = ind + 1; newInd < MaxPrimeInd - N + level + 1; newInd++)
            {
                TestInd[level] = newInd;
                if (!Test(level)) continue;
                var sol = Solve(newInd, level + 1);
                if (sol > 0)
                    return sol;
            }
            return 0;
        }

        private static bool Test(int newInd)
        {
            return Enumerable.Range(0, newInd).All(i => IsPrime(i, newInd) && IsPrime(newInd, i));
        }

        private static bool IsPrime(int ind1, int ind2)
        {
            return IsPrimeUsingPrimes(int.Parse(
                OddPrimes.Value[TestInd[ind1]].ToString() + OddPrimes.Value[TestInd[ind2]]));
        }
    }
}
