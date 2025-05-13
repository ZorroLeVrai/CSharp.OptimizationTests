namespace Exercices.Operations.Exercice3;

public interface ISearchPositionInList
{
    bool Contains(int item);

    (bool isPresent, int position) Find(int item);
}

public class OptimizedSearchPositionInList
{
    // Dictionary <data, position>
    private readonly Dictionary<int, int> _collection;

    public OptimizedSearchPositionInList(IEnumerable<int> elements)
    {
        var index = 0;
        _collection = elements
            .ToDictionary(element => element, _ => index++);
    }

    public bool Contains(int item)
    {
        return _collection.ContainsKey(item);
    }

    public (bool isPresent, int position) Find(int item)
    {
        if (_collection.TryGetValue(item, out var position))
            return (true, position);

        return (false, -1);
    }
}

public class NaiveSearchPositionInList
{
    private readonly IEnumerable<int> _collection;

    public NaiveSearchPositionInList(IEnumerable<int> elements)
    {
        _collection = elements;
    }

    public bool Contains(int item)
    {
        return _collection.Contains(item);
    }

    public (bool isPresent, int position) Find(int item)
    {
        var index = 0;
        foreach (var element in _collection)
        {
            if (element == item)
                return (true, index);
            ++index;
        }

        return (false, -1);
    }
}
