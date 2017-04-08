using System;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler099 : Euler
    {
        public override long Exec()
        {
            var ind = 0;
            var maxInd = 0;
            var maxBase = 1;
            var maxExp = 0;
            foreach (var pair in InputLines.Select(l => l.Split(','))
                .Select(p => new {Base = int.Parse(p[0]), Exp = int.Parse(p[1])}))
            {
                ind++;
                if (pair.Exp*Math.Log10(pair.Base) <= maxExp*Math.Log10(maxBase))
                    continue;
                maxBase = pair.Base;
                maxExp = pair.Exp;
                maxInd = ind;
            }
            return maxInd;
        }
    }
}
