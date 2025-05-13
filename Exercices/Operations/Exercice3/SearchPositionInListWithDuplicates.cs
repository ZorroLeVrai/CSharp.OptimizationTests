namespace Exercices.Operations.Exercice3;

public interface ISearchPositionInListWithDuplicates
{
    bool Contains(int item);

    (bool isPresent, IEnumerable<int> positions) Find(int item);
}

public class OptimizedSearchPositionInListWithDuplicates : ISearchPositionInListWithDuplicates
{
    // ILookup <data, position>
    private readonly ILookup<int, int> _collection;

    public OptimizedSearchPositionInListWithDuplicates(IEnumerable<int> elements)
    {
        var index = 0;
        _collection = elements
            .ToLookup(element => element, _ => index++);
    }

    public bool Contains(int item)
    {
        return _collection.Contains(item);
    }

    public (bool isPresent, IEnumerable<int> positions) Find(int item)
    {
        var positions = _collection[item];
        return (positions.Any(), positions);
    }
}


public class NaiveSearchPositionInListWithDuplicates : ISearchPositionInListWithDuplicates
{
    private readonly IEnumerable<int> _collection;

    public NaiveSearchPositionInListWithDuplicates(IEnumerable<int> elements)
    {
        _collection = elements;
    }

    public bool Contains(int item)
    {
        return _collection.Contains(item);
    }

    public (bool isPresent, IEnumerable<int> positions) Find(int item)
    {
        List<int> positions = new();
        var index = 0;
        foreach (var element in _collection)
        {
            if (element == item)
                positions.Add(index);
            ++index;
        }
        return (positions.Any(), positions);
    }
}