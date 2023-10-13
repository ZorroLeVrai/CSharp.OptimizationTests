namespace Exploration.Threading;

internal class SolveRaceConditionSpinLock
{
    const int NB_ITERATION = 100000;
    static int sharedCounter = 0;

    public static void Run()
    {
        var spinLock = new SpinLock();

        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);
        Console.WriteLine($"sharedCounter: {sharedCounter}");

        void ModifyCounter(int nb)
        {
            var lockTaken = false;
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                lockTaken = false;
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
}
