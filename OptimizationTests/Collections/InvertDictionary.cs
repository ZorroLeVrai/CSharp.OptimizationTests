namespace OptimizationTests.Collections;

public class InvertDictionary
{
    public static Dictionary<TOut, TIn[]> InvertDictionaryUsingLinq<TIn, TOut>(Dictionary<TIn, TOut> inputDictionary)
        where TIn : notnull
        where TOut : notnull
    {
        var resultDico = inputDictionary.ToLookup(item => item.Value, item => item.Key)
            .ToDictionary(item => item.Key, item => item.ToArray());

        return resultDico;
    }

    public static Dictionary<TOut, List<TIn>> InvertDictionarySimpleCode<TIn, TOut>(Dictionary<TIn, TOut> inputDictionary)
        where TIn : notnull
        where TOut : notnull
    {
        var resultDico = new Dictionary<TOut, List<TIn>>();
        foreach (var (key, val) in inputDictionary)
        {
            if (resultDico.TryGetValue(val, out var valueList))
            {
                valueList.Add(key);
            }
            else
            {
                resultDico.Add(val, new List<TIn>() { key });
            }
        }

        return resultDico;
    }
}
