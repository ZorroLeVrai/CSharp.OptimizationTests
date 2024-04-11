namespace Exercices.Multithreading;

public record struct InputOutputResult(int Input, int Output)
{
    public override string ToString()
        => $"{Input} => {Output}";
}
