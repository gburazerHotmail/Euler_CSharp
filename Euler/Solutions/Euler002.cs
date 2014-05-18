namespace Euler.Solutions
{
    class Euler002 : IEuler
    {
        public long Exec()
        {
            var sum = 0;
            var prev = 1;
            var cur = 1;
            while (cur < 4000000)
            {
                if (cur % 2 == 0)
                    sum += cur;
                var tmp = cur;
                cur += prev;
                prev = tmp;
            }
            return sum;
        }
    }
}
