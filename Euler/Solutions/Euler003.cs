namespace Euler.Solutions
{
    class Euler003 : Euler
    {
        public override long Exec()
        {
            var num = 600851475143;
            var sol = 0;
            for (var cur = 3; cur * 2 < num; cur += 2)
                if (IsPrime(cur) && num % cur == 0)
                {
                    num /= cur;
                    if (cur > sol)
                        sol = cur;
                }
            return IsPrime(num) ? num : sol;
        }
    }
}
