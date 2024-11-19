using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Linq;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class LinkEx2Benchmark
{
    LinqEx2? ex2 = null;
    string[]? col = null;

    [GlobalSetup]
    public void SetupData()
    {
        ex2 = new LinqEx2();
        col = new string[] { "Pomme", "Banane", "Pomme", "Cerise", "Banane", "Pomme" };
    }

    [Benchmark]
    public void ToOccurenceDico()
    {
        ex2!.ToOccurenceDico(col!);
    }

    [Benchmark]
    public void ToOccurenceDico2()
    {
        ex2!.ToOccurenceDico2(col!);
    }

    [Benchmark]
    public void ToOccurenceDico3()
    {
        ex2!.ToOccurenceDico3(col!);
    }
}
