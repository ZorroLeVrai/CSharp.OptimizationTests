using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole;

[MemoryDiagnoser]
public class TestCalcul
{
    private int[] _liste;

    public TestCalcul()
    {
        _liste = Enumerable.Range(1, 10000).ToArray();
    }

    [Benchmark(Baseline=true)]
    public long Somme1()
    {
        long somme = 0;
        for (int i = 0; i < _liste.Length; i++)
        {
            somme += _liste[i];
        }

        return somme;
    }


    [Benchmark]
    public long Somme2()
    {
        return _liste.Aggregate((acc, cur) => acc + cur);
    }
}
