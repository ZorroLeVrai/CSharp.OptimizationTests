using Exploration.PerfView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfilingConsole;

internal class WaitBeforeAction : IRunnable
{
    public void Run()
    {
        new WaitBeforePrinting(5000)
            .WaitInALoop();
    }
}
