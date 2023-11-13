namespace Exploration.PerfView;

internal class Additions
{
    static int FastAdd(int a, int b)
    {
        return a + b;
    }

    static int SlowAdd(int a, int b)
    {
        long sum = 1;

        for (int j = 0; j < 10_000_000; ++j)
        {
            sum *= j;
        }

        return a + b;
    }

    public static void Main()
    {
        int result = 0;
        for (int i = 0; i < 20; ++i)
        {
            if (i % 10 == 0)
                result = SlowAdd(1, 2);
            else
                result = FastAdd(1, 2);
        }

        Console.WriteLine("Result: {0}", result);
    }
}
