namespace DistantWebApp.Services;

public static class ConverterService
{
    static private Random random = new Random();

    public async static Task<string> IntToBinaryAsync(int value, CancellationToken ct)
    {
        var rand = random.Next(500, 4000); // Simulate some delay
        // Simulate a delay to mimic a long-running operation
        await Task.Delay(rand, ct);
        return Convert.ToString(value, 2);
    }
}