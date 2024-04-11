namespace Exercices.Multithreading;

public struct InputOutputResult
{
    public int Input { get; }
    public int Output { get; }

    public InputOutputResult(int number, int sumDigits)
    {
        Input = number;
        Output = sumDigits;
    }

    public override string ToString()
    {
        return $"{Input} => {Output}";
    }
}
