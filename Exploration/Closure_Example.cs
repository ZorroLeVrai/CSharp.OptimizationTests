namespace Exploration;

internal static class Closure_Example
{
    private static void DisplayGetters(Func<Tool>[] getterArray, Action<Tool> display)
    {
        foreach (var getter in getterArray)
        {
            display(getter());
        }
    }

    public static void Run()
    {
        var arrayLength = 10;
        var getters = new Func<Tool>[arrayLength];
        for (int i = 0; i < arrayLength; ++i)
        {
            Tool tool = new Tool((char)('A' + i), i);
            getters[i] = getter;

            Tool getter() => tool;
        }

        DisplayGetters(getters, Console.WriteLine);
    }

    private record Tool(char Name, decimal Price);
}
