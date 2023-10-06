namespace Exercices;

public interface IRun
{
    void Run();
}

public abstract class RunBase<TIn, TOut>: IRun
{
    public abstract TIn Init();

    public abstract TOut Process(TIn input);

    public abstract void DisplayResult(TOut output);

    public void Run()
    {
        var input = Init();
        var output = Process(input);
        DisplayResult(output);
    }
}
