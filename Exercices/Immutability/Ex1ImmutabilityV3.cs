namespace Exercices.Immutability;

internal class Ex1ImmutabilityV3
{
    private readonly List<IPersonV3> _persons = new();

    public IReadOnlyList<IPersonV3> Persons
    {
        get => _persons;
        //get => new List<IPersonV3>(_persons);
    }

    public Ex1ImmutabilityV3(IEnumerable<IPersonV3> personList)
    {
        _persons = new List<IPersonV3>(personList);
    }

    public Ex1ImmutabilityV3(Ex1ImmutabilityV3 original)
    {
        _persons = new List<IPersonV3>(original._persons);
    }

    public Ex1ImmutabilityV3 AddPerson(IPersonV3 person)
    {
        var clone = new Ex1ImmutabilityV3(this);
        clone._persons.Add(person);
        return clone;
    }

    public void DisplayPersons()
    {
        Console.WriteLine("\nInternal List:");
        foreach (var person in Persons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}

interface IPersonV3
{
    string FirstName { get; }
    string LastName { get; }
}

public class PersonMutableV3 : IPersonV3
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public PersonMutableV3(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public static class UseImmutableV3
{
    public static void Run()
    {
        var persons = new List<PersonMutableV3>
        {
            new PersonMutableV3("John", "Smith"),
            new PersonMutableV3("Mary", "Jones"),
            new PersonMutableV3("Peter", "Brown")
        };

        var original = new Ex1ImmutabilityV3(persons);
        var originalPersons = original.Persons;

        //Erreur de compilation
        //original.Persons[0].FirstName = "Johnathan";
        //Erreur de compilation
        //original.Persons.Add(new PersonImmutableV1("Jane", "Doe"));

        original.AddPerson(new PersonMutableV3("Tim", "Doe"));
        original.DisplayPersons();

        DisplayPersons("Original list", persons);
        DisplayPersons("original.Persons", originalPersons);
    }

    static void DisplayPersons(string tag, IEnumerable<IPersonV3> persons)
    {
        Console.WriteLine();
        Console.WriteLine($"{tag}:");
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}