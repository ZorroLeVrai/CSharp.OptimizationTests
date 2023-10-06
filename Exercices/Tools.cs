namespace Exercices;

internal static class Tools
{
    public static string ToPrettyString<T>(this IEnumerable<T> items)
    {
        return string.Format("[{0}]", string.Join(", ", items));
    }

    public static string ToPrettyString<TKey, TValue>(this Dictionary<TKey, TValue> items) where TKey : notnull
    {
        return string.Format("[{0}]", string.Join(", \n", items.Select(item => $"{item.Key}: {item.Value}")));
    }
}
