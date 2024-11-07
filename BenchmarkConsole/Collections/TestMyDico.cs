using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exploration.Dictionaries;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class TestMyDico
{
    private MyDico<string, int> myDico = new ();

    private Dictionary<string, int> realDico = new ();

    private List<int> justNumbers = new();

    private char GetChar(int i) => (char)('A' + i);

    public TestMyDico()
    {
        char[] key = new char[2];

        for (int i = 0; i < 26; ++i)
        {
            key[0] = GetChar(i);
            for (int j = 0; j < 26; ++j)
            {
                key[1] = GetChar(j);
                var strKey = new string(key);
                var value = i * 26 + j;
                myDico.Add(strKey, value);
                realDico.Add(strKey, value);
                justNumbers.Add(value);
            }
        }
    }

    [Benchmark (Baseline=true)]
    public void GetDataFromRealDico()
    {
        var result = realDico["MA"];
        result = realDico["AA"];
        result = realDico["ZZ"];
    }

    [Benchmark]
    public void GetDataFromMyDico()
    {
        var result = myDico["MA"];
        result = myDico["AA"];
        result = myDico["ZZ"];
    }

    [Benchmark]
    public void GetDataFromList()
    {
        var result = justNumbers.Contains(312);
        result = justNumbers.Contains(0);
        result = justNumbers.Contains(675);
    }
}
