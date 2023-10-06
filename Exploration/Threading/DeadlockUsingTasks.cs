namespace Exploration.Threading;

internal class DeadlockUsingTasks
{
    static object lock1 = new object();
    static object lock2 = new object();

    public static void Run()
    {
        var task1 = Task.Factory.StartNew(() =>
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1 acquired lock 1");
                Thread.Sleep(100);

                lock (lock2) {
                    Console.WriteLine("Thread 1 acquired lock 2");
                }
            }
        });

        var task2 = Task.Factory.StartNew(() =>
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2 acquired lock 2");
                Thread.Sleep(100);

                lock (lock1)
                {
                    Console.WriteLine("Thread 2 acquired lock 1");
                }
            }
        });

        Task.WaitAll(task1, task2);
    }
}
