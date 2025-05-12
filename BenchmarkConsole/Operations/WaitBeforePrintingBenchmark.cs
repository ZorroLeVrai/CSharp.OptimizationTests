using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exploration.PerfView;

namespace BenchmarkConsole.Operations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class WaitBeforePrintingBenchmark
{
    private WaitBeforePrinting? _waitBeforePrinting;

    [GlobalSetup]
    public void SetupData()
    {
        _waitBeforePrinting = new WaitBeforePrinting(5000);
    }

    [Benchmark]
    public void WaitInALoop()
    {
        _waitBeforePrinting!.WaitInALoop();
    }

    [Benchmark]
    public void SynchronousWait()
    {
        _waitBeforePrinting!.SychronousWait();
    }

    [Benchmark]
    async public Task AsynchronousWait()
    {
        await _waitBeforePrinting!.AsychronousWait();
    }
}
