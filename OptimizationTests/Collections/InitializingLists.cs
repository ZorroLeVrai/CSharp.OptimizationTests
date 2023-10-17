using System.Collections.Generic;

namespace OptimizationTests.Collections;

public static class InitializingLists
{
    public static IEnumerable<int> GetInitializedList(int listSize, bool reserveSpace)
    {
        var list = reserveSpace ? new List<int>(listSize) : new List<int>();
        for (int i = 0; i< listSize; ++i)
        {
            list.Add(i);
        }

        return list;
    }

    public static IEnumerable<int> GetInitializedArray(int arraySize)
    {
        var array = new int[arraySize];
        for (int i = 0; i < arraySize; ++i)
        {
            array[i] = i;
        }

        return array;
    }

    public static void InitializeSpan(Span<int> numbers, int spanSize)
    {
        for (int i = 0; i < spanSize; ++i)
        {
            numbers[i] = i;
        }
    }

    public static void InitializeSpanWithRef(in Span<int> numbers, int spanSize)
    {
        for (int i = 0; i < spanSize; ++i)
        {
            numbers[i] = i;
        }
    }
}
