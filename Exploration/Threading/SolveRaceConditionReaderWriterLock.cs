namespace Exploration.Threading;

internal class SolveRaceConditionReaderWriterLock
{
    static int counter = 0;
    static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();

    static void WriterProc()
    {
        for (int i = 0; i < 5; ++i)
        {
            rwl.EnterWriteLock();

            try
            {
                ++counter;
            }
            finally
            {
                rwl.ExitWriteLock();
            }
            Thread.Sleep(1000);
        }
    }

    static void ReaderProc()
    {
        var previous = 0;
        while (previous < 5)
        {

            rwl.EnterReadLock();

            try
            {
                if (counter != previous)
                {
                    previous = counter;
                    Console.WriteLine($"Counter: {counter}");
                }
            }
            finally
            {
                rwl.ExitReadLock();
            }
        }
    }

    public static void Run()
    {
        var readerThread = new Thread(ReaderProc);
        readerThread.Name = "Reader Thread";

        var writerThread = new Thread(WriterProc);
        writerThread.Name = "Writer Thread";

        readerThread.Start();
        writerThread.Start();
    }
}
