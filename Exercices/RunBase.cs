namespace Exercices;

public interface IRun
{
    void Run();
}

public abstract class RunBase<TIn, TOut> : IRun
{
    protected TIn? Input { get; private set; }
    protected TOut? Output { get; private set; }

    public abstract TIn Init();

    public abstract TOut Process();

    public abstract void DisplayResult();

    public void Initialize()
    {
        Input = Init();
    }

    public RunBase<TIn, TOut> Initialize(TIn input)
    {
        Input = input;
        return this;
    }

    public void RunProcess()
    {
        Output = Process();
        DisplayResult();
    }

    public void Run()
    {
        Initialize();
        RunProcess();
    }
}
