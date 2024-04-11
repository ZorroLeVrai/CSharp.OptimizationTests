using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class InitEnumerableBenchmark
{
    [Params(1000, 10_000, 100_000)]
    public int NbElements { get; set; }

    [Benchmark(Baseline = true)]
    public void CreateListForLoop()
    {
        var lst = new List<int>();
        for (int i=0; i<NbElements; ++i)
            lst.Add(i);
    }

    [Benchmark]
    public void CreateListInitCapacity()
    {
        var lst = new List<int>(NbElements);
        for (int i = 0; i < NbElements; ++i)
            lst.Add(i);
    }

    [Benchmark]
    public void CreateListLinq()
    {
        Enumerable.Range(0, NbElements)
            .ToList();
    }

    [Benchmark]
    public void CreateArrayForLoop()
    {
        var arr = new int[NbElements];
        for (int i = 0; i < NbElements; ++i)
            arr[i] = i;
    }

    [Benchmark]
    public void CreateArrayLinq()
    {
        Enumerable.Range(0, NbElements)
            .ToArray();
    }

    [Benchmark]
    public void CreateStackArrayForLoop()
    {
        Span<int> span = stackalloc int[NbElements];
        for (int i = 0; i < NbElements; ++i)
            span[i] = i;
    }

    [Benchmark]
    public void CreateDictionaryForLoop()
    {
        var dico = new Dictionary<int, int>();
        for(int i = 0; i < NbElements; ++i)
            dico.Add(i, i);
    }

    [Benchmark]
    public void CreateDictionaryInitCapacity()
    {
        var dico = new Dictionary<int, int>(NbElements);
        for (int i = 0; i < NbElements; ++i)
            dico.Add(i, i);
    }

    [Benchmark]
    public void CreateDictionaryLinq()
    {
        Enumerable.Range(0, NbElements)
            .ToDictionary(item => item);
    }
}
