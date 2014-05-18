using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Euler.Solutions
{
    class Euler096 : Euler
    {
        public override long Exec()
        {
            LoadBoards();
            InitSpots();
            Parallel.For(0, N, board => Solve(board, _availableSpots[board].Count));
            return Enumerable.Range(0, N).Sum(board =>
                100*_elements[board, 0, 0] + 10*_elements[board, 0, 1] + _elements[board, 0, 2]);
        }

        class Spot
        {
            public Spot(int row, int col)
            {
                Row = row;
                Col = col;
                Available = new HashSet<int>(Enumerable.Range(1, 9));
                Linked = new HashSet<Spot>();
            }

            public readonly int Row;
            public readonly int Col;
            public readonly HashSet<int> Available;
            public readonly HashSet<Spot> Linked;
        }

        private const int N = 50;
        private readonly int[,,] _elements = new int[N,9,9];
        private readonly Spot[,,] _spots = new Spot[N,9,9];
        private readonly HashSet<Spot>[] _availableSpots = new HashSet<Spot>[N];

        private void LoadBoards()
        {
            var lines = File.ReadAllLines(FilePath("Euler096.txt"));
            for (var board = 0; board < N; board++)
                for (var row = 0; row < 9; row++)
                    for (var col = 0; col < 9; col++)
                    {
                        var n = lines[board*10 + 1 + row][col] - '0';
                        _elements[board, row, col] = n;
                        if (n == 0)
                            _spots[board, row, col] = new Spot(row, col);
                    }
        }

        private void InitSpots()
        {
            for (var board = 0; board < N; board++)
            {
                _availableSpots[board] = new HashSet<Spot>();
                for (var row = 0; row < 9; row++)
                    for (var col = 0; col < 9; col++)
                        if (_elements[board, row, col] == 0)
                        {
                            var spot = _spots[board, row, col];
                            for (var i = 0; i < 9; i++)
                            {
                                Init(board, spot, i, col);
                                Init(board, spot, row, i);
                                Init(board, spot, 3*(row/3) + i/3, 3*(col/3) + i%3);
                            }
                            spot.Linked.Remove(spot);
                            _availableSpots[board].Add(spot);
                        }
            }
        }

        private void Init(int board, Spot spot, int row, int col)
        {
            var n = _elements[board, row, col];
            if (n == 0)
                spot.Linked.Add(_spots[board, row, col]);
            else
                spot.Available.Remove(n);
        }

        private bool Solve(int board, int left)
        {
            if (left == 0)
                return true;

            if (_availableSpots[board].Count == 0)
                return false;

            // TODO: MinBy()
            var spot = _availableSpots[board].First();
            foreach (var candidate in _availableSpots[board].Skip(1))
                if (candidate.Available.Count < spot.Available.Count ||
                    (candidate.Available.Count == spot.Available.Count && candidate.Linked.Count > spot.Linked.Count))
                    spot = candidate;

            var availableList = spot.Available.ToList();
            foreach (var n in availableList.Where(n => Place(board, spot, n)))
                if (Solve(board, left - 1))
                    return true;
                else
                    Remove(board, spot);

            return false;
        }

        private bool Place(int board, Spot spot, int n)
        {
            if (spot.Linked.Any(l => 
                _availableSpots[board].Contains(l) && 
                l.Available.Count == 1 && 
                l.Available.Single() == n))
                return false;

            var row = spot.Row;
            var col = spot.Col;
            _elements[board, row, col] = n;

            foreach (var linked in spot.Linked.Where(s => _availableSpots[board].Contains(s)))
                linked.Available.Remove(n);

            _availableSpots[board].Remove(spot);

            return true;
        }

        private void Remove(int board, Spot spot)
        {
            var row = spot.Row;
            var col = spot.Col;
            var n = _elements[board, row, col];

            _elements[board, row, col] = 0;

            _availableSpots[board].Add(spot);

            foreach (var linked in spot.Linked.Where(s => _availableSpots[board].Contains(s)))
                MaybeAddAvailable(board, n, linked);
        }

        private void MaybeAddAvailable(int board, int n, Spot spot)
        {
            var row = spot.Row;
            var col = spot.Col;
            for (var i = 0; i < 9; i++)
                if (!Check(board, n, row, col, i, col) ||
                    !Check(board, n, row, col, row, i) ||
                    !Check(board, n, row, col, 3*(row/3) + i/3, 3*(col/3) + i%3))
                    return;
            spot.Available.Add(n);
        }

        private bool Check(int board, int n, int row, int col, int targetRow, int targetCol)
        {
            if (_elements[board, targetRow, targetCol] == 0) return true;
            if (row == targetRow && col == targetCol) return true;
            return _elements[board, targetRow, targetCol] != n;
        }
    }
}
