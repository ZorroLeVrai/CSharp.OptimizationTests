namespace Exploration.Threading;

internal class SolveRaceConditionReaderWriterLock
{
    static int sharedCounter = 0;
    static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();

    static void WriterProc()
    {
        for (int i = 0; i < 5; ++i)
        {
            rwl.EnterWriteLock();

            try
            {
                ++sharedCounter;
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
                if (sharedCounter != previous)
                {
                    previous = sharedCounter;
                    Console.WriteLine($"Counter: {sharedCounter}");
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
        sharedCounter = 0;

        var readerThread = new Thread(ReaderProc);
        readerThread.Name = "Reader Thread";

        var writerThread = new Thread(WriterProc);
        writerThread.Name = "Writer Thread";

        readerThread.Start();
        writerThread.Start();
    }
}
