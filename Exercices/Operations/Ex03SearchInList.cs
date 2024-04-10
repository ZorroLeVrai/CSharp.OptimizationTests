using System.Linq;

namespace Exercices.Operations;

public class Ex03SearchInList
{
    private readonly HashSet<int> _collection;

    public Ex03SearchInList(int[] elements)
    {
        _collection = new HashSet<int>(elements);
    }

    public bool Contains(int item) => _collection.Contains(item);
}

public class Ex03SearchPositionInList
{
    private readonly Dictionary<int, int> _collection;

    public Ex03SearchPositionInList(int[] elements)
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

public class Ex03SearchPositionInListWithDuplicates
{
    private readonly ILookup<int, int> _collection;

    public Ex03SearchPositionInListWithDuplicates(int[] elements)
    {
        var index = 0;
        _collection = elements
            .ToLookup(element => element, _ => index++);
    }

    public (bool isPresent, IEnumerable<int> positions) Find(int item)
    {
        var positions = _collection[item];
        return (positions.Any(), positions);
    }
}
