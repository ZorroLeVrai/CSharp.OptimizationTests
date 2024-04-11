using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Operations.Exercice3;

namespace BenchmarkConsole.Operations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class Ex3SearchPositionInCollectionBenchmark
{
    private IEnumerable<int> _collection = Enumerable.Empty<int>();
    private OptimizedSearchPositionInList _optimizedSearch = new OptimizedSearchPositionInList(Enumerable.Empty<int>());
    private NaiveSearchPositionInList _naiveSearch = new NaiveSearchPositionInList(Enumerable.Empty<int>());

    [Params(100, 1000, 10_000)]
    public int NbElements { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        _collection = Enumerable.Range(0, NbElements);
        _optimizedSearch = new OptimizedSearchPositionInList(_collection);
        _naiveSearch = new NaiveSearchPositionInList(_collection);
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