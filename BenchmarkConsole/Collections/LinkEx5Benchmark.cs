using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Linq;
using static Exercices.Linq.LinqEx5;

namespace BenchmarkConsole.Collections;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 2, iterationCount: 8)]
public class LinkEx5Benchmark
{
    IEnumerable<LinqEx5.Student> _students = Enumerable.Empty<Student>();
    LinqEx5 ex5 = new LinqEx5();

    [GlobalSetup]
    public void SetupData()
    {
        _students = new Student[]
        {
            new Student { Name = "Alice", Courses = new string[] { "Math", "Science" } },
            new Student { Name = "Bob", Courses = new string[] { "History", "English", "Science" } },
            new Student { Name = "Charlie", Courses = new string[] { "Math", "Physics", "Chemistry" } }
        };
    }

    [Benchmark]
    public void CountByToDictionary()
    {
        ex5.ProcessCountByToDictionary(_students);
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
