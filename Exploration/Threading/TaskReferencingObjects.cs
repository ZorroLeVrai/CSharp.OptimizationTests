namespace Exploration.Threading;

internal class TaskReferencingObjects
{
    public void Run()
    {
        var task = CreateHeavyTask(20_000);
        task.Wait();

        var task2 = CreateWaitingTask(60_000);
        task2.Wait();

        Console.WriteLine("End of the program");
        Console.ReadLine();
    }

    public Task<int> CreateHeavyTask(int timeInMs)
    {
        var charTab = new char[10_000_000];
        var index = 0;
        foreach (char c in charTab)
        {
            charTab[index++] = c;
        }

        return Task.Run(() =>
        {
            Thread.Sleep(timeInMs);
            //the captured `charTab` variable is released once this method has been executed
            //20Mb of memory to release
            return charTab.Length;
        });
    }

    public Task CreateWaitingTask(int timeInMs)
    {
        return Task.Run(() => Thread.Sleep(timeInMs));
    }
}
