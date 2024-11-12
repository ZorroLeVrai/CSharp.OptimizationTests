namespace Exploration.Threading;

internal class AsyncWithExceptionsExample
{
    int _nbTasks = 10;

    public async Task Run()
    {
        var tasks = new Task[_nbTasks];
        for (int i = 0; i < tasks.Length; ++i)
        {
            if (i == 8)
                await GetValueAsync(i, true);
            else
                await GetValueAsync(i);
        }
    }

    async Task GetValueAsync(int number, bool generateException = false)
    {
        await Task.Delay(50);
        if (generateException)
            throw new Exception($"Generated exception - {nameof(number)}: {number}");
        await Console.Out.WriteLineAsync(number.ToString());
    }
}
