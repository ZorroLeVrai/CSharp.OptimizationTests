namespace Exercices.Linq;

public class LinqEx1 : RunBase<IEnumerable<int>, IEnumerable<int>>
{
    public override IEnumerable<int> Init()
    {
        return Enumerable.Range(1, 20);
    }

    public override IEnumerable<int> Process()
    {
        if (Input is null)
            return Enumerable.Empty<int>();

        return Input
            .Where(num => (num % 2) == 1)
            //.Where(num => (num & 1) == 1)
            .Select(num => 2 * num);
    }
        
    public override void DisplayResult()
    {
        Console.WriteLine(Output!.ToPrettyString());
    }
}
