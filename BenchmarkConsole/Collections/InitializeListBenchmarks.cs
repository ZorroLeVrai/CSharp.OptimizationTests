using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using OptimizationTests.Collections;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class InitializeListBenchmarks
{
    private const int LIST_SIZE = 1100;

    [Benchmark]
    public void InitializeListWithoutReservingSpace()
    {
        InitializingLists.GetInitializedList(LIST_SIZE, false);
    }

    [Benchmark]
    public void InitializeListAfterReservingSpace()
    {
        InitializingLists.GetInitializedList(LIST_SIZE, true);
    }

    [Benchmark]
    public void InitializeArray()
    {
        InitializingLists.GetInitializedArray(LIST_SIZE);
    }

    [Benchmark]
    public void InitializeSpan()
    {
        Span<int> numbers = stackalloc int[LIST_SIZE];
        InitializingLists.InitializeSpan(numbers, LIST_SIZE);
    }

    [Benchmark]
    public void InitializeSpanWithRef()
    {
        Span<int> numbers = stackalloc int[LIST_SIZE];
        InitializingLists.InitializeSpanWithRef(in numbers, LIST_SIZE);
    }
}
