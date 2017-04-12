using System;
using System.Linq;

namespace Euler
{
    class Triangle : Euler
    {
        public override long Exec()
        {
            Load(InputLines);
            Sum();
            return _triangle[0];
        }

        private static int[] _triangle;
        private static int _rowCount;

        private static void Load(string[] lines)
        {
            _rowCount = lines.Length;
            _triangle = new int[TotalElements(_rowCount)];
            var ind = 0;
            foreach (var num in lines.SelectMany(line => line.Split(' ')))
                _triangle[ind++] = int.Parse(num);
        }

        private static void Sum()
        {
            for (var row = _rowCount - 1; row >= 1; row--)
                for (var col = 1; col <= row; col++)
                    SetValue(row, col, GetValue(row, col) + Math.Max(GetValue(row + 1, col), GetValue(row + 1, col + 1)));
        }

        private static int GetValue(int row, int col)
        {
            return _triangle[TotalElements(row - 1) + col - 1];
        }

        private static void SetValue(int row, int col, int value)
        {
            _triangle[TotalElements(row - 1) + col - 1] = value;
        }

        private static int TotalElements(int rowCount)
        {
            return rowCount*(1 + rowCount)/2;
        }
    }
}
