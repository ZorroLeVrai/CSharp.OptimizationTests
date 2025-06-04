namespace Exercices.Asynchrones;

internal class GenerateBinaryBase
{
    protected Random _random = new();
    protected int _nbToGenerate;

    public GenerateBinaryBase(int nbToGenerate)
    {
        _nbToGenerate = nbToGenerate;
    }

    protected string GetBinary(int number)
    {
        using HttpClient client = new();

        client.BaseAddress = new Uri("https://localhost:7014/");
        var url = string.Concat("api/IntToBinary/", number);

        try
        {
            return client.GetStringAsync(url).Result;
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

    private IEnumerable<string> GenerateBinaries()
    {
        var results = new string[_nbToGenerate];

        for (int i = 0; i < _nbToGenerate; ++i)
        {
            int randomNumber = _random.Next(256);
            results[i] = GetBinary(randomNumber);
        }

        return results;
    }

    public void Display()
    {
        var result = GenerateBinaries().ToArray();
        foreach (var binary in result)
        {
            Console.WriteLine(binary);
        }
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

