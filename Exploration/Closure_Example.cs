namespace Exploration;

internal static class Closure_Example
{
    public static void Run()
    {
        var arrayLength = 10;
        var getters = new Func<int>[arrayLength];
        for (int i = 0; i < arrayLength; ++i)
        {
            getters[i] = () => i;
        }

        //DisplayGetters(getters, Console.WriteLine);
        foreach (var getter in getters)
            Console.WriteLine(getter());
    }

    private record Tool(char Name, decimal Price);
}
