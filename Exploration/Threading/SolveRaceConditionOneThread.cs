namespace Exploration.Threading;

public class SolveRaceConditionOneThread
{
    const int NB_ITERATION = 100_000;
    static int sharedCounter;

    public static void Execute()
    {
        sharedCounter = 0;

        LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(1);
        var taskFactory = new TaskFactory(lcts);

        Task incTask = taskFactory.StartNew(() => ModifyCounter(1));
        Task decTask = taskFactory.StartNew(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                sharedCounter += nb;
            }
        }
    }

    static public void Run()
    {
        Execute();
        Console.WriteLine($"sharedCounter: {sharedCounter}");
    }
}
