using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using OptimizationTests.Collections;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class InvertDictionaryBenchmarks
{
    Dictionary<string, char> _inputDico = new Dictionary<string, char>
    {
        { "Artichaut", 'A' },
        { "Aubergine", 'A' },
        { "Betterave", 'B' },
        { "Blette", 'B' },
        { "Tomate", 'T' }
    };

    [Benchmark]
    public void InvertDictionaryUsingLinq()
    {
        var outputDico = InvertDictionary.InvertDictionaryUsingLinq(_inputDico);
    }

    [Benchmark]
    public void InvertDictionarySimpleCode()
    {
        var outputDico = InvertDictionary.InvertDictionarySimpleCode(_inputDico);
    }
}
