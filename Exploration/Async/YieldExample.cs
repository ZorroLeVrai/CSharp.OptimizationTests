namespace Exploration.Async;

internal class YieldExample
{
    public async Task<int> GetTotalWaitAsync(string tag, int sleepTime, int awaitTime)
    {
        // Yielding allows the method to return control to the caller,
        //await Task.Yield();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0} - {1} - Avant le Sleep", tag, Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(sleepTime);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} - {1} - Après le Sleep", tag, Thread.CurrentThread.ManagedThreadId);

        await Task.Delay(awaitTime);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("{0} - {1} - Après le Delay", tag, Thread.CurrentThread.ManagedThreadId);

        return sleepTime + awaitTime;
    }

    public async Task LauncherUsingAwaitAsync(int nbIterations)
    {
        for (int i = 0; i < nbIterations; i++)
        {
            // Start the task and await it
            var result = await GetTotalWaitAsync($"Call {i}", 1000, 2000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Result: {result}");
        }
    }

    public async Task LaunchUsingWhenAllAsync(int nbIterations)
    {
        var tasks = new Task<int>[nbIterations];
        for (int i = 0; i < nbIterations; i++)
        {
            // Start the task and add it to the list
            tasks[i] = Task.Run(() => GetTotalWaitAsync($"Call {i}", 1000, 2000));
        }
        // Wait for all tasks to complete
        var results = await Task.WhenAll(tasks);

        Console.ForegroundColor = ConsoleColor.White;
        // Process results
        foreach (var result in results)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}
