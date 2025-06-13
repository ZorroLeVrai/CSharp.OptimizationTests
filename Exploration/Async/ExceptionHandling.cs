using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exploration.Async;

internal class ExceptionHandling
{
    private async Task<int> GetNumberAsync(int number, Exception? exception = null)
    {
        await Task.Delay(number * 1000); // Simulate some asynchronous work
        if (exception != null)
        {
            throw exception; // Throw the provided exception
        }

        return number;
    }

    private async Task<int> GetNumberAsync(int number, CancellationToken cancellationToken)
    {
        await Task.Delay(number * 1000, cancellationToken); // Simulate some asynchronous work
        return number;
    }

    private Task<int>[] CreateTasks()
    {
        var cts = new CancellationTokenSource();

        var tasks = new Task<int>[]
        {
            GetNumberAsync(1, new Exception("Task 1")),
            GetNumberAsync(2, cts.Token),
            GetNumberAsync(3)

            //GetNumberAsync(1, new Exception("Exception 1")),
            //GetNumberAsync(2, new OperationCanceledException("Exception 2")),
            ////GetNumberAsync(2, cts.Token),
            //GetNumberAsync(3, new Exception("Exception 3"))
        };

        cts.Cancel();

        return tasks;
    }

    public async Task HandlingExceptionV1()
    {
        var tasks = CreateTasks();
        var whenAllTasks = Task.WhenAll(tasks);

        try
        {
            var results = await whenAllTasks;

            foreach (var result in results)
            {
                Console.WriteLine($"Result: {result}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred: {ex.Message}");

            if (whenAllTasks.Exception != null)
            {
                foreach (var innerEx in whenAllTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine($"Inner Exception: {innerEx.Message}");
                }
            }
        }
    }

    public async Task HandlingExceptionV2()
    {
        var allTasks = CreateTasks();
        var whenAllTasks = Task.WhenAll(allTasks);

        try
        {
            var results = await whenAllTasks;

            foreach (var result in results)
            {
                Console.WriteLine($"Result: {result}");
            }
        }
        catch
        {
            for (int i = 0; i < allTasks.Length; i++)
            {
                if (allTasks[i].Exception != null)
                {
                    Console.WriteLine($"Task {i} failed with exception: {allTasks[i].Exception!.Message}");
                }
                else if (allTasks[i].IsCanceled)
                {
                    Console.WriteLine($"Task {i} was canceled.");
                }
                else
                {
                    Console.WriteLine($"Task {i} completed successfully.");
                }
            }
        }
    }
}
