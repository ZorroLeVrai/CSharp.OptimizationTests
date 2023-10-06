namespace Exercices.Linq;

internal class LinqEx3 : RunBase<int[], int>
{
    public override int[] Init()
    {
        return new int[] { 40, 61, 13, 56, 83, 100, 9, 76, 25 };
    }

    public override int Process(int[] input)
    {
        return input.Aggregate((acc, cur) => acc + ((cur & 1) == 1 ? -1 : 1) * cur);
    }

    public override void DisplayResult(int output)
    {
        Console.WriteLine(output);
    }
}
