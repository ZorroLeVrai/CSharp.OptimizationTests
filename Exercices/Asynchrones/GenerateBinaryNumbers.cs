namespace Exercices.Asynchrones;

internal class GenerateBinaryBase
{
    protected Random _random = new();
    protected int _nbToGenerate;

    public GenerateBinaryBase(int nbToGenerate)
    {
        _nbToGenerate = nbToGenerate;
    }

    protected async Task<string> GetBinaryAsync(int number)
    {
        using HttpClient client = new();

        client.BaseAddress = new Uri("https://localhost:7014/");
        var url = string.Concat("api/IntToBinary/", number);

        try
        {
            return await client.GetStringAsync(url);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

internal class GenerateBinaryNumbers : GenerateBinaryBase
{
    public GenerateBinaryNumbers(int nbToGenerate) : base(nbToGenerate)
    {
    }

    private async IAsyncEnumerable<string> GenerateBinariesAsync()
    {
        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            yield return await GetBinaryAsync(randomNumber);
        }
    }

    public async Task DisplayAsync()
    {
        await BinaryDisplayer.DisplayAsync(GenerateBinariesAsync());
    }
}

internal class GenerateBinaryParallelNumbers : GenerateBinaryBase
{
    public GenerateBinaryParallelNumbers(int nbToGenerate) : base(nbToGenerate)
    {
    }

    private async IAsyncEnumerable<string> GenerateBinariesAsync()
    {
        var tasks = new Task<string>[_nbToGenerate];
        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            tasks[i] = GetBinaryAsync(randomNumber);
        }

        for (int i = 0; i < _nbToGenerate; ++i)
        {
            yield return await tasks[i];
        }
    }

    public async Task DisplayAsync()
    {
        await BinaryDisplayer.DisplayAsync(GenerateBinariesAsync());
    }
}


internal class GenerateBinaryParallelNumbers2 : GenerateBinaryBase
{
    public GenerateBinaryParallelNumbers2(int nbToGenerate) : base(nbToGenerate)
    {
    }

    private Task<string>[] GenerateBinaries()
    {
        var tasks = new Task<string>[_nbToGenerate];
        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            tasks[i] = GetBinaryAsync(randomNumber);
        }

        Task.WaitAll(tasks);

        return tasks;
    }

    public void Display()
    {
        BinaryDisplayer.Display(GenerateBinaries());
    }
}

internal class GenerateBinaryAsapNumbers : GenerateBinaryBase
{
    public GenerateBinaryAsapNumbers(int nbToGenerate) : base(nbToGenerate)
    {
    }

    public void Display()
    {
        Task[] tasks = new Task[_nbToGenerate];

        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            tasks[i] = DispBinaryStrAsync(GetBinaryAsync(randomNumber));
            //tasks[i] = GetBinaryAsync(randomNumber)
            //    .ContinueWith(t => Console.WriteLine(t.Result));
        }

        Task.WaitAll(tasks);

        static async Task DispBinaryStrAsync(Task<string> task)
        {
            var result = await task;
            await Console.Out.WriteLineAsync(result);
        }
    }
}

internal static class BinaryDisplayer
{
    public static async Task DisplayAsync(IAsyncEnumerable<string> results)
    {
        await foreach (var resultItem in results)
            Console.WriteLine(resultItem);
    }

    public static void Display(Task<string>[] tasks)
    {
        foreach (var resultItem in tasks)
            Console.WriteLine(resultItem.Result);
    }
}

