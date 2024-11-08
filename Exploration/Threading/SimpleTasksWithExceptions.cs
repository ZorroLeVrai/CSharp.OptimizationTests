namespace Exploration.Threading;

internal class SimpleTasksWithExceptions
{
    static void ExecuteProc(string taskName, int nbLoop)
    {
        for (int i = 0; i < nbLoop; ++i)
        {
            Console.WriteLine("{0} - Loop {1}", taskName, i);
            Thread.Sleep(500);

            if (taskName == "Task 2" && i == 4)
                throw new Exception("Just for fun");
        }
    }

    static void ExecuteProcWithExceptionHandling(string taskName, int nbLoop)
    {
        try
        {
            ExecuteProc(taskName, nbLoop);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public static void Run()
    {
        var task1 = Task.Run(() => ExecuteProc("Task 1", 10));
        var task2 = Task.Run(() => ExecuteProc("Task 2", 10));

        Task.WaitAll(task1, task2);
    }
}
