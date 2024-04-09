namespace Exploration.PerfView;

public class Additions
{
    private readonly int _slowNbLoop;

    public Additions(int slowNbLoop)
    {
        _slowNbLoop = slowNbLoop;
    }

    int FastAdd(int a, int b)
    {
        return a + b;
    }

    int SlowAdd(int a, int b)
    {
        long sum = 1;

        for (int j = 0; j < _slowNbLoop; ++j)
        {
            sum += j;
        }

        return a + b;
    }

    public void Main()
    {
        int result = 0;
        for (int i = 0; i < 50; ++i)
        {
            if (i % 10 == 0)
                result = SlowAdd(1, 2);
            else
                result = FastAdd(1, 2);
        }

        Console.WriteLine("Result: {0}", result);
    }
}
