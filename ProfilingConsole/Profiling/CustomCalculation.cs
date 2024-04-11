using Exploration.PerfView;
using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class CustomCalculation : IRunnable
{
    private const int nbLoops = 500_000_000;

    public void Run()
    {
        new Additions(nbLoops)
            .Main();
    }
}
