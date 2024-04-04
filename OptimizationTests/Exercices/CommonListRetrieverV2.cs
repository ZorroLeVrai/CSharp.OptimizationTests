namespace OptimizationTests.Exercices;

public struct SPerson
{
    public SPerson() { }

    public int Id { get; set; }
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public DateTime Date_naissance { get; set; } = DateTime.MinValue;

    public override string ToString()
    {
        return $"{Prenom} {Nom} {Date_naissance}";
    }
}

internal class CommonListRetrieverV2
{
    private IEnumerable<SPerson> personList1;
    private IEnumerable<SPerson> personList2;
    private HashSet<SPerson> personSet1;
    private HashSet<SPerson> personSet2;

    private readonly PersonEqualityComparer personComparer = new PersonEqualityComparer();

    public CommonListRetrieverV2(IEnumerable<SPerson> personList1, IEnumerable<SPerson> personList2)
    {
        this.personList1 = personList1;
        this.personList2 = personList2;
        personSet1 = new HashSet<SPerson>(personList1);
        personSet2 = new HashSet<SPerson>(personList2);
    }

    public IEnumerable<SPerson> GetIntersectionUsingList()
    {
        if (personList1 is null || personList2 is null)
            return Enumerable.Empty<SPerson>();

        var commonList = new HashSet<SPerson>();

        foreach (var person1 in personList1)
        {
            foreach (var person2 in personList2)
            {
                if (person1.Equals(person2))
                    commonList.Add(person1);
            }
        }

        return commonList;
    }


    public IEnumerable<SPerson> GetIntersectionUsingListLinqVersion()
    {
        if (personList1 is null || personList2 is null)
            return Enumerable.Empty<SPerson>();

        return personList1.Intersect(personList2).ToList();
    }

    public IEnumerable<SPerson> GetIntersectionUsingHashSet()
    {
        if (personSet1 is null || personSet2 is null)
            return Enumerable.Empty<SPerson>();

        personSet1.IntersectWith(personSet2);
        return personSet1;
    }
}
