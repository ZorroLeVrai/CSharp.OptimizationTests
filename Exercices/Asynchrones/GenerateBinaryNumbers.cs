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
            Console.WriteLine("Requete envoyée: {0}", url);
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

    private async Task<IEnumerable<string>> GenerateBinaries()
    {
        var tasks = new Task<string>[_nbToGenerate];

        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            tasks[i] = GetBinaryAsync(randomNumber);
        }

        await foreach (var completedTask in Task.WhenEach(tasks))
        {
            // Process the result of the completed task
            var result = await completedTask;
            Console.WriteLine($"Task completed with result: {result}");
        }

        return tasks.Select(task => task.Result);

        //return tasks;
    }

    public async Task Display()
    {
        var result = await GenerateBinaries();
        //foreach (var binary in result)
        //{
        //    Console.WriteLine(binary);
        //}
    }

    //public async Task DisplayAsync()
    //{
    //    await BinaryDisplayer.DisplayAsync(GenerateBinariesAsync());
    //}
}

internal class GenerateBinaryParallelNumbers : GenerateBinaryBase
{
    public GenerateBinaryParallelNumbers(int nbToGenerate) : base(nbToGenerate)
    {
    }

    //private async IAsyncEnumerable<string> GenerateBinariesAsync()
    //{
        
    //}

    //public async Task DisplayAsync()
    //{
    //    await BinaryDisplayer.DisplayAsync(GenerateBinariesAsync());
    //}
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

