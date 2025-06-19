using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Threading;

internal class ParallelForExample
{
    public static void Run()
    {
        var numbers = Enumerable.Range(1, 1000).ToArray();
        var doubles = new int[numbers.Length];

        //for (int i = 0; i < numbers.Length; ++i)
        //{
        //    doubles[i] = 2*numbers[i];
        //}

        Parallel.For(0, numbers.Length, i =>
        {
            doubles[i] = 2 * numbers[i];
        });

        Console.WriteLine("Doubles: {0}", string.Join(", ", doubles));
    }
}
