namespace Euler.Solutions
{
    class Euler041 : Euler
    {
        public override long Exec()
        {
            long limit = 0;
            for (var i = 0; i < N; i++)
                limit = limit * 10 + N;

            for (var i = limit; i > 0; i--)
                if (IsPandigital(i) && IsPrime(i))
                    return i;
            return 0;
        }

        private const int N = 7;

        private static bool IsPandigital(long n)
        {
            var digits = new bool[N + 1];
            var count = 0;
            while (n > 0)
            {
                count++;
                var d = n % 10;
                if (d > N || d == 0 || digits[d])
                    return false;
                digits[d] = true;
                n /= 10;
            }
            return (count == N);
        }
    }
}
