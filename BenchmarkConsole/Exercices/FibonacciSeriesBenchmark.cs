using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.Method)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class FibonacciSeriesBenchmark
{
    private Ex02FibonacciSeries? fiboSeries;

    [Params(20, 40, 100)]
    public int N { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        fiboSeries = new Ex02FibonacciSeries();
    }

    [Benchmark]
    public void ComputeUsingIterator()
    {
        fiboSeries!.ComputeUsingIterator(N);
    }

    [Benchmark]
    public void ComputeUsingArray()
    {
        fiboSeries!.ComputeUsingArray(N);
    }
}
