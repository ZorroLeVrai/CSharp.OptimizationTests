namespace Exploration.Threading;

internal class OneThreadSchedulerTest
{
    public static void Run()
    {
        var nb = 100;
        var tasks = new Task[100];

        LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(1);
        var taskFactory = new TaskFactory(lcts);

        for(int i = 0; i < nb; ++i)
        {
            var loc = i;
            tasks[i] = taskFactory.StartNew(() => Console.WriteLine(loc));
        }

        Task.WaitAll(tasks);
    }
}
