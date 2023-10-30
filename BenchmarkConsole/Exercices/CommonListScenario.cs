using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using OptimizationTests.Exercices;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class CommonListScenario
{
    private RetrieveCommonListScenario? commonListScenario;

    [GlobalSetup]
    public void SetupData()
    {
        commonListScenario = new RetrieveCommonListScenario();
    }

    [Benchmark]
    public void GetIntersectionUsingList()
    {
        commonListScenario!.GetIntersectionUsingList();
    }

    [Benchmark]
    public void GetIntersectionUsingListLinqVersion()
    {
        commonListScenario!.GetIntersectionUsingListLinqVersion();
    }

    [Benchmark]
    public void GetIntersectionUsingHashSet()
    {
        commonListScenario!.GetIntersectionUsingHashSet();
    }
}