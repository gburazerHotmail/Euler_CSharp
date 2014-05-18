using System.Collections.Generic;

namespace Euler.Solutions
{
    class Euler038 : IEuler
    {
        public long Exec()
        {
            long sol = 0;
            for (var n = 2; n <= 9; n++)
            {
                long resnum = 0;
                for (var k = 1; resnum < 1000000000; k++)
                {
                    var res = "0";
                    for (var i = 1; i <= n; i++)
                        res += (k * i).ToString();
                    resnum = long.Parse(res);
                    if (Is9Pandigital(resnum) && resnum > sol)
                        sol = resnum;
                }
            }
            return sol;
        }

        private static bool Is9Pandigital(long n)
        {
            if (n <= 99999999 || n >= 1000000000)
                return false;

            var digits = new HashSet<int>();
            while (n > 0)
            {
                var digit = (int)(n % 10);
                if (digit == 0 || digits.Contains(digit))
                    return false;
                digits.Add(digit);
                n /= 10;
            }

            return true;
        }

    }
}
