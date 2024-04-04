using System.Diagnostics.Metrics;

namespace Exploration.Threading;

public class SolveRaceConditionSpinLock
{
    const int NB_ITERATION = 100000;
    static int sharedCounter = 0;

    public static void Execute()
    {
        sharedCounter = 0;

        var spinLock = new SpinLock();

        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                var lockTaken = false;
                try
                {
                    spinLock.Enter(ref lockTaken);
                    sharedCounter += nb;
                }
                finally
                {
                    if (lockTaken)
                        spinLock.Exit();
                }
            }
        }
    }

    public static void Run()
    {
        Execute();
        Console.WriteLine($"sharedCounter: {sharedCounter}");
    }
}