namespace Exercices.Operations.Exercice3;

public interface ISearchInList
{
    bool Contains(int item);
}

public class OptimizedSearchInList : ISearchInList
{
    private readonly HashSet<int> _collection;

    public OptimizedSearchInList(IEnumerable<int> elements)
    {
        _collection = new HashSet<int>(elements);
    }

    public bool Contains(int item) => _collection.Contains(item);
}

public class NaiveSearchInList : ISearchInList
{
    private readonly IEnumerable<int> _collection;

    public NaiveSearchInList(IEnumerable<int> elements)
    {
        _collection = elements;
    }

    public bool Contains(int item) => _collection.Contains(item);
}