using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class ConwaySeriesBenchmark
{
    private Ex03ConwaySeriesV1? conwaySeriesV1;
    private Ex03ConwaySeriesV2? conwaySeriesV2;

    [GlobalSetup]
    public void SetupData()
    {
        conwaySeriesV1 = new Ex03ConwaySeriesV1();
        conwaySeriesV1.Initialize();

        conwaySeriesV2 = new Ex03ConwaySeriesV2();
        conwaySeriesV2.Initialize();
    }

    [Benchmark]
    public void ProcessConwaySeriesV1()
    {
        conwaySeriesV1!.Process();
    }

    [Benchmark]
    public void ProcessConwaySeriesV2()
    {
        conwaySeriesV2!.Process();
    }
}