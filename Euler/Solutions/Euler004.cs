using System.Linq;

namespace Euler.Solutions
{
    class Euler004 : IEuler
    {
        public long Exec()
        {
            var max = 0;
            for (var n1 = 999; n1 >= 100; n1--)
                for (var n2 = n1 - 1; n2 >= 100; n2--)
                {
                    var p = n1 * n2;
                    if (p > max && IsPalindrome(p))
                        max = p;
                }
            return max;
        }

        private static bool IsPalindrome(int n)
        {
            return n.ToString() == new string(n.ToString().Reverse().ToArray());
        }
    }
}
