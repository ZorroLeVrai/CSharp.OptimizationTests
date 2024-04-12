namespace DistantWebApp.Services;

public static class ConverterService
{
    public async static Task<string> IntToBinaryAsync(int value)
    {
        await Task.Delay(1000);
        return Convert.ToString(value, 2);
    }
}