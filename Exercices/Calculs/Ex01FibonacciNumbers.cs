using System;

namespace Exercices.Calculs;

public class Ex01FibonacciNumbers : RunBase<int, long>
{
    public override int Init()
    {
        return 40;
    }

    public long IterativeFibo(int terme)
    {
        if (terme < 2)
            return terme;

        var beforeLast = 0L;  //n-2
        var last = 1L;  //n-1
        var currentIndex = 1;
        while (currentIndex++ < terme)
        {
            //var tempBeforeLast = beforeLast;
            //beforeLast = last;
            //last = tempBeforeLast + last; //last = beforeLast + last;
            (beforeLast, last) = (last, last + beforeLast);
        }

        return last;
    }

    public long RecursiveFibo(int terme)
    {
        if (terme < 2)
            return terme;

        return RecursiveFibo(terme - 1) + RecursiveFibo(terme - 2);
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

    public long RecursiveSpanMemoFibo(int index)
    {
        Span<long> fiboMemo = stackalloc long[index + 1];
        fiboMemo.Fill(-1);
        fiboMemo[0] = 0;
        fiboMemo[1] = 1;

        return InternalRecursiveFibo(fiboMemo, index);

        long InternalRecursiveFibo(in Span<long> memo, int index)
        {
            if (memo[index] >= 0)
                return memo[index];

            memo[index] = InternalRecursiveFibo(memo, index - 1) + InternalRecursiveFibo(memo, index - 2);
            return memo[index];
        }
    }

    public long TailResursiveFibo(int terme)
    {
        if (terme < 2)
            return terme;

        return InternalRecFibo(1, 0, 1);

        long InternalRecFibo(int currentIndex, long beforeLast /* n-2 */, long last /* n-1 */)
        {
            if (currentIndex >= terme)
                return last;

            return InternalRecFibo(currentIndex + 1, last, beforeLast + last);
        }
    }

    public long TailIterativeFibo(int n)
    {
        if (n < 2)
            return n;

        var (cur, l, bl) = (1, 1L, 0L);
        while (true)
        {
            if (cur == n)
                return l;
            (cur, l, bl) = (cur + 1, l + bl, l);
        }
    }

    public long LinqParallelFibo(int n)
    {
        if (n < 2)
            return n;

        return Enumerable.Range(2, n-1).AsParallel().Aggregate(new { Current = 1, Prev = 0 }, (x, _) => new { Current = x.Prev + x.Current, Prev = x.Current }).Current;
    }

    public long LinqParallelFiboV2(int n)
    {
        if (n < 2)
            return n;

        return Enumerable.Range(2, n-1).Aggregate((cur: 1, prev: 0), (acc, _) => (acc.cur + acc.prev, acc.cur)).cur;
    }

    public long ArrayFibo(int n)
    {
        Span<long> fiboValues = stackalloc long[n + 1];
        fiboValues[0] = 0;
        fiboValues[1] = 1;

        for (int i = 2; i <= n; i++)
            fiboValues[i] = fiboValues[i - 1] + fiboValues[i - 2];

        return fiboValues[n];
    }

    public override long Process()
    {
        return RecursiveMemoFibo(Input);
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Result: {0}", Output);
    }
}
