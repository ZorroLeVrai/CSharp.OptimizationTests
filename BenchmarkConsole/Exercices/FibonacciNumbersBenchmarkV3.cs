using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class FibonacciNumbersBenchmarkV3
{
    private Ex01FibonacciNumbers? fiboNumbers;

    [GlobalSetup]
    public void SetupData()
    {
        fiboNumbers = new Ex01FibonacciNumbers();
    }

    [Params(10, 20, 40)]
    public int N { get; set; }

    [Benchmark]
    public void IterativeFibo()
    {
        if (fiboNumbers == null)
            throw new InvalidOperationException("FibonacciNumbers instance is not initialized.");
        fiboNumbers.IterativeFibo(N);
    }

    [Benchmark]
    public void RecursiveFibo()
    {
        if (fiboNumbers == null)
            throw new InvalidOperationException("FibonacciNumbers instance is not initialized.");
        fiboNumbers.RecursiveFibo(N);
    }

    [Benchmark]
    public void RecursiveMemoFibo()
    {
        if (fiboNumbers == null)
            throw new InvalidOperationException("FibonacciNumbers instance is not initialized.");
        fiboNumbers.RecursiveMemoFibo(N);
    }
}
