namespace Exploration.PerfView;

public class WaitBeforePrinting
{
    private readonly int _waitTimeInMs = 5000;

    public WaitBeforePrinting(int timeInMs)
    {
        _waitTimeInMs = timeInMs;
    }

    private void PrintEndMessage()
    {
        Console.WriteLine("Programme terminé");
    }

    public void WaitInALoop()
    {
        var startTime = DateTime.Now;
        var currentTime = DateTime.Now;
        while ((currentTime - startTime).TotalMilliseconds < _waitTimeInMs)
            currentTime = DateTime.Now;

        PrintEndMessage();
    }

    public void SychronousWait()
    {
        Thread.Sleep(_waitTimeInMs);
        PrintEndMessage();
    }

    public async Task AsychronousWait()
    {
        await Task.Delay(_waitTimeInMs);
        PrintEndMessage();
    }
}
