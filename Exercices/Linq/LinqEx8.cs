namespace Exercices.Linq;

internal class LinqEx8 : RunBase<IEnumerable<int>, Dictionary<int, IEnumerable<int>>>
{
    public override IEnumerable<int> Init()
    {
        return Enumerable.Range(2, 29);
    }

    public override Dictionary<int, IEnumerable<int>> Process(IEnumerable<int> input)
    {
        return input.Select(number => new { Number = number, Series = SyracuseSeries(number) })
            .ToDictionary(item => item.Number, item => item.Series);

        IEnumerable<int> SyracuseSeries(int number)
        {
            var syracuseNumbers = new List<int>();
            var current = number;
            do
            {
                syracuseNumbers.Add(current);
                current = (current & 1) == 1 ? 3 * current + 1 : current / 2;
            } while (current > 1);
            syracuseNumbers.Add(current);
            return syracuseNumbers;
        }
    }

    public override void DisplayResult(Dictionary<int, IEnumerable<int>> output)
    {
        foreach (var (key, value) in output)
        {
            Console.WriteLine($"{key}: {value.ToPrettyString()}");
        }
    }
}
