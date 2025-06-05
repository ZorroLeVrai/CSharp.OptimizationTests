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
    Random rnd = new Random();

    [GlobalSetup]
    public void SetupData()
    {
        ex2 = new LinqEx2();
        //col = new string[] { "Pomme", "Banane", "Pomme", "Cerise", "Banane", "Pomme" };
        col = CreateElements(1000); // Create a collection of 1000 elements
    }

    private string[] CreateElements(int count)
    {
        Func<int, string> getElementFromIndex = val => val switch
        {
            0 => "Pomme",
            1 => "Banane",
            2 => "Cerise",
            3 => "Poire",
            4 => "Orange",
            5 => "Fraise",
            6 => "Melon",
            7 => "Kiwi",
            8 => "Mangue",
            9 => "Ananas",
            _ => "Element"
        };

        Func<string> getElement = () => getElementFromIndex(rnd.Next(0, 10));


        return Enumerable
            .Range(0, count)
            .Select(_ => getElement())
            .ToArray();
    }

    private Dictionary<string, int> CreateExpectedDico(IEnumerable<string> collection)
    {
        var expectedDico = new Dictionary<string, int>();
        foreach (var item in collection)
        {
            if (expectedDico.TryGetValue(item, out int nbOccurence))
            {
                expectedDico[item] = ++nbOccurence;
            }
            else
            {
                expectedDico.Add(item, 1);
            }
        }

        return expectedDico;
    }

    [Benchmark(Baseline = true)]
    public void ToOccurenceDicoSimpleLoop()
    {
        CreateExpectedDico(col!);
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

    [Benchmark]
    public void ToOccurenceDico4()
    {
        ex2!.ToOccurenceDico4(col!);
    }

    [Benchmark]
    public void ToOccurenceDico5()
    {
        ex2!.ToOccurenceDico5(col!);
    }
}
