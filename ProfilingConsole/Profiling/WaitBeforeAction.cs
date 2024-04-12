using Exploration.PerfView;
using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class WaitBeforeAction : IRunnable
{
    public void Run()
    {
        new WaitBeforePrinting(5000)
            .WaitInALoop();
    }
}
