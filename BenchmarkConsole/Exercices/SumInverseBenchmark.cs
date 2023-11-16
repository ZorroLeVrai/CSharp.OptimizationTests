using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Multithreading;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class SumInverseBenchmark
{
    private const uint NB_TERME = 1_000_000_000;
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
    public void ParallelLinqProcess()
    {
        computer.ParallelLinqProcess(NB_TERME);
    }

    [Benchmark]
    public void SplitParallelProcess()
    {
        computer.SplitParallelProcess(NB_TERME);
    }
}
