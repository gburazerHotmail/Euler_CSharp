using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler059 : Euler
    {
        public override long Exec()
        {
            var cipherText = new string(File.ReadAllText(FilePath("Euler059.txt"))
                .Split(',').Select(int.Parse).Select(c => (char) c).ToArray());

            return ValidChars().SelectMany(c1 =>
                ValidChars().SelectMany(c2 =>
                    ValidChars().Select(
                        c3 => new string(new[] {c1, c2, c3}))
                        .Select(pwd => Decipher(cipherText, pwd))
                        .Where(IsEnglishText)))
                .First().Sum(c => (int) c);
        }

        private static IEnumerable<char> ValidChars()
        {
            return Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char) c);
        }

        private static string Decipher(string cipherText, string pwd)
        {
            var len = cipherText.Length;
            var res = new char[len];
            for (var ind = 0; ind < len; ind++)
                res[ind] = (char) (cipherText[ind] ^ pwd[ind%pwd.Length]);
            return new string(res);
        }

        private static bool IsEnglishText(string text)
        {
            return text.Split(' ').Count(w => w == "in" || w == "to" || w == "and" || w == "from") > 5;
        }
    }
}
