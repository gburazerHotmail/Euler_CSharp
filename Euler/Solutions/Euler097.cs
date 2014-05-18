namespace Euler.Solutions
{
    class Euler097 : IEuler
    {
        public long Exec()
        {
            return (28433 * MyPow2(7830457) + 1) % Mod;
        }

        private const long Mod = 10000000000;

        private static long MyPow2(int exp)
        {
            long res = 1;
            for (var i = 0; i < exp; i++)
            {
                res *= 2;
                res %= Mod;
            }
            return res;
        }
    }
}
