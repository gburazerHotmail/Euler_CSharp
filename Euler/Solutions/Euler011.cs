using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    class Euler011 : Euler
    {
        public override long Exec()
        {
            var lineInd = 0;
            foreach (var line in InputLines)
            {
                var colInd = 0;
                foreach (var n in line.Split(' ').Select(int.Parse))
                    Grid[lineInd, colInd++] = n;
                lineInd++;
            }

            var max = 0;
            for (var i = 0; i < N; i++)
                for (var j = 0; j < N; j++)
                    max = new[]
                    {
                        max,
                        Sum4(i, j, N - 3, 0, N, 1, 0),
                        Sum4(i, j, N, 0, N - 3, 0, 1),
                        Sum4(i, j, N - 3, 0, N - 3, 1, 1),
                        Sum4(i, j, N - 3, 3, N, 1, -1)
                    }.Max();
            return max;
        }

        private const int N = 20;
        private static readonly int[,] Grid = new int[N, N];

        private static int Sum4(int i, int j, int up1, int lo2, int up2, int inc1, int inc2)
        {
            return (i < up1 && j >= lo2 && j < up2)
                ? Grid[i, j] * Grid[i + inc1, j + inc2] * Grid[i + inc1 * 2, j + inc2 * 2] * Grid[i + inc1 * 3, j + inc2 * 3]
                : 0;
        }
    }
}
