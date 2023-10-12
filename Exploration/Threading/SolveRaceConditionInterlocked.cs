namespace Exploration.Threading;

internal class SolveRaceConditionInterlocked
{
    const int NB_ITERATION = 100000;
    static int sharedCounter = 0;

    public static void Run()
    {
        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));

        Task.WaitAll(incTask, decTask);
        Console.WriteLine($"sharedCounter: {sharedCounter}");

        void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
                Interlocked.Add(ref sharedCounter, nb);
        }
    }
}
