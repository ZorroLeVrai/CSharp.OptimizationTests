using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Linq;
using static Exercices.Linq.LinqEx5B;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class LinkEx5BBenchmark
{
    IEnumerable<LinqEx5B.Student> _students = Enumerable.Empty<Student>();
    LinqEx5B ex5 = new LinqEx5B();

    [GlobalSetup]
    public void SetupData()
    {
        _students = new Student[]
        {
            new Student("Alice", new string[] { "Math", "Science" }),
            new Student("Bob", new string[] { "History", "English", "Science" }),
            new Student("Charlie", new string[] { "Math", "Physics", "Chemistry" })
        };
    }

    [Benchmark]
    public void GroupByToDictionary()
    {
        ex5.ProcessGroupByToDictionary(_students);
    }

    [Benchmark]
    public void AggregateToDictionary()
    {
        ex5.ProcessAggregateToDictionary(_students);
    }
}
