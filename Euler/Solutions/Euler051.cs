using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    class Euler051 : Euler
    {
        public override long Exec()
        {
            const int limit = 1000000;
            SievePrimes(limit);
            var pow10 = 10;
            for (_n = 2; _n < limit; _n++)
                if (!NotPrime[_n])
                {
                    if (_n/pow10 > 0)
                    {
                        _digitCount++;
                        pow10 *= 10;
                    }
                    for (var howMany = 1; howMany < _digitCount; howMany++)
                    {
                        var count = CountMaxPrimesInReplacements(howMany, new HashSet<int>());
                        if (count > 0)
                            return count;
                    }
                }
            throw new NotImplementedException();
        }

        private static int _n;
        private static int _digitCount = 1;

        private static long CountMaxPrimesInReplacements(int howMany, ISet<int> digitIndToChange)
        {
            if (howMany == 0)
            {
                var family = new HashSet<int>();
                for (var digit = 0; digit <= 9; digit++)
                {
                    var test = ReplaceDigits(digitIndToChange, digit);
                    if (NotPrime[test]) continue;
                    family.Add(test);
                }
                if (family.Count == 8)
                    return family.Min();
            }

            for (var newDigitIndToChange = digitIndToChange.Count == 0 ? 0 : digitIndToChange.Max() + 1;
                newDigitIndToChange < _digitCount;
                newDigitIndToChange++)
            {
                digitIndToChange.Add(newDigitIndToChange);
                var count = CountMaxPrimesInReplacements(howMany - 1, digitIndToChange);
                if (count > 0)
                    return count;
                digitIndToChange.Remove(newDigitIndToChange);
            }

            return 0;
        }

        private static int ReplaceDigits(ICollection<int> digitIndToChange, int digit)
        {
            if (digitIndToChange.Contains(0) && digit == 0)
                return 0;

            var str = _n.ToString().ToCharArray();
            foreach (var ind in digitIndToChange)
                str[ind] = (char)(digit + '0');
            return int.Parse(new string(str));
        }
    }
}
