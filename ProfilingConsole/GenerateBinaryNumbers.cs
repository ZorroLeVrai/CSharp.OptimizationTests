namespace ConsoleApp;

internal class GenerateBinaryNumbers
{
    static Random random = new Random();

    public static IEnumerable<string> GenerateBinaries(int nbNumbers)
    {
        for (int i = 0; i < nbNumbers; ++i)
        {
            int randonNumber = random.Next(256);
            yield return GetBinary(randonNumber);
        }

        string GetBinary(int number)
        {
            using HttpClient client = new();

            client.BaseAddress = new Uri("https://localhost:7014/");
            var url = string.Concat("api/IntToBinary/", number);

            try
            {
                return client.GetStringAsync(url)
                    .Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
