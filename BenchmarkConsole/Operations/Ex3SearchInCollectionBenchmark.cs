using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Operations.Exercice3;

namespace BenchmarkConsole.Operations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class Ex3SearchInCollectionBenchmark
{
    private IEnumerable<int> _collection = Enumerable.Empty<int>();
    private OptimizedSearchInList _optimizedSearch = new OptimizedSearchInList(Enumerable.Empty<int>());
    private NaiveSearchInList _naiveSearch = new NaiveSearchInList(Enumerable.Empty<int>());

    [Params(100, 1000, 10_000)]
    public int NbElements { get; set; }

    [GlobalSetup]
    public void SetupData()
    {
        _collection = Enumerable.Range(0, NbElements);
        _optimizedSearch = new OptimizedSearchInList(_collection);
        _naiveSearch = new NaiveSearchInList(_collection);
    }

    [Benchmark(Baseline=true)]
    public void NaiveContains()
    {
        _naiveSearch.Contains(NbElements-1);
    }

    [Benchmark]
    public void OptimizedContains()
    {
        _optimizedSearch.Contains(NbElements-1);
    }
}
