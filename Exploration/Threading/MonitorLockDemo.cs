namespace Exploration.Threading;

internal class MonitorLockDemo
{
    static object lobj = new object();

    public static void Run()
    {
        for (int i = 1; i <= 6; i++)
        {
            Monitor.Enter(lobj);
            Console.WriteLine($"Enter {i}");
        }

        for (int i = 1; i <= 6; i++)
        {
            Monitor.Exit(lobj);
            Console.WriteLine($"Release {i}");
        }

        var task = Task.Run(() => {
            Monitor.Enter(lobj);
            Console.WriteLine("Step 6");
        });

        task.Wait();
    }
}
