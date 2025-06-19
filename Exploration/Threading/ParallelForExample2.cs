using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Threading;

internal class ParallelForExample2
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 1000);
        var totalSum = 0;

        Parallel.ForEach(numbers, number => Interlocked.Add(ref totalSum, number));
        //Parallel.ForEach(numbers, number => totalSum += number);
        Console.WriteLine("totalSum: {0}", totalSum);
    }
}
