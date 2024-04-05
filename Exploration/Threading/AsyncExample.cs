namespace Exploration.Threading;

public class AsyncExample
{
    public async Task Run()
    {
        Console.WriteLine("Start Prgm");
        Console.WriteLine("Step 1");
        var task = ProcessAsync();
        Console.WriteLine("Step 2");
        LongProcess(5000);
        PrintThreadId(1);
        await task;
        PrintThreadId(1);
        Console.WriteLine("End Prgm");
    }

    public async Task ProcessAsync()
    {
        Console.WriteLine("Start Process");
        PrintThreadId(2);
        await Task.Delay(3000);
        PrintThreadId(2);
        Console.WriteLine("End Process");
    }

    private void LongProcess(int nbMs)
    {
        var startTime = DateTime.Now;
        var currentTime = DateTime.Now;
        while ((currentTime - startTime).TotalMilliseconds < nbMs)
            currentTime = DateTime.Now;
    }

    private void PrintThreadId(int tagId)
    {
        Console.WriteLine($"{tagId}: Current Thread ID: {Thread.CurrentThread.ManagedThreadId}");
    }
}
