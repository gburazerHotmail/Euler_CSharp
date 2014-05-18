using System.Linq;

namespace Euler.Solutions
{
    class Euler028 : IEuler
    {
        public long Exec()
        {
            Dir[0, 0] =  0; Dir[0, 1] =  1; // right
            Dir[1, 0] =  1; Dir[1, 1] =  0; // down
            Dir[2, 0] =  0; Dir[2, 1] = -1; // left
            Dir[3, 0] = -1; Dir[3, 1] =  0; // up

            Mat[Size, Size] = 1;

            var i = Size;
            var j = Size;
            var dirInd = 3;
            for (var n = 2; n <= Limit * Limit; n++)
            {
                var newDirInd = (dirInd + 1) % 4;
                if (CanTurn(i, j, newDirInd))
                    dirInd = newDirInd;
                i += Dir[dirInd, 0];
                j += Dir[dirInd, 1];
                Mat[i, j] = n;
            }

            return Enumerable.Range(0, Limit).Select(e => Mat[e, e] + Mat[e, Limit - e - 1]).Sum() - 1;
        }

        private const int Size = 500;
        private const int Limit = 2 * Size + 1;
        private static readonly int[,] Mat = new int[Limit, Limit];
        private static readonly int[,] Dir = new int[4, 2];

        private static bool CanTurn(int i, int j, int dirInd)
        {
            var newi = i + Dir[dirInd, 0];
            if (newi < 0 || newi >= Limit)
                return false;
            var newj = j + Dir[dirInd, 1];
            if (newj < 0 || newj >= Limit)
                return false;
            return 0 == Mat[newi, newj];
        }
    }
}
