using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Cuni.Arithmetics.FixedPoint;

namespace Benchmarks
{
    public class BenchmarkSuite
    {
        private int N = 100;
        private Fixed<Q16_16>[,] mat16_16;
        private Fixed<Q24_8>[,] mat24_8;

        [GlobalSetup]
        public void Setup()
        {
            mat16_16 = GaussianElimination.RandomMatrix<Q16_16>(N);
            mat24_8 = GaussianElimination.RandomMatrix<Q24_8>(N);
        }

        [Benchmark]
        public void Elimination16_16() => GaussianElimination.Run(N, mat16_16);

        [Benchmark]
        public void Elimination24_8() => GaussianElimination.Run(N, mat24_8);

        [Benchmark]
        public void IntToQ16_16() => new Fixed<Q16_16>(42);

        [Benchmark]
        public void IntToQ24_8() => new Fixed<Q24_8>(42);
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkSuite>();
        }
    }
}
