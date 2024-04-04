using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exploration.Threading;

namespace BenchmarkConsole.Multithreading;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 3, iterationCount: 8)]
public class SynchronizationBenchmark
{
    [Benchmark]
    public void UsingLocks()
    {
        SolveRaceConditionLock.Execute();
    }

    [Benchmark]
    public void UsingSpinLocks()
    {
        SolveRaceConditionSpinLock.Execute();
    }

    [Benchmark]
    public void UsingInterlocked()
    {
        SolveRaceConditionInterlocked.Execute();
    }

    [Benchmark]
    public void UsingOneUniqueThread()
    {
        SolveRaceConditionOneThread.Execute();
    }
}
