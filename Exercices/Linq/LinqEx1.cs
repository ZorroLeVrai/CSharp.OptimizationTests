namespace Exercices.Linq;

public class LinqEx1 : RunBase<IEnumerable<int>, IEnumerable<int>>
{
    public override IEnumerable<int> Init()
    {
        return Enumerable.Range(1, 20);
    }

    public override IEnumerable<int> Process(IEnumerable<int> input)
    {
        return input
            .Where(num => (num & 1) == 1)
            .Select(num => 2 * num);
    }
        
    public override void DisplayResult(IEnumerable<int> output)
    {
        Console.WriteLine(output.ToPrettyString());
    }
}
