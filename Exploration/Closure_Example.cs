namespace Exploration;

internal static class Closure_Example
{
    public static void Run()
    {
        var arrayLength = 10;
        var getters = new Func<int>[arrayLength];

        var collection = Enumerable.Range(0,10).ToList();
        var collection_enum = new IEnumerable<string>[arrayLength];

        for (int i = 0; i < arrayLength; ++i)
        {
            var loc_i = i;

            getters[i] = () => maFunc(loc_i);

            collection_enum[i] = collection
                .Where(e => e > i)
                .Select(e => e.ToString());

            static int maFunc(int nb)
            {
                return nb;
            }
        }

        foreach (var getter in getters)
            Console.WriteLine(getter());

        for (int i = 0; i < arrayLength; ++i)
        {
            Console.WriteLine($"{i} => {string.Join(",", collection_enum[i])}");
        }
    }

    private record Tool(char Name, decimal Price);
}
