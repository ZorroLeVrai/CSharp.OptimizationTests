using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Multithreading;

namespace BenchmarkConsole.Multithreading;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class SumDigitBenchmark
{
    private int[] _collection = new int[0];
    private Ex02SumDigits? _sumDigits;

    [Params(1_000_000)]
    public int NbElements { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        _sumDigits = new Ex02SumDigits();
        _sumDigits.Init();
        _collection = _sumDigits.GenerateNumbers(NbElements);
    }

    [Benchmark(Baseline =true)]
    public void SimpleCompute()
    {
        _sumDigits!.SimpleCompute(_collection);
    }

    [Benchmark]
    public void SimpleWithCacheCompute()
    {
        _sumDigits!.SimpleWithCacheCompute(_collection);
    }

    [Benchmark]
    public void ParallelCompute()
    {
        _sumDigits!.ParallelCompute(_collection);
    }

    [Benchmark]
    public void ParallelWithCacheCompute()
    {
        _sumDigits!.ParallelWithCacheCompute(_collection);
    }

    [Benchmark]
    public void ParallelWithOptionsCompute()
    {
        _sumDigits!.ParallelWithOptionsCompute(_collection);
    }

    [Benchmark]
    public void TasksCompute()
    {
        _sumDigits!.TasksCompute(_collection);
    }

    [Benchmark]
    public void SplitTasksCompute()
    {
        _sumDigits!.SplitTasksCompute(_collection);
    }

    [Benchmark]
    public void SplitTasksWithCacheCompute()
    {
        _sumDigits!.SplitTasksWithCacheCompute(_collection);
    }
}
