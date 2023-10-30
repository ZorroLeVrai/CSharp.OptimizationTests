namespace Exercices.Calculs;

internal class Ex02FibonacciSeries : RunBase<int, IEnumerable<long>>
{
    public override int Init()
    {
        return 60;
    }

    public override IEnumerable<long> Process()
    {
        yield return 0;
        if (Input == 0)
            yield break;
        yield return 1;

        var beforeLast = 0L;
        var last = 1L;
        var currentIndex = 1;
        
        while (currentIndex++ < Input)
        {
            (beforeLast, last) = (last, last + beforeLast);
            yield return last;
        }

        yield break;
    }

    public override void DisplayResult()
    {
        if (Output is null)
            return;

        int index = 0;
        foreach (var fiboNumber in Output) {
            Console.WriteLine($"fibonacci({index++}): {fiboNumber}");
        }
    }
}