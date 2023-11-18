namespace Exploration.Threading;

/**
 * Solves the Monitor deadlock issue
 **/
internal class MonitorWaitPulseCoordinationV2
{
    static object phone = new object();

    private Thread workerThread;
    private Thread bossThread;

    public MonitorWaitPulseCoordinationV2()
    {
        workerThread = new Thread(WorkerThread);
        workerThread.Name = "Worker Thread";
        bossThread = new Thread(BossThread);
        bossThread.Name = "Boss Thread";
    }

    void WorkerThread()
    {
        lock (phone)
        {
            bossThread.Start();
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

    void BossThread()
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

    public void Run()
    {
        workerThread.Start();
    }
}
