namespace Exercices.Linq;

internal class LinqEx3 : RunBase<int[], int>
{
    public override int[] Init()
    {
        return new int[] { 40, 61, 13, 56, 83, 100, 9, 76, 25 };
    }

    public override int Process()
    {
        if (Input == null)
            return 0;

        return Input.Aggregate((acc, cur) => acc + ((cur & 1) == 1 ? -1 : 1) * cur);
    }

    public override void DisplayResult()
    {
        Console.WriteLine(Output);
    }
}
