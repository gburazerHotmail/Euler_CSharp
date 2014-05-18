namespace Euler.Solutions
{
    class Euler015 : IEuler
    {
        public long Exec()
        {
            const int limit = 20;
            var sol = new long[limit + 1, limit + 1];

            for (var i = 1; i <= limit; i++)
                sol[0, i] = sol[i, 0] = 1;

            for (var i = 1; i <= limit; i++)
                for (var j = 1; j <= limit; j++)
                    sol[i, j] = sol[i - 1, j] + sol[i, j - 1];

            return sol[limit, limit];
        }
    }
}
