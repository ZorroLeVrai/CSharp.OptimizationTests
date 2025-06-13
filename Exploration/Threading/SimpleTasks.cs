namespace Exploration.Threading;

internal class SimpleTasks
{
    static void ExecuteProc(string taskName, int nbLoop)
    {
        for (int i = 0; i < nbLoop; ++i)
        {
            Console.WriteLine("{0} {1} - Loop {2}", taskName, Thread.GetCurrentProcessorId(), i);
            Thread.Sleep(500);
        }
    }

    public static void Run()
    {
        var task1 = Task.Run(() => ExecuteProc("Task 1", 10));
        var task2 = Task.Run(() => ExecuteProc("Task 2", 10));

        Task.WaitAll(task1, task2);
    }
}
