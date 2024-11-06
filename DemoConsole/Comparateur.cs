using BenchmarkDotNet.Attributes;
using Exercices.Calculs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole;

public class Comparateur
{
    private Ex02FibonacciSeries ex02FibonacciSeries;

    public Comparateur()
    {
        ex02FibonacciSeries = new Ex02FibonacciSeries();
    }

    [Benchmark]
    public void Method1()
    {
        ex02FibonacciSeries.ComputeUsingIterator(30);
    }

    [Benchmark]
    public void Method2()
    {
        ex02FibonacciSeries.ComputeUsingArray(30);
    }
}
