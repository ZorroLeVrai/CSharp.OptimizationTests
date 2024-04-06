namespace Exercices.Multithreading;

public class Ex01SommeInverse : RunBase<uint, double>
{
    private const uint NB_TERME = 100_000_000;

    public override uint Init()
    {
        return NB_TERME;
    }

    public double SimpleProcess(uint nbTerme)
    {
        double sum = 0;
        for (long i = 1; i <= nbTerme; ++i)
            sum += 1.0 / i;

        return sum;
    }

    public double SimpleLinqProcess(uint nbTerme)
    {
        var inbTerme = (int)nbTerme;
        return Enumerable.Range(1, inbTerme)
            .Sum(x => 1.0 / x);
    }

    public double ParallelLinqProcess(uint nbTerme)
    {
        var inbTerme = (int)nbTerme;
        return Enumerable.Range(1, inbTerme)
            .AsParallel()
            .Sum(x => 1.0 / x);
    }

    public double ParallelWithMaxDegreeWithLock(uint nbTerme, int nbParallelism)
    {
        object obj = new object();
        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = nbParallelism
        };

        double sum = 0;
        Parallel.For(1, (int)nbTerme+1, parallelOptions, i =>
        {
            lock(obj)
            {
                sum += 1 / i;
            }
        });

        return sum;
    }

    public double ParallelWithMaxDegreeWithSpinLock(uint nbTerme, int nbParallelism)
    {
        var spinLock = new SpinLock();
        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = nbParallelism
        };

        double sum = 0;
        Parallel.For(1, (int)nbTerme + 1, parallelOptions, i =>
        {
            var lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);
                sum += 1 / i;
            }
            finally
            {
                if (lockTaken)
                    spinLock.Exit();
            }
        });

        return sum;
    }

    public double SplitParallelProcess(uint nbTerme)
    {
        const int nbSplits = 1000;
        Task<double>[] tasks = new Task<double>[nbSplits];

        var nbTermsInSplit = ((double)nbTerme)/nbSplits;

        for (int i = 0; i < nbSplits; ++i)
        {
            var minTerme = (uint)(i * nbTermsInSplit + 1);
            var maxTerme = (uint)((i + 1) * nbTermsInSplit);
            tasks[i] = Task.Run<double>(() => ProcessWithBoundaries(minTerme, maxTerme));
        }

        Task.WaitAll(tasks);

        return tasks.Sum(task => task.Result);


        double ProcessWithBoundaries(uint minTerme, uint maxTerme)
        {
            double sum = 0;
            for (uint i = minTerme; i <= maxTerme; ++i)
                sum += 1.0 / i;
            
            return sum;
        }
    }

    public double SplitParallelProcessV2(uint nbTerme)
    {
        const int nbSplits = 1000;
        var intermediateResults = new double[nbSplits];
        var nbTermsInSplit = ((double)nbTerme) / nbSplits;

        Parallel.For(0, nbSplits, (i, state) =>
        {
            var minTerme = (uint)(i * nbTermsInSplit + 1);
            var maxTerme = (uint)((i + 1) * nbTermsInSplit);
            intermediateResults[i] = ProcessWithBoundaries(minTerme, maxTerme);
        });

        return intermediateResults.Sum();

        double ProcessWithBoundaries(uint minTerme, uint maxTerme)
        {
            double sum = 0;
            for (uint i = minTerme; i <= maxTerme; ++i)
                sum += 1.0 / i;

            return sum;
        }
    }

    public override double Process()
    {
        return SplitParallelProcess(Input);
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Resultat: {0}", Output);
    }

    public void CompareResults()
    {
        Console.WriteLine("SimpleProcess: {0}", SimpleProcess(NB_TERME));

        Console.WriteLine("SimpleLinqProcess: {0}", SimpleLinqProcess(NB_TERME));

        Console.WriteLine("ParallelLinqProcess: {0}", ParallelLinqProcess(NB_TERME));

        Console.WriteLine("SplitParallelProcess: {0}", SplitParallelProcess(NB_TERME));
    }
}
