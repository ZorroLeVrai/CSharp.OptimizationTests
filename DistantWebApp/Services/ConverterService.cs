namespace DistantWebApp.Services;

public static class ConverterService
{
    public static string IntToBinary(int value)
    {
        Task.Delay(1000).Wait();
        return Convert.ToString(value, 2);
    }
}