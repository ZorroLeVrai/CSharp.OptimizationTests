namespace Exploration.Threading;

internal class AutoResetEventCoordination
{
    private static AutoResetEvent resetEvent = new AutoResetEvent(false);

    static void WaitAndPrint(object? threadNameObj)
    {
        var threadName = (string)(threadNameObj ?? string.Empty);
        Console.WriteLine("{0} en attente qu'un événement soit reçu", threadName);
        resetEvent.WaitOne();
        Console.WriteLine("{0} continue après que l'événement ait été reçu", threadName);

        Thread.Sleep(2000);

        //l'appel au Set() est obligatoire pour notifier le thread suivant
        resetEvent.Set();
    }

    static void SetEvent()
    {
        Thread.Sleep(4000); // simule un travail
        Console.WriteLine("Le thread définit l'événement");
        resetEvent.Set();
    }

    public static void Run()
    {
        //démarre les 2 threads en attente
        for (int i = 0; i < 2; ++i)
        {
            var thread = new Thread(WaitAndPrint);
            thread.Start($"Thread {i + 1}");
        }

        //démarre le thread qui va définir l'événement
        var threadSetEvent = new Thread(SetEvent);
        threadSetEvent.Start();
    }
}
