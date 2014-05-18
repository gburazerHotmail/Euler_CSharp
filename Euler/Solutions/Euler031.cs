namespace Euler.Solutions
{
    class Euler031 : IEuler
    {
        public long Exec()
        {
            return CalcWays(Limit, 7);
        }

        private const int Limit = 200;
        private static readonly long[,] Ways = new long[Limit + 1, 8];
        private static readonly int[] Den = {1, 2, 5, 10, 20, 50, 100, 200};

        private static long CalcWays(int n, int startInd)
        {
            if (n < 0 || startInd < 0)
                return 0;

            if (Ways[n, startInd] > 0)
                return Ways[n, startInd];

            if (n == 0 || startInd == 0)
                return 1;

            long res = 0;
            for (var count = 0; count <= n/Den[startInd]; count++)
                res += CalcWays(n - count*Den[startInd], startInd - 1);

            Ways[n, startInd] = res;
            return res;
        }
    }
}
