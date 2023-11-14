using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;
using OptimizationTests.Exercices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class FibonacciNumbers
{
    private Ex01FibonacciNumbers? fiboNumbers;
    private const int N = 40;

    [GlobalSetup]
    public void SetupData()
    {
        fiboNumbers = new Ex01FibonacciNumbers();
    }

    [Benchmark]
    public void IterativeFibo()
    {
        fiboNumbers!.IterativeFibo(N);
    }

    [Benchmark]
    public void RecursiveFibo()
    {
        fiboNumbers!.RecursiveFibo(N);
    }

    [Benchmark]
    public void RecursiveMemoFibo()
    {
        fiboNumbers!.RecursiveMemoFibo(N);
    }

    [Benchmark]
    public void TailResursiveFibo()
    {
        fiboNumbers!.TailResursiveFibo(N);
    }
}
