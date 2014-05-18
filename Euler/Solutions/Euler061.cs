using System.Linq;

namespace Euler.Solutions
{
    class Euler061 : IEuler
    {
        public long Exec()
        {
            var min = 0;
            for (var n = 1; min < Limit; n++)
            {
                min = n*(n + 1)/2;
                Update(0, min);
                Update(1, n*n);
                Update(2, n*(3*n - 1)/2);
                Update(3, n*(2*n - 1));
                Update(4, n*(5*n - 3)/2);
                Update(5, n*(3*n - 2));
            }
            return Solve(0);
        }

        private const int N = 6;
        private const int Limit = 10000;
        private const int LowLimit = Limit / 10;
        private static readonly bool[,] Is = new bool[6, 10*Limit];
        private static readonly bool[] IsUsed = new bool[Limit];
        private static readonly int[] Candidate = new int[N];
        private static readonly int[] IsCount = new int[6];

        private static void Update(int i, int n)
        {
            if (n >= Limit/10 && n < Limit)
                Is[i, n] = true;
        }

        private static long Solve(int level)
        {
            if (level == N)
                return IsSolution() ? Candidate.Sum() : 0;

            for (var n = LowLimit; n < Limit; n++)
                if (!IsUsed[n])
                {
                    Candidate[level] = n;
                    if (!Test(level)) continue;
                    Add(n);
                    var sol = Solve(level + 1);
                    if (sol > 0)
                        return sol;
                    Remove(n);
                }

            return 0;
        }

        private static bool Test(int level)
        {
            if (!AreCyclic(level))
                return false;

            var n = Candidate[level];
            for (var i = 0; i < 6; i++)
                if (Is[i, n])
                    return true;
            return false;
        }

        private static bool AreCyclic(int level)
        {
            return level == 0
                ||
                (
                    AreCyclic(Candidate[level - 1], Candidate[level])
                    && ((level != N - 1) || AreCyclic(Candidate[level], Candidate[0]))
                );
        }

        private static bool AreCyclic(int n1, int n2)
        {
            return n1%100 == n2/100;
        }

        private static void Add(int n)
        {
            IsUsed[n] = true;
            for (var i = 0; i < 6; i++)
                if (Is[i, n])
                    IsCount[i]++;
        }

        private static void Remove(int n)
        {
            IsUsed[n] = false;
            for (var i = 0; i < 6; i++)
                if (Is[i, n])
                    IsCount[i]--;
        }

        private static bool IsSolution()
        {
            if (!IsCount.All(i => i > 0))
                return false;
            for (var ind = 0; ind < N; ind++)
            {
                var n = Candidate[ind];
                Remove(n);
                var removesMoreThanOne = IsCount.Count(i => i == 0) > 1;
                Add(n);
                if (removesMoreThanOne)
                    return false;
            }
            return true;
        }
    }
}
