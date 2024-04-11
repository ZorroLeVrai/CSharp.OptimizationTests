using Exploration.PerfView;
using ProfilingConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Profiling;

internal class WaitBeforeAction : IRunnable
{
    public void Run()
    {
        new WaitBeforePrinting(5000)
            .WaitInALoop();
    }
}
