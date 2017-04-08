using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler022 : Euler
    {
        public override long Exec()
        {
            var names = new List<string>(InputText.Replace("\"", "").Split(','));
            names.Sort(AlphabeticalCompare);
            return names.Select((t, i) => (i + 1)*t
                .Aggregate<char, long>(0, (current, c) => current + (c - 'A' + 1)))
                .Sum();
        }

        private static int AlphabeticalCompare(string s1, string s2)
        {
            for (var i = 0; i < s1.Length; i++)
                if (i >= s2.Length)
                    return 1;
                else if (s1[i] < s2[i])
                    return -1;
                else if (s1[i] > s2[i])
                    return 1;
            if (s2.Length > s1.Length)
                return -1;
            return 0;
        }
    }
}
