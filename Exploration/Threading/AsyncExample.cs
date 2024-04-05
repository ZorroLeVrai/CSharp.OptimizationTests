namespace Exploration.Threading;

public class AsyncExample
{
    public async Task Run()
    {
        Console.WriteLine("Start Prgm");
        Console.WriteLine("Step 1");
        var task = ProcessAsync();
        Console.WriteLine("Step 2");
        LongProcess(3000);
        Console.WriteLine("Step 3");
        PrintThreadId(1);
        await task;
        PrintThreadId(1);
        Console.WriteLine("End Prgm");
    }

    public async Task ProcessAsync()
    {
        Console.WriteLine("Start Process");
        PrintThreadId(2);
        await Task.Delay(2000);
        PrintThreadId(2);
        Console.WriteLine("End Process");
    }

    public Task ProcessSync()
    {
        Console.WriteLine("Start Process");
        PrintThreadId(2);
        return Task.Run(() => {
            Thread.Sleep(2000);
            PrintThreadId(2);
            Console.WriteLine("End Process");
        });
    }

    private void LongProcess(int nbMs)
    {
        Thread.Sleep(nbMs);
    }

    private void PrintThreadId(int tagId)
    {
        Console.WriteLine($"{tagId}: Current Thread ID: {Thread.CurrentThread.ManagedThreadId}");
    }
}
