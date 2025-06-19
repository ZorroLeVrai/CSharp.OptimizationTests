namespace Exploration.Threading;

internal class SimpleThreads
{
    static void ExecuteProc(object? nbLoopObj)
    {
        var nbLoop = (int)(nbLoopObj ?? 5);
        for (int i = 0; i < nbLoop; ++i)
        {
            Console.WriteLine("{0} - {1} - Loop {2}", Thread.CurrentThread.Name, Thread.GetCurrentProcessorId(), i);
            Thread.Sleep(500);
        }
    }

    public static void Run()
    {
        var thread1 = new Thread(ExecuteProc);
        thread1.Name = "Thread 1";

        var thread2 = new Thread(ExecuteProc);
        thread2.Name = "Thread 2";

        thread1.Start(10);
        thread2.Start(10);
    }
}
