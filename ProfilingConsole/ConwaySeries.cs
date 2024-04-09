using Exercices.Calculs;

namespace ProfilingConsole;

internal class ConwaySeries : IRunnable
{
    private const int terme = 40;

    public void Run()
    {
        var result = new Ex03ConwaySeriesV1()
            .Initialize(terme)
            .Process();
        Console.WriteLine($"Result: {result}");
    }
}
