using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler042 : Euler
    {
        public override long Exec()
        {
            PrecalcTn();
            return InputText.Split(new[] { ',' })
                .Count(word => IsTriangleWord(word.Skip(1).Take(word.Length - 2).ToArray()));
        }
        private const int Limit = 100;
        private static readonly int[] Tn = new int[Limit];

        private static void PrecalcTn()
        {
            for (var n = 1; n <= Limit; n++)
                Tn[n - 1] = n * (n + 1) / 2;
        }

        private static bool IsTriangleWord(IEnumerable<char> word)
        {
            var sum = word.Sum(c => c - 'A' + 1);

            if (sum > Tn[Limit - 1])
                throw new NotImplementedException("Premali limit!");

            for (var i = Limit; i >= 1 && sum <= Tn[i - 1]; i--)
                if (Tn[i - 1] == sum)
                    return true;

            return false;
        }
    }
}
