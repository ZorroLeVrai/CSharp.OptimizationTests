namespace Exploration.Threading;

public class SolveRaceConditionLock
{
    const int NB_ITERATION = 1000_000;
    // the volatile keyword is not necessary here, because we are using a lock
    static volatile int sharedCounter;

    static object sharedCounterLock = new object();

    public static void Execute()
    {
        sharedCounter = 0;

        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                lock (sharedCounterLock)
                {
                    sharedCounter += nb;
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
