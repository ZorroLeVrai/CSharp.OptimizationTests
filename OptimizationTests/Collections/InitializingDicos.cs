namespace OptimizationTests.Collections;

public static class InitializingDicos
{
    public static IEnumerable<KeyValuePair<string, int>> GetInitializedDico(int listSize, bool reserveSpace)
    {
        var dico = reserveSpace ? new Dictionary<string, int>(listSize) : new Dictionary<string, int>();
        for (int i = 0; i < listSize; ++i)
        {
            dico.Add(i.ToString("X"), i);
        }

        return dico;
    }

    public static IEnumerable<KeyValuePair<string, int>> GetInitializedListKeyValuePair(int listSize)
    {
        var list = new List<KeyValuePair<string, int>>(listSize);
        for (int i = 0; i < listSize; ++i)
        {
            list.Add(new KeyValuePair<string, int>(i.ToString("X"), i));
        }

        return list;
    }

    public static IEnumerable<KeyValuePair<string, int>> GetInitializedArrayKeyValuePair(int listSize)
    {
        var array = new KeyValuePair<string, int>[listSize];
        for (int i = 0; i < listSize; ++i)
        {
            array[i] = new KeyValuePair<string, int>(i.ToString("X"), i);
        }

        return array;
    }
}
