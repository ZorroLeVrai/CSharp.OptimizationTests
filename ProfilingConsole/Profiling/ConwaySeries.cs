using Exercices.Calculs;
using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class ConwaySeries : IRunnable
{
    private const int terme = 50;

    public void Run()
    {
        var result = new Ex03ConwaySeriesV1()
            .Initialize(terme)
            .Process();
        Console.WriteLine($"Result: {result}");
    }
}
