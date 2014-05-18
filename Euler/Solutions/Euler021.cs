namespace Euler.Solutions
{
    class Euler021 : IEuler
    {
        public long Exec()
        {
            var sum = 0;
            for (var a = 2; a < 10000; a++)
            {
                var da = d(a);
                if (da > a && d(da) == a)
                    sum += a + da;
            }
            return sum;
        }

        private static int d(int n)
        {
            var res = 0;
            for (var i = 1; i <= n / 2; i++)
                if (n % i == 0)
                    res += i;
            return res;
        }
    }
}
