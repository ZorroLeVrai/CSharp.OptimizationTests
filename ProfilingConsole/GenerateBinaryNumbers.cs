namespace ConsoleApp;

internal class GenerateBinaryNumbers
{
    static Random random = new Random();

    public async static IAsyncEnumerable<string> GenerateBinariesAsync(int nbNumbers)
    {
        for (int i = 0; i < nbNumbers; ++i)
        {
            int randonNumber = random.Next(256);
            yield return await GetBinaryAsync(randonNumber);
        }
    }


    public async static IAsyncEnumerable<string> GenerateParallelBinariesAsync(int nbNumbers)
    {
        var tasks = new Task<string>[nbNumbers];
        for (int i = 0; i < nbNumbers; ++i)
        {
            int randonNumber = random.Next(256);
            tasks[i] = GetBinaryAsync(randonNumber);
        }

        for (int i = 0; i < nbNumbers; ++i)
        {
            yield return await tasks[i];
        }

        //Task.WaitAll(tasks);
        //return tasks.Select(t => t.Result).ToArray();
    }

    public static Task<string>[] GenerateParallelBinaries(int nbNumbers)
    {
        var tasks = new Task<string>[nbNumbers];
        for (int i = 0; i < nbNumbers; ++i)
        {
            int randonNumber = random.Next(256);
            tasks[i] = GetBinaryAsync(randonNumber);
        }

        Task.WaitAll(tasks);

        return tasks;
    }

    public static void GenerateBinariesAsap(int nbNumbers)
    {
        Task[] tasks = new Task[nbNumbers];

        for (int i = 0; i < nbNumbers; ++i)
        {
            int randomNumber = random.Next(256);
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

    static async Task<string> GetBinaryAsync(int number)
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
