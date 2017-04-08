using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler054 : Euler
    {
        public override long Exec()
        {
            return InputLines.Select(l => l.Split(' '))
                .Select(h => new {one = h.Take(5), two = h.Skip(5).Take(5)})
                .Count(h => PlayerOneWins(SortHand(h.one), SortHand(h.two)));
        }

        private static IList<string> SortHand(IEnumerable<string> hand)
        {
            return hand
                .OrderByDescending(card => Val(card[0]))
                .ToList();
        }

        private static int Val(char val)
        {
            int res;
            if (int.TryParse(new string(val, 1), out res))
                return res;
            switch (val)
            {
                case 'T':
                    return 10;
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                case 'A':
                    return 14;
            }
            throw new NotImplementedException();
        }

        private static bool PlayerOneWins(IList<string> one, IList<string> two)
        {
            var val1 = Val(one);
            var val2 = Val(two);
            return val1 > val2 ||
                   (val1 >= val2 &&
                    CompareHighest(
                        one.Select(c => Val(c[0])).ToList(), 
                        two.Select(c => Val(c[0])).ToList()));
        }

        private static bool CompareHighest(IList<int> one, IList<int> two)
        {
            for (var i = 0; i < 5; i++)
            {
                if (one[i] == two[i]) continue;
                return one[i] > two[i];
            }
            throw new NotImplementedException();
        }

        private static int Val(IEnumerable<string> hand)
        {
            var h = hand.Select(c => new {val = Val(c[0]), col = c[1]}).ToList();
            var col = h.First().col;
            var flush = h.Count(c => c.col == col) == 5;
            var straight = (h[0].val - 1 == h[1].val && h[1].val - 1 == h[2].val && h[2].val - 1 == h[3].val &&
                            h[3].val - 1 == h[4].val) ||
                           (h.First().val == 14 && h.Skip(1).First().val == 5 && h.Last().val == 2);

            // royal flush
            if (flush && straight && h.First().val == 14)
                return 900;

            // straight flush
            if (flush && straight)
                return 800;

            // four of a kind
            if (h[0].val == h[3].val)
                return 700 + h[0].val;
            if (h[1].val == h[4].val)
                return 700 + h[1].val;

            // full house
            if (h[0].val == h[2].val && h[3].val == h[4].val)
                return 600 + h[0].val;
            if (h[0].val == h[1].val && h[2].val == h[4].val)
                return 600 + h[2].val;

            // flush
            if (flush)
                return 500;

            // straight
            if (straight)
                return 400 + h[2].val;

            // three of a kind
            if (h[0].val == h[2].val)
                return 300 + h[0].val;
            if (h[1].val == h[3].val)
                return 300 + h[1].val;
            if (h[2].val == h[4].val)
                return 300 + h[2].val;

            // two pairs
            if (h[0].val == h[1].val && h[2].val == h[3].val)
                return 200 + h[0].val + h[2].val;
            if (h[0].val == h[1].val && h[3].val == h[4].val)
                return 200 + h[0].val + h[3].val;
            if (h[1].val == h[2].val && h[3].val == h[4].val)
                return 200 + h[1].val + h[3].val;

            // one pair
            if (h[0].val == h[1].val)
                return 100 + h[0].val;
            if (h[1].val == h[2].val)
                return 100 + h[1].val;
            if (h[2].val == h[3].val)
                return 100 + h[2].val;
            if (h[3].val == h[4].val)
                return 100 + h[3].val;

            // high card
            return 0;
        }
    }
}
