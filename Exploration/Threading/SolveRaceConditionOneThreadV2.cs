using System.Diagnostics;

namespace Exploration.Threading;

internal class SolveRaceConditionOneThreadV2
{
    const int NB_ITERATION = 100_000;
    private static SharedCounter _sharedCounter = new SharedCounter();

    public static async Task Run()
    {
        var sw = new Stopwatch();
        sw.Start();

        try
        {
            var incTask = Task.Run(() => ModifyCounter(1, NB_ITERATION));
            var decTask = Task.Run(() => ModifyCounter(-1, NB_ITERATION));

            Task.WaitAll(incTask, decTask);
            Console.WriteLine($"sharedCounter: {await _sharedCounter.GetCounter()}");
        }
        finally
        {
            sw.Stop();
        }

        Console.WriteLine("Elapsed Time: {0}ms", sw.ElapsedMilliseconds);

        async Task ModifyCounter(int nb, int nbIteration)
        {
            for (int i = 0; i < nbIteration; ++i)
            {
                await _sharedCounter.AddToCounter(nb);
            }
        }
    }


    private class SharedCounter
    {
        private int _sharedCounter = 0;
        private LimitedConcurrencyLevelTaskScheduler _lcts;
        private CancellationTokenSource _tokenSource;
        private CancellationToken _cancellationToken;

        public SharedCounter()
        {
            _lcts = new LimitedConcurrencyLevelTaskScheduler(1);
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
        }

        public async Task<int> GetCounter()
        {
            return await Task<int>.Factory.StartNew((obj) => ((SharedCounter)obj!)._sharedCounter, this, _cancellationToken, TaskCreationOptions.None, _lcts);
        }

        public async Task AddToCounter(int nb)
        {
            await Task.Factory.StartNew(AddToMyCounter, this, _cancellationToken, TaskCreationOptions.None, _lcts);

            void AddToMyCounter(object? obj)
            {
                SharedCounter sc = ((SharedCounter)obj!);
                sc._sharedCounter += nb;
            }
        }
    }
}
