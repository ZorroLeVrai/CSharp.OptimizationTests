namespace Exploration.Threading;

internal class TaskWithExceptionsExample
{
    int _nbTasks = 10;

    public void Run()
    {
        var tasks = new Task<string>[_nbTasks];
        for(int i = 0; i < tasks.Length; ++i)
        {
            var locIndex = i;
            tasks[i] = (i == 8) ? Task.Run(() => GetValue(locIndex, true))
                : Task.Run(() => GetValue(locIndex));
        }

        Task.WaitAll(tasks);

        foreach (var task in tasks)
            Console.WriteLine(task.Result);
    }

    string GetValue(int number, bool generateException = false)
    {
        if (generateException)
            throw new Exception($"Generated exception - {nameof(number)}: {number}");
        return number.ToString();
    }
}
