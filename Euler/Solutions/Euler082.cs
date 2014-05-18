using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euler.Solutions
{
    class Euler082 : Euler
    {
        public override long Exec()
        {
            PrecalcNeighbors();
            var min = long.MaxValue;
            var lck = new object();
            Parallel.For(0, N, startRow =>
            {
                var distances = DijkstraDistances(N*startRow);
                for (var endRow = 0; endRow < N; endRow++)
                    lock(lck)
                        min = Math.Min(min, Matrix[startRow, 0] + distances[N*endRow + N - 1]);
            });
            return min;
        }

        private const int N = 80;
        private const int N2 = N*N;
        private static readonly long[,] Matrix = LoadMatrix(N, "Euler082.txt");
        private static readonly List<Tuple<int, long>>[] Neighbors = new List<Tuple<int, long>>[N2];

        private static void PrecalcNeighbors()
        {
            for (var n = 0; n < N2; n++)
            {
                Neighbors[n] = new List<Tuple<int, long>>();
                var row = n/N; var col = n%N;
                if (col < N - 1) Neighbors[n].Add(new Tuple<int, long>(n + 1, Matrix[row, col + 1])); // right
                if (row > 0)     Neighbors[n].Add(new Tuple<int, long>(n - N, Matrix[row - 1, col])); // up
                if (row < N - 1) Neighbors[n].Add(new Tuple<int, long>(n + N, Matrix[row + 1, col])); // down
            }
        }

        private static long[] DijkstraDistances(int src)
        {
            var dist = new long[Matrix.Length];
            for (var i = 0; i < N2; i++)
                dist[i] = long.MaxValue;
            dist[src] = 0;
            var visited = new HashSet<int> {src};
            var unvisited = new HashSet<int>(Enumerable.Range(0, N2)); unvisited.Remove(src);
            var cur = src;
            while (!Enumerable.Range(0, N).All(i => visited.Contains(N*i+N-1)))
            {
                foreach (var neighbor in Neighbors[cur])
                    dist[neighbor.Item1] = Math.Min(dist[neighbor.Item1], dist[cur] + neighbor.Item2);
                visited.Add(cur); unvisited.Remove(cur);
                var minDist = long.MaxValue;
                foreach (var u in unvisited)
                    if (dist[u] < minDist)
                    {
                        minDist = dist[u];
                        cur = u;
                    }
            }
            return dist;
        }
    }
}
