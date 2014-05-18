using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    class Euler036 : IEuler
    {
        public long Exec()
        {
            return Enumerable.Range(1, 1000000)
                .Where(n => IsPalindrome(n.ToString()) && IsPalindrome(ReverseBase2(n)))
                .Sum();
        }

        private static bool IsPalindrome(string s)
        {
            return Enumerable.Range(0, s.Length/2).All(i => s[i] == s[s.Length - i - 1]);
        }

        private static string ReverseBase2(int n)
        {
            var ret = new StringBuilder();
            while (n > 0)
            {
                ret.Append(n % 2);
                n /= 2;
            }
            return ret.ToString();
        }
    }
}
