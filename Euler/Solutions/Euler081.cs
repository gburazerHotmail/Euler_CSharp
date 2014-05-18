using System;

namespace Euler.Solutions
{
    class Euler081 : Euler
    {
        public override long Exec()
        {
            const int n = 80;
            var matrix = LoadMatrix(n, "Euler081.txt");
            for (var row = 0; row < n; row++)
                for (var col = 0; col < n; col++)
                {
                    var left = col > 0 ? matrix[row, col - 1] : long.MaxValue;
                    var up = row > 0 ? matrix[row - 1, col] : long.MaxValue;
                    if (row > 0 || col > 0)
                        matrix[row, col] += Math.Min(left, up);
                }
            return matrix[n - 1, n - 1];
        }
    }
}
