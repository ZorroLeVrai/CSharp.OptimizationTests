using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Async;

internal class TaskWait
{
    async Task<int> Calculate(int index)
    {
        var delayTime = Random.Shared.Next(500, 5000);
        await Task.Delay(delayTime);
        return index;
    }

    public async Task RunWhenAllAsync(int nbTasks)
    {
        Task<int>[] tasks = Enumerable
            .Range(0, nbTasks)
            .Select(Calculate)
            .ToArray();

        var results = await Task.WhenAll(tasks);

        for (int i = 0; i < results.Length; i++)
        {
            Console.WriteLine($"Task {i} completed with result: {results[i]}");
        }
    }

    public async Task LaunchUsingWhenAnyAsync(int nbTasks)
    {
        var tasks = Enumerable
            .Range(0, nbTasks)
            .Select(Calculate)
            .ToList();

        while (tasks.Count > 0)
        {
            // Wait for any task to complete
            var completedTask = await Task.WhenAny(tasks);
            tasks.Remove(completedTask);
            // Process the result of the completed task
            var result = await completedTask;
            Console.WriteLine($"Task completed with result: {result}");
        }
    }

    public async Task LaunchUsingWhenEachAsync(int nbTasks)
    {
        var tasks = Enumerable
            .Range(0, nbTasks)
            .Select(Calculate)
            .ToArray();

        await foreach (var completedTask in Task.WhenEach(tasks))
        {
            // Process the result of the completed task
            var result = await completedTask;
            Console.WriteLine($"Task completed with result: {result}");
        }
    }
}
