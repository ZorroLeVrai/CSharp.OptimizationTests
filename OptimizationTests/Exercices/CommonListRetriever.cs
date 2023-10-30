namespace OptimizationTests.Exercices;

public class Person
{
    public int Id { get; set; }
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public DateTime Date_naissance { get; set; } = DateTime.MinValue;

    public override string ToString()
    {
        return $"{Prenom} {Nom} {Date_naissance}";
    }
}

internal class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person? person1, Person? person2)
    {
        if (ReferenceEquals(person1, person2))
            return true;

        if (person2 is null || person1 is null)
            return false;

        return string.Equals(person1.Prenom, person2.Prenom, StringComparison.Ordinal)
            && string.Equals(person1.Nom, person2.Nom, StringComparison.Ordinal)
            && person1.Date_naissance == person2.Date_naissance;
    }

    public int GetHashCode(Person per) => (per.Prenom, per.Nom, per.Date_naissance).GetHashCode();
}

internal class CommonListRetriever
{
    private IEnumerable<Person> personList1;
    private IEnumerable<Person> personList2;
    private HashSet<Person> personSet1;
    private HashSet<Person> personSet2;

    private readonly PersonEqualityComparer personComparer = new PersonEqualityComparer();

    public CommonListRetriever(IEnumerable<Person> personList1, IEnumerable<Person> personList2)
    {
        this.personList1 = personList1;
        this.personList2 = personList2;
        personSet1 = new HashSet<Person>(personList1, personComparer);
        personSet2 = new HashSet<Person>(personList2, personComparer);
    }

    public IEnumerable<Person> GetIntersectionUsingList()
    {
        if (personList1 is null || personList2 is null)
            return Enumerable.Empty<Person>();

        var commonList = new List<Person>();

        foreach (var person1 in personList1)
        {
            foreach (var person2 in personList2)
            {
                if (personComparer.Equals(person1, person2) && !commonList.Contains(person1))
                    commonList.Add(person1);
            }
        }

        return commonList;
    }


    public IEnumerable<Person> GetIntersectionUsingListLinqVersion()
    {
        if (personList1 is null || personList2 is null)
            return Enumerable.Empty<Person>();

        return personList1.Intersect(personList2, personComparer).ToList();
    }

    public IEnumerable<Person> GetIntersectionUsingHashSet()
    {
        if (personSet1 is null || personSet2 is null)
            return Enumerable.Empty<Person>();

        personSet1.IntersectWith(personSet2);
        return personSet1;
    }
}
