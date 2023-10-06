namespace Exploration.Threading;

internal class RaceCondition
{
    const int NB_ITERATION = 100000;
    static int sharedCounter = 0;

    public static void Run()
    {
        Task incTask = new Task(() => ModifyCounter(1));
        Task decTask = new Task(() => ModifyCounter(-1));

        incTask.Start();
        decTask.Start();

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
