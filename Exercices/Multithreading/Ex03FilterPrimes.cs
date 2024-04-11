namespace Exercices.Multithreading;

public class Ex03FilterPrimes : RunBase<int[], HashSet<int>>
{
    private const int NB_ELEMENTS = 20;
    private const int MAX_VALUE_TO_PROCESS = 1000_000;
    private HashSet<int> _cachedPrimes = new();

    public override int[] Init()
    {
        InitCache();
        return GenerateNumbers(NB_ELEMENTS);
    }

    public void InitCache()
    {
        _cachedPrimes = GetFirstPrimeNumbers(MAX_VALUE_TO_PROCESS)
            .ToHashSet();
    }

    public int[] GenerateNumbers(int nb)
        => new NumberGenerator(2, MAX_VALUE_TO_PROCESS)
            .GenerateNumbers(nb);

    private static IEnumerable<int> GetFirstPrimeNumbers(int maxNumber)
    {
        if (maxNumber < 2)
            return Enumerable.Empty<int>();

        var primeNumbers = new List<int>() { 2 };
        var currentNumber = 3;
        while (currentNumber <= maxNumber)
        {
            if (internalIsPrime(primeNumbers, currentNumber))
                primeNumbers.Add(currentNumber);

            currentNumber += 2;
        }

        return primeNumbers;

        static bool internalIsPrime(IReadOnlyList<int> primeNumbers, int number)
        {
            var index = 0;
            while (index < primeNumbers.Count && Square(primeNumbers[index]) <= number)
            {
                if (number % primeNumbers[++index] == 0)
                    return false;
            }

            return true;
        }
    }

    private static long Square(long num) => num * num;

    public bool isPrime(int number)
    {
        for (int i = 2; Square(i) <= number; ++i)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    private HashSet<int> InternalSimpleCompute(int[] inputElements, bool useCache)
    {
        var result = new HashSet<int>();
        if (useCache)
        {
            for (int i = 0; i < inputElements.Length; ++i)
            {
                if (_cachedPrimes.Contains(inputElements[i]))
                    result.Add(inputElements[i]);
            }

        }
        else
        {
            for (int i = 0; i < inputElements.Length; ++i)
            {
                if (isPrime(inputElements[i]))
                    result.Add(inputElements[i]);
            }
                
        }
        return result;
    }

    public HashSet<int> SimpleCompute(int[] inputElements)
        => InternalSimpleCompute(inputElements, false);

    public HashSet<int> SimpleWithCacheCompute(int[] inputElements)
        => InternalSimpleCompute(inputElements, true);

    private HashSet<int> InternalParallelCompute(int[] inputElements, bool useCache)
    {
        var tempResult = new int[inputElements.Length];
        Array.Fill(tempResult, 0);

        if (useCache)
        {
            Parallel.For(0, inputElements.Length, i =>
            {
                if (_cachedPrimes.Contains(inputElements[i]))
                    tempResult[i] = inputElements[i];
            });
        }
        else
        {
            Parallel.For(0, inputElements.Length, i =>
            {
                if (isPrime(inputElements[i]))
                    tempResult[i] = inputElements[i];
            });

        }

        return tempResult
            .Where(item => item != 0)
            .ToHashSet();
    }

    public HashSet<int> ParallelCompute(int[] inputElements)
        => InternalParallelCompute(inputElements, false);

    public HashSet<int> ParallelWithCacheCompute(int[] inputElements)
        => InternalParallelCompute(inputElements, true);

    private HashSet<int> InternalSplitTasksCompute(int[] inputElements, bool useCache)
    {
        var tempResult = new int[inputElements.Length];
        Array.Fill(tempResult, 0);
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

        return tempResult
            .Where(item => item != 0)
            .ToHashSet();

        void ProcessRange(uint fromInclusive, uint toExclusive)
        {
            for (uint i = fromInclusive; i < toExclusive; ++i)
            {
                if (isPrime(inputElements[i]))
                    tempResult[i] = inputElements[i];
            }
        }

        void ProcessRangeWithCache(uint fromInclusive, uint toExclusive)
        {
            for (uint i = fromInclusive; i < toExclusive; ++i)
            {
                if (_cachedPrimes.Contains(inputElements[i]))
                    tempResult[i] = inputElements[i];
            }
        }
    }

    public HashSet<int> SplitTasksCompute(int[] inputElements)
        => InternalSplitTasksCompute(inputElements, false);

    public HashSet<int> SplitTasksWithCacheCompute(int[] inputElements)
        => InternalSplitTasksCompute(inputElements, true);

    public override HashSet<int> Process()
    {
        if (Input == null)
            throw new Exception("Input is null");
        return SplitTasksWithCacheCompute(Input);
    }

    public override void DisplayResult()
    {
        if (Output == null)
            throw new Exception("Output is null");
        foreach (var item in Output)
            Console.WriteLine(item);
    }
}
