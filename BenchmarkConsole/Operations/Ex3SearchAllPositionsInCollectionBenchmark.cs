using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Operations.Exercice3;

namespace BenchmarkConsole.Operations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class Ex3SearchAllPositionsInCollectionBenchmark
{
    private IEnumerable<int> _collection = Enumerable.Empty<int>();
    private OptimizedSearchPositionInListWithDuplicates _optimizedSearch = new OptimizedSearchPositionInListWithDuplicates(Enumerable.Empty<int>());
    private NaiveSearchPositionInListWithDuplicates _naiveSearch = new NaiveSearchPositionInListWithDuplicates(Enumerable.Empty<int>());

    [Params(100, 1000, 10_000)]
    public int NbElements { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        _collection = Enumerable.Range(0, NbElements);
        _optimizedSearch = new OptimizedSearchPositionInListWithDuplicates(_collection);
        _naiveSearch = new NaiveSearchPositionInListWithDuplicates(_collection);
    }

    [Benchmark(Baseline = true)]
    public void NaiveFind()
    {
        _naiveSearch.Find(NbElements - 1);
    }

    [Benchmark]
    public void OptimizedFind()
    {
        _optimizedSearch.Find(NbElements - 1);
    }
}
