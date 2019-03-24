using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace Benchmarks
{
    public class BenchmarkSuite
    {
        private Fixed<Q16_16>[,] mat;
        private int N = 10;

        [GlobalSetup]
        public void Setup()
        {
            mat = GaussianElimination.RandomMatrix<Q16_16>(N);
        }

        [Benchmark]
        public void Elimination() => GaussianElimination.Run(N, mat);
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkSuite>();
        }
    }
}
