namespace Exercices.Multithreading;

public class Ex01SommeInverse : RunBase<uint, double>
{
    private const uint NB_TERME = 1_000_000_000;

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

    public override double Process()
    {
        return SimpleLinqProcess(Input);
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
