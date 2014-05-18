using System.IO;
using System.Linq;
using System.Numerics;

namespace Euler.Solutions
{
    class Euler013 : Euler
    {
        public override long Exec()
        {
            return long.Parse(File.ReadAllLines(FilePath("Euler013.txt"))
                .Aggregate<string, BigInteger>(0, (current, line) => current + BigInteger.Parse(line))
                .ToString()
                .Substring(0, 10));
        }
    }
}
