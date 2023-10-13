class Program
{
    static async Task Main()
    {
        Console.WriteLine("Start of Main");

        // Crée une instance de HttpClient pour effectuer une requête asynchrone
        using (HttpClient client = new HttpClient())
        {
            // Utilise le mot-clé await pour attendre que la requête soit terminée
            string result = await client.GetStringAsync("https://www.google.com");

            Console.WriteLine("Received content length: {0}", result.Length);
        }

        Console.WriteLine("End of Main");
    }
}



//SolveRaceConditionOneThread.Run();