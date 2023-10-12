namespace Exploration.Threading;

internal class MonitorWaitPulseCoordination
{
    static object phone = new object();

    static void WorkerThread()
    {
        lock (phone)
        {
            for (int i = 0; i < 5; ++i)
            {
                Monitor.Wait(phone); //releases 'phone' lock and wait to be signaled
                Console.WriteLine("Travail en cours");
                Thread.Sleep(500);
                Console.WriteLine("Tâche effectuée");
                Monitor.Pulse(phone); //signals all waiting threads
            }
        }
    }
    
    static void BossThread()
    {
        lock (phone)
        {
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("Tâche assignée ");
                Monitor.Pulse(phone); //Pulse le thread en attente
                Monitor.Wait(phone); //relache le lock et attend un signal
            }
        }
    }

    public static void Run()
    {
        var thread1 = new Thread(WorkerThread);
        var thread2 = new Thread(BossThread);
        thread1.Start();
        thread2.Start();
    }
}
