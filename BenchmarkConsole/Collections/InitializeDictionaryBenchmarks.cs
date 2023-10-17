using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using OptimizationTests.Collections;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class InitializeDictionaryBenchmarks
{
    private const int DICO_SIZE = 1100;

    [Benchmark]
    public void InitializeDicoWithoutReservingSpace()
    {
        InitializingDicos.GetInitializedDico(DICO_SIZE, false);
    }

    [Benchmark]
    public void InitializeDicoAfterReservingSpace()
    {
        InitializingDicos.GetInitializedDico(DICO_SIZE, true);
    }

    [Benchmark]
    public void InitializeListKeyValue()
    {
        InitializingDicos.GetInitializedListKeyValuePair(DICO_SIZE);
    }

    [Benchmark]
    public void InitializeArrayKeyValue()
    {
        InitializingDicos.GetInitializedArrayKeyValuePair(DICO_SIZE);
    }
}
