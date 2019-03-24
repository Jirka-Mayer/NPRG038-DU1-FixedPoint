using System;
using Cuni.Arithmetics.FixedPoint;

namespace Benchmarks
{
    public static class GaussianElimination
    {
        public static Fixed<Q>[,] RandomMatrix<Q>(int n) where Q : IQ, new()
        {
            Random r = new Random();
            var mat = new Fixed<Q>[n, n];

            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                mat[i, j] = new Fixed<Q>(r.Next());

            return mat;

            // mat[row, col]
        }

        public static void Run<Q>(int n, Fixed<Q>[,] mat) where Q : IQ, new()
        {
            for (int col = 0; col < n - 1; col++)
            {
                for (int row = col + 1; row < n; row++)
                {
                    // null a single cell
                    Fixed<Q> alpha = mat[col, row] / mat[col, col];
                    for (int c = 0; c < n; c++)
                        mat[c, row] -= mat[c, col] * alpha;
                }
            }
        }
    }
}
