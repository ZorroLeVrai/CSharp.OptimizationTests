namespace Exercices.Multithreading;

public class NumberGenerator
{
    private Random _random = new ();
    private int _fromInclusive;
    private int _toExclusive;

    public NumberGenerator(int fromInclusive, int toExclusive)
    {
        _fromInclusive = fromInclusive;
        _toExclusive = toExclusive;
    }

    public int[] GenerateNumbers(int nb)
    {
        var numbers = new int[nb];
        for (int i = 0; i < nb; ++i)
            numbers[i] = _random.Next(_fromInclusive, _toExclusive);
        return numbers;
    }
}
