namespace Exploration.PerfView;

internal class WaitBeforePrinting
{
    private const int waitTimeInMs = 5000;

    private static void PrintEndMessage()
    {
        Console.WriteLine("Programme terminé");
    }

    public static void WaitInALoop()
    {
        var startTime = DateTime.Now;
        var currentTime = DateTime.Now;
        while ((currentTime - startTime).TotalSeconds < 5)
            currentTime = DateTime.Now;

        PrintEndMessage();
    }

    public static void SychronousWait()
    {
        Thread.Sleep(waitTimeInMs);

        PrintEndMessage();
    }

    public async static void AsychronousWait()
    {
        await Task.Delay(waitTimeInMs);

        PrintEndMessage();
    }

}
