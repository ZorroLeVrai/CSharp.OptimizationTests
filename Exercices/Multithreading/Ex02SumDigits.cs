namespace Exercices.Multithreading;

public class Ex02SumDigits : RunBase<int[], InputOutputResult[]>
{
    private const int NB_ELEMENTS = 10;
    private const int MAX_VALUE_TO_PROCESS = 1000;
    private InputOutputResult?[] _cachedResult = new InputOutputResult?[MAX_VALUE_TO_PROCESS];

    public override int[] Init()
    {
        InitCache();
        return GenerateNumbers(NB_ELEMENTS);
    }

    public void InitCache()
    {
        Array.Fill(_cachedResult, null);
        //for (int i = 0; i< MAX_VALUE_TO_PROCESS; i++)
        //{
        //    _cachedResult[i] = ProcessNumber(i);
        //}
    }

    private InputOutputResult GetFromCache(int index)
    {
        if (_cachedResult[index] == null)
        {
            Interlocked.Exchange(ref _cachedResult[index], ProcessNumber(index));
        }

        return _cachedResult[index] ?? throw new InvalidOperationException("Cached result is null for index " + index);
    }

    public int[] GenerateNumbers(int nb)
        => new NumberGenerator(0, MAX_VALUE_TO_PROCESS)
            .GenerateNumbers(nb);

    private InputOutputResult ProcessNumber(int number)
    {
        return new InputOutputResult(number, RecSumDigits(number, 0));

        int RecSumDigits(int number, int currentSum)
        {
            if (number < 10)
                return number + currentSum;

            var (quotient, remainder) = Math.DivRem(number, 10);
            return RecSumDigits(quotient, currentSum + remainder);
        }
    }

    private InputOutputResult[] InternalSimpleCompute(int[] inputElements, bool useCache)
    {
        var result = new InputOutputResult[inputElements.Length];
        if (useCache)
        {
            for (int i = 0; i < inputElements.Length; ++i)
                result[i] = GetFromCache(inputElements[i]);
        }
        else
        {
            for (int i = 0; i < inputElements.Length; ++i)
                result[i] = ProcessNumber(inputElements[i]);
        }
        return result;
    }

    public InputOutputResult[] SimpleCompute(int[] inputElements)
        => InternalSimpleCompute(inputElements, false);

    public InputOutputResult[] SimpleWithCacheCompute(int[] inputElements)
        => InternalSimpleCompute(inputElements, true);

    public InputOutputResult[] InternalParallelCompute(int[] inputElements, bool useCache)
    {
        var result = new InputOutputResult[inputElements.Length];
        if (useCache)
        {
            Parallel.For(0, inputElements.Length, i =>
            {
                result[i] = GetFromCache(inputElements[i]);
            });
        }
        else
        {
            Parallel.For(0, inputElements.Length, i =>
            {
                result[i] = ProcessNumber(inputElements[i]);
            });
            
        }
        return result;
    }

    public InputOutputResult[] ParallelCompute(int[] inputElements)
        => InternalParallelCompute(inputElements, false);

    public InputOutputResult[] ParallelWithCacheCompute(int[] inputElements)
        => InternalParallelCompute(inputElements, true);

    public InputOutputResult[] ParallelWithOptionsCompute(int[] inputElements)
    {
        var result = new InputOutputResult[inputElements.Length];
        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 100
        };
        Parallel.For(0, inputElements.Length, parallelOptions, i =>
        {
            result[i] = ProcessNumber(inputElements[i]);
        });
        return result;
    }

    public InputOutputResult[] TasksCompute(int[] inputElements)
    {
        var result = new InputOutputResult[inputElements.Length];
        var tasks = new Task[inputElements.Length];
        for (int i = 0; i < inputElements.Length; ++i)
        {
            var locIndex = i;
            tasks[locIndex] = Task.Run(() => result[locIndex] = ProcessNumber(inputElements[locIndex]));
        }
            
        Task.WaitAll(tasks);
        return result;
    }

    private InputOutputResult[] InternalSplitTasksCompute(int[] inputElements, bool useCache)
    {
        var result = new InputOutputResult[inputElements.Length];
        const int nbSplits = 100;
        Task[] tasks = new Task[nbSplits];

        var nbTermsInSplit = ((double)inputElements.Length) / nbSplits;

        for (int i = 0; i < nbSplits; ++i)
        {
            var minTerme = (uint)(i * nbTermsInSplit);
            var maxTerme = (uint)((i + 1) * nbTermsInSplit);
            if (useCache)
                tasks[i] = Task.Run(() => ProcessRangeWithCache(minTerme, maxTerme));
            else
                tasks[i] = Task.Run(() => ProcessRange(minTerme, maxTerme));
        }

        Task.WaitAll(tasks);

        return result;

        void ProcessRange(uint fromInclusive, uint toExclusive)
        {
            for (uint i = fromInclusive; i < toExclusive; ++i)
                result[i] = ProcessNumber(inputElements[i]);
        }

        void ProcessRangeWithCache(uint fromInclusive, uint toExclusive)
        {
            for (uint i = fromInclusive; i < toExclusive; ++i)
                result[i] = GetFromCache(inputElements[i]);
        }
    }

    public InputOutputResult[] SplitTasksCompute(int[] inputElements)
        => InternalSplitTasksCompute(inputElements, false);

    public InputOutputResult[] SplitTasksWithCacheCompute(int[] inputElements)
        => InternalSplitTasksCompute(inputElements, true);

    public override InputOutputResult[] Process()
    {
        if (Input == null)
            throw new Exception("Input is null");
        return SplitTasksWithCacheCompute(Input);
    }

    public override void DisplayResult()
    {
        if (Output == null)
            throw new Exception("Output is null");
        for (int i=0; i<NB_ELEMENTS; ++i)
            Console.WriteLine(Output[i]);
    }
}