namespace Exercices.Calculs;

internal class Ex01FibonacciNumbers : RunBase<int, long>
{
    public override int Init()
    {
        return 60;
    }

    public long IterativeFibo(int index)
    {
        if (index < 2)
            return index;

        var beforeLast = 0L;
        var last = 1L;
        var currentIndex = 1;
        while (currentIndex++ < index)
            (beforeLast, last) = (last, last + beforeLast);

        return last;
    }

    public long RecursiveFibo(int index)
    {
        if (index < 2)
            return index;

        return RecursiveFibo(index - 1) + RecursiveFibo(index - 2);
    }

    public long RecursiveMemoFibo(int index)
    {
        long[] fiboMemo = new long[index+1];
        Array.Fill(fiboMemo, -1);
        fiboMemo[0] = 0;
        fiboMemo[1] = 1;

        return InternalRecursiveFibo(index);

        long InternalRecursiveFibo(int index) {
            if (fiboMemo[index] >= 0)
                return fiboMemo[index];

            fiboMemo[index] = InternalRecursiveFibo(index - 1) + InternalRecursiveFibo(index - 2);
            return fiboMemo[index];
        }
    }

    public long TailResursiveFibo(int fiboIndex)
    {
        if (fiboIndex < 2)
            return fiboIndex;

        return InternalRecFibo(1, 0, 1);

        long InternalRecFibo(int currentIndex, long beforeLast, long last)
        {
            if (currentIndex >= fiboIndex)
                return last;

            return InternalRecFibo(currentIndex + 1, last, beforeLast + last);
        }
    }

    public override long Process(int input)
    {
        return RecursiveMemoFibo(input);
    }

    public override void DisplayResult(long output)
    {
        Console.WriteLine("Result: {0}", output);
    }
}
