namespace DistantWebApp.Services;

public static class ConverterService
{
    public static string IntToBinary(int value)
    {
        //Task.Delay(1000);
        Thread.Sleep(1000);
        return Convert.ToString(value, 2);
    }
}