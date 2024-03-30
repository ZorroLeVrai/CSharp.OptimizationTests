namespace Exercices.Calculs;

public class Ex02FibonacciSeries : RunBase<int, IEnumerable<long>>
{
    public override int Init()
    {
        return 60;
    }

    private IEnumerable<long> FibonacciIterator()
    {
        yield return 0;
        yield return 1;

        var beforeLast = 0L;
        var last = 1L;

        while (true)
        {
            (beforeLast, last) = (last, last + beforeLast);
            yield return last;
        }
    }

    public IEnumerable<long> ComputeUsingIterator(int nbTerm)
    {
        var fiboArray = new long[nbTerm+1];
        var currentIndex = 0;
        foreach (var fiboTerm in FibonacciIterator())
        {
            fiboArray[currentIndex++] = fiboTerm;
            if (currentIndex > nbTerm)
                break;
        }

        return fiboArray;
    }

    public IEnumerable<long> ComputeUsingArray(int nbTerm)
    {
        var fiboArray = new long[nbTerm+1];
        for (int i = 0; i <= nbTerm; ++i)
        {
            if (i < 2)
                fiboArray[i] = i;
            else
                fiboArray[i] = fiboArray[i - 1] + fiboArray[i - 2];
        }

        return fiboArray;
    }

    public override IEnumerable<long> Process()
    {
        return ComputeUsingIterator(Input);
    }


    public override void DisplayResult()
    {
        if (Output is null)
            return;

        int index = 0;
        foreach (var fiboNumber in Output) {
            Console.WriteLine($"fibonacci({index++}): {fiboNumber:n0}");
        }
    }
}