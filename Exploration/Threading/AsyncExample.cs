namespace Exploration.Threading;

public class AsyncExample
{
    public async Task Run()
    {
        Console.WriteLine("Start Prgm");
        Console.WriteLine("Step 1");
        PrintThreadId(1);
        //var task = ProcessAsync();
        var toto = "TOTO";
        await ProcessAsync().ConfigureAwait(false);
        Console.WriteLine(toto);
        Console.WriteLine("Step 2");
        //LongProcess(3000);
        PrintThreadId(4);
        Console.WriteLine("Step 3");
        //PrintThreadId(1);
        //await task;
        //PrintThreadId(1);
        Console.WriteLine("End Prgm");
    }

    public async Task ProcessAsync()
    {
        Console.WriteLine("Start Process");
        PrintThreadId(2);
        Console.WriteLine("Task Delay - ProcessAsync");
        //Request base de données
        await Task.Delay(5000).ConfigureAwait(false);
        PrintThreadId(3);
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


    public void ParallelRequestCall()
    {
        var tasks = new List<Task>();
        for (int i = 0; i < 10; i++)
        {
            Task task = ProcessAsync();
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());

        Console.ReadKey();
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
