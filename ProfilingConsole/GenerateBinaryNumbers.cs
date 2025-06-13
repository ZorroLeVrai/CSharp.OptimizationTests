using System.ComponentModel.DataAnnotations;

namespace ConsoleApp;

internal class GenerateBinaryBase
{
    protected Random _random = new();
    protected int _nbToGenerate;

    public GenerateBinaryBase(int nbToGenerate) { 
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

    private async Task<string> GetBinaryWrapper(int number, int index)
    {
        var result = await GetBinaryAsync(number);
        Console.WriteLine("{0}: {1}", index, result);
        return result;
    }

    private async IAsyncEnumerable<string> GenerateBinariesAsync()
    {
        var tasks = new Task<string>[_nbToGenerate];
        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            tasks[i] = GetBinaryAsync(randomNumber);
        }

        var results = await Task.WhenAll(tasks);
        foreach (var result in results)
        {
            yield return result;
        }

        //return Task.WhenEach(tasks);

        //Task.WaitAll(tasks);
        //return tasks.Select(t => t.Result);
        //return tasks.Select(async t => { return await t; });
    }

    public async Task DisplayAsync()
    {
        await foreach (var resultItem in GenerateBinariesAsync())
        {
            Console.WriteLine(resultItem);
        }
        //foreach(var resultItem in GenerateBinariesAsync())
        //{
        //    Console.WriteLine(resultItem);
        //}
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
