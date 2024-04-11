namespace Exploration.Threading;

internal class RaceCondition
{
    const int NB_ITERATION = 1000_000;
    static int sharedCounter = 0;

    public static void Run()
    {
        sharedCounter = 0;

        Task incTask = Task.Run(() => ModifyCounter(1));
        Task decTask = Task.Run(() => ModifyCounter(-1));
        
        Task.WaitAll(incTask, decTask);
        Console.WriteLine($"sharedCounter: {sharedCounter}");

        static void ModifyCounter(int nb)
        {
            for (int i = 0; i < NB_ITERATION; ++i)
            {
                sharedCounter += nb;
            }
        }
    }
}
