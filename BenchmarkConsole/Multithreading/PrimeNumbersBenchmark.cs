using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Multithreading;

namespace BenchmarkConsole.Multithreading;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class PrimeNumbersBenchmark
{
    private int[] _collection = new int[0];
    private Ex03FilterPrimes? _filterPrimes;

    [Params(1_000_000)]
    public int NbElements { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        _filterPrimes = new Ex03FilterPrimes();
        _filterPrimes.Init();
        _collection = _filterPrimes.GenerateNumbers(NbElements);
    }

    [Benchmark(Baseline = true)]
    public void SimpleCompute()
    {
        _filterPrimes!.SimpleCompute(_collection);
    }

    [Benchmark]
    public void SimpleWithCacheCompute()
    {
        _filterPrimes!.SimpleWithCacheCompute(_collection);
    }

    [Benchmark]
    public void LinqCompute()
    {
        _filterPrimes!.LinqCompute(_collection);
    }

    [Benchmark]
    public void LinqPrimeV1Compute()
    {
        _filterPrimes!.LinqPrimeV1Compute(_collection);
    }

    [Benchmark]
    public void LinqWithCacheCompute()
    {
        _filterPrimes!.LinqWithCacheCompute(_collection);
    }

    [Benchmark]
    public void LinqParallelCompute()
    {
        _filterPrimes!.LinqParallelCompute(_collection);
    }

    [Benchmark]
    public void LinqParallelWithCacheCompute()
    {
        _filterPrimes!.LinqParallelWithCacheCompute(_collection);
    }

    [Benchmark]
    public void ParallelCompute()
    {
        _filterPrimes!.ParallelCompute(_collection);
    }

    [Benchmark]
    public void ParallelWithCacheCompute()
    {
        _filterPrimes!.ParallelWithCacheCompute(_collection);
    }

    [Benchmark]
    public void SplitTasksCompute()
    {
        _filterPrimes!.SplitTasksCompute(_collection);
    }

    [Benchmark]
    public void SplitTasksWithCacheCompute()
    {
        _filterPrimes!.SplitTasksWithCacheCompute(_collection);
    }
}
