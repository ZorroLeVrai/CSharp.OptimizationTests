using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Method)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class FibonacciNumbersBenchmarkV2
{
    private Ex01FibonacciNumbers? fiboNumbers;

    [Params(10, 20, 40)]
    public int N { get; set; }

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
    public void RecursiveSpanMemoFibo()
    {
        fiboNumbers!.RecursiveSpanMemoFibo(N);
    }

    [Benchmark]
    public void TailResursiveFibo()
    {
        fiboNumbers!.TailResursiveFibo(N);
    }
}