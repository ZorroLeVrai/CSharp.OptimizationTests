using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Calculs;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class ConwaySeriesBenchmark
{
    private Ex03ConwaySeriesV1? conwaySeriesV1;
    private Ex03ConwaySeriesV2? conwaySeriesV2;
    private Ex03ConwaySeriesV3? conwaySeriesV3;

    [Params(10, 20, 30, 40)]
    public int N { get; set; }


    [GlobalSetup]
    public void SetupData()
    {
        conwaySeriesV1 = new Ex03ConwaySeriesV1();
        conwaySeriesV1.Initialize();

        conwaySeriesV2 = new Ex03ConwaySeriesV2();
        conwaySeriesV2.Initialize();

        conwaySeriesV3 = new Ex03ConwaySeriesV3();
        conwaySeriesV3.Initialize();
    }

    [Benchmark(Baseline = true)]
    public void ProcessConwaySeriesV1()
    {
        conwaySeriesV1!.Process(N);
    }

    [Benchmark]
    public void ProcessConwaySeriesV2()
    {
        conwaySeriesV2!.Process(N);
    }

    [Benchmark]
    public void ProcessConwaySeriesV3()
    {
        conwaySeriesV3!.Process(N);
    }
}