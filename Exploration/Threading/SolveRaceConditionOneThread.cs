namespace Exploration.Threading;

internal class SolveRaceConditionOneThread
{
    const int NB_ITERATION = 100_000;
    static int sharedCounter;

    public static void Run()
    {
        sharedCounter = 0;

        LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(1);
        var taskFactory = new TaskFactory(lcts);

        Task incTask = taskFactory.StartNew(() => ModifyCounter(1));
        Task decTask = taskFactory.StartNew(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);
        Console.WriteLine($"sharedCounter: {sharedCounter}");

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                sharedCounter += nb;
            }
        }
    }
}
