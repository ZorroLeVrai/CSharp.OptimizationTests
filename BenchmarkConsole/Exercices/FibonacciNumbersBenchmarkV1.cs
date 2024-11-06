using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 4)]
public class FibonacciNumbersBenchmarkV1
{
    Ex01FibonacciNumbers fiboNumbers = new Ex01FibonacciNumbers();
    //private const int nTerme = 10;

    [Params(10, 20, 40)]
    public int N { get; set; }

    [Benchmark(Baseline= true)]
    public void IterativeFibo()
    {
        fiboNumbers.IterativeFibo(N);
    }

    [Benchmark]
    public void RecursiveFibo()
    {
        fiboNumbers.RecursiveFibo(N);
    }

    [Benchmark]
    public void RecursiveMemoFibo()
    {
        fiboNumbers.RecursiveMemoFibo(N);
    }

    [Benchmark]
    public void RecursiveSpanMemoFibo()
    {
        fiboNumbers.RecursiveSpanMemoFibo(N);
    }

    [Benchmark]
    public void TailResursiveFibo()
    {
        fiboNumbers.TailResursiveFibo(N);
    }

    [Benchmark]
    public void LinqParallelFibo()
    {
        fiboNumbers.LinqParallelFibo(N);
    }

    [Benchmark]
    public void LinqParallelFiboV2()
    {
        fiboNumbers.LinqParallelFiboV2(N);
    }

    [Benchmark]
    public void ArrayFibo()
    {
        fiboNumbers.ArrayFibo(N);
    }
}
