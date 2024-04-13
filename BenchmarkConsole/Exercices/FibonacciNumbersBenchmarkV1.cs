using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class FibonacciNumbersBenchmarkV1
{
    Ex01FibonacciNumbers fiboNumbers = new Ex01FibonacciNumbers();
    private const int nTerme = 20;

    [Benchmark]
    public void IterativeFibo()
    {
        fiboNumbers.IterativeFibo(nTerme);
    }

    [Benchmark]
    public void RecursiveFibo()
    {
        fiboNumbers.RecursiveFibo(nTerme);
    }

    [Benchmark]
    public void RecursiveMemoFibo()
    {
        fiboNumbers.RecursiveMemoFibo(nTerme);
    }

    [Benchmark]
    public void TailResursiveFibo()
    {
        fiboNumbers.TailResursiveFibo(nTerme);
    }

    [Benchmark]
    public void TailIterativeFibo()
    {
        fiboNumbers.TailItertiveFibo(nTerme);
    }
}
