namespace DistantWebApp.Services;

public static class ConverterService
{
    static private Random random = new Random();

    public static string IntToBinary(int value)
    {
        var rand = random.Next(500, 4000); // Simulate some delay
        Task.Delay(rand).Wait();
        return Convert.ToString(value, 2);
    }
}