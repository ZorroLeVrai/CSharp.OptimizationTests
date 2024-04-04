using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Threading;

internal class ParallelSelectExample
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 1000);
        var doubledNumbers = numbers.AsParallel().AsOrdered().Select(x => x * 2).ToList();
        Console.WriteLine(string.Join(",", doubledNumbers));
    }
}
