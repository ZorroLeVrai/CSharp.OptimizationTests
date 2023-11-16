using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Operations;

namespace BenchmarkConsole.Operations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class CommonListBenchmark
{
    private Ex01CommonList commonList = new Ex01CommonList();

    [Benchmark]
    void GetCommonListUsingHashSet()
    {
        commonList.Run();
    }
}
