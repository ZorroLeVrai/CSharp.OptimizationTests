using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Multithreading;

namespace BenchmarkConsole.Multithreading;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class SumInverseBenchmark
{
    private const uint NB_TERME = 10_000_000;
    private readonly Ex01SommeInverse computer = new Ex01SommeInverse();

    [Benchmark(Baseline = true)]
    public void SimpleProcess()
    {
        computer.SimpleProcess(NB_TERME);
    }

    [Benchmark]
    public void SimpleLinqProcess()
    {
        computer.SimpleLinqProcess(NB_TERME);
    }

    [Benchmark]
    public void ParallelWithMaxDegreeWithLock()
    {
        computer.ParallelWithMaxDegreeWithLock(NB_TERME, 1000);
    }

    [Benchmark]
    public void ParallelWithMaxDegreeWithSpinLock()
    {
        computer.ParallelWithMaxDegreeWithSpinLock(NB_TERME, 1000);
    }

    [Benchmark]
    public void ParallelLinqProcess()
    {
        computer.ParallelLinqProcess(NB_TERME);
    }

    [Benchmark]
    public void SplitParallelProcess()
    {
        computer.SplitParallelProcess(NB_TERME);
    }

    [Benchmark]
    public void SplitParallelProcessV2()
    {
        computer.SplitParallelProcessV2(NB_TERME);
    }
}
