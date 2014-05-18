namespace Euler.Solutions
{
    class Euler014 : IEuler
    {
        public long Exec()
        {
            Sol[1] = 1;
            var maxLen = 0;
            var maxLenN = 0;
            for (var i = 2; i < Limit; i++)
            {
                var len = Len(i);
                if (len <= maxLen) continue;
                maxLen = len;
                maxLenN = i;
            }
            return maxLenN;
        }

        private const int Limit = 1000000;
        private static readonly int[] Sol = new int[Limit];

        private static int Len(long n)
        {
            if (n < Limit)
            {
                if (Sol[n] != 0) return Sol[n];
                if (n % 2 == 0)
                    Sol[n] = 1 + Len(n / 2);
                else
                    Sol[n] = 1 + Len(3 * n + 1);
                return Sol[n];
            }
            if (n % 2 == 0)
                return 1 + Len(n / 2);
            return 1 + Len(3 * n + 1);
        }
    }
}
