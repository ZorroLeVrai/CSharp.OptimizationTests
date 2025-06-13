namespace Exercices.Multithreading;

public record InputOutputResult(int Input, int Output)
{
    public override string ToString()
        => $"{Input} => {Output}";
}
