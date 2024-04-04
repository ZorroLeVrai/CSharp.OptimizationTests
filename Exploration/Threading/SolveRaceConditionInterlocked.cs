namespace Exploration.Threading;

public class SolveRaceConditionInterlocked
{
    const int NB_ITERATION = 100000;
    static int sharedCounter;

    public static void Execute()
    {
        sharedCounter = 0;

        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
                Interlocked.Add(ref sharedCounter, nb);
        }
    }

    public static void Run()
    {
        Execute();
        Console.WriteLine($"sharedCounter: {sharedCounter}");
    }
}
