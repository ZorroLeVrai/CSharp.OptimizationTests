namespace Exploration.Threading;

internal class SimpleThreadsWithExceptions
{
    static void ExecuteProc(object? nbLoopObj)
    {
        var (threadIndex, nbLoop) = (ThreadData)(nbLoopObj ?? new ThreadData(-1, 5));
        for (int i = 0; i < nbLoop; ++i)
        {
            Console.WriteLine("{0} - Index {1} - Loop {2}", Thread.CurrentThread.Name, threadIndex, i);
            Thread.Sleep(500);

            if (threadIndex == 2 && i == 4)
                throw new Exception("Just for fun");
        }
    }

    public static void Run()
    {
        var thread1 = new Thread(ExecuteProc);
        thread1.Name = "Thread 1";

        var thread2 = new Thread(ExecuteProc);
        thread2.Name = "Thread 2";

        thread1.Start(new ThreadData(1, 10));
        thread2.Start(new ThreadData(2, 10));
    }

    private record ThreadData(int ThreadId, int NbLoop);
}
