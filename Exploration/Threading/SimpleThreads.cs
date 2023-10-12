namespace Exploration.Threading;

internal class SimpleThreads
{
    static void ExecuteProc(object? nbLoopObj)
    {
        var nbLoop = (int)(nbLoopObj ?? 5);
        for (int i = 0; i < nbLoop; ++i)
        {
            Console.WriteLine("{0} - Loop {1}", Thread.CurrentThread.Name, i);
            Thread.Sleep(0);
        }
    }

    public static void Run()
    {
        var thread1 = new Thread(ExecuteProc);
        thread1.Name = "Thread 1";

        var thread2 = new Thread(ExecuteProc);
        thread2.Name = "Thread 2";

        thread1.Start(5);
        thread2.Start(5);
    }
}
