namespace Exploration.Threading;

internal class DeadlockUsingThreads
{
    static object lock1 = new object();
    static object lock2 = new object();

    public static void Run()
    {
        Thread t1 = new Thread(() =>
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1: Holding lock 1...");
                Thread.Sleep(1000); // Simulate some work

                Console.WriteLine("Thread 1: Waiting for lock 2...");
                lock (lock2)
                {
                    Console.WriteLine("Thread 1: Acquired lock 2");
                }
            }
        });
        t1.Name = "t1";

        Thread t2 = new Thread(() =>
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2: Holding lock 2...");
                Thread.Sleep(1000); // Simulate some work

                Console.WriteLine("Thread 2: Waiting for lock 1...");
                lock (lock1)
                {
                    Console.WriteLine("Thread 2: Acquired lock 1");
                }
            }
        });
        t2.Name = "t2";

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine("Both threads completed.");
    }
}
