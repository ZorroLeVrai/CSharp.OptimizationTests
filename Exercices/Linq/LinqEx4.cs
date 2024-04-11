namespace Exercices.Linq;

internal class LinqEx4 : RunBase<(int[], int[]), bool>
{
    public override (int[], int[]) Init()
    {
        return (new int[] { 2, 5, 7, 9 }, new int[] { 4, 25, 49, 81 });
    }

    public override bool Process()
    {
        return Method();
    }

    public bool Method()
    {
        var (numbers, squares) = Input;
        if (numbers.Length != squares.Length)
            return false;
        return numbers.Zip(squares, (number, square) => (number, square))
            .All(item => item.square == item.number * item.number);
    }

    public bool MethodV2()
    {
        var (numbers, squares) = Input;
        if (numbers.Length != squares.Length)
            return false;
        return numbers.Zip(squares)
            .All(item => item.Second == item.First * item.First);
    }

    public override void DisplayResult()
    {
        Console.WriteLine(Output);
    }
}
