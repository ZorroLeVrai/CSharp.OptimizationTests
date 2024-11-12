namespace Exploration.Threading;

internal class TestConfigureAwait
{
    public async Task Run()
    {
        //Console.WriteLine("Avant l'appel à la tâche asynchrone");

        await Task.Delay(500).ConfigureAwait(true);

        PrintThreadId("Before DoWorkAsync");
        await DoWorkAsync();
        PrintThreadId("Before Wait");
        PrintThreadId("After DoWorkAsync");

        //Console.WriteLine("Après l'appel à la tâche asynchrone");
    }

    private async Task<int> DoWorkAsync()
    {
        //Console.WriteLine("Avant le Task.Delay");

        int number1 = 5;

        PrintThreadId("Before Task.Delay");
        Console.WriteLine($"Before: ThreadId: {Environment.CurrentManagedThreadId}");
        await Task.Delay(1000).ConfigureAwait(true);
        Console.WriteLine($"After: ThreadId: {Environment.CurrentManagedThreadId}");
        PrintThreadId("After Task.Delay");

        //Console.WriteLine("Après le Task.Delay");

        return number1 + 5;
    }

    private void PrintThreadId(string tag)
    {
        Console.WriteLine($"{tag}: ThreadId: {Environment.CurrentManagedThreadId}");
    }
}
