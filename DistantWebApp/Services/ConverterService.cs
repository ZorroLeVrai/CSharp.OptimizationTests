namespace DistantWebApp.Services;

public static class ConverterService
{
    static private Random random = new Random();

    public async static Task<string> IntToBinaryAsync(int value)
    {
        var rand = random.Next(500, 4000); // Simulate some delay
        await Task.Delay(rand);
        return Convert.ToString(value, 2);
    }
}