using Exercices.Calculs;

namespace ProfilingConsole;

internal class FibonacciSequence : IRunnable
{
    private const int terme = 45;

    public void Run()
    {
        var result = new Ex01FibonacciNumbers().RecursiveFibo(terme);
        Console.WriteLine($"{terme} => {result}");
    }
}
