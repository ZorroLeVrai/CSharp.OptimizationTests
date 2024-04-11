using Exercices.Calculs;
using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class FibonacciSequence : IRunnable
{
    private const int terme = 45;

    public void Run()
    {
        var result = new Ex01FibonacciNumbers().RecursiveFibo(terme);
        Console.WriteLine($"{terme} => {result}");
    }
}
