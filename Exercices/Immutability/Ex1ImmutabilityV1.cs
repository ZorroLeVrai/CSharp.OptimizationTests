using System.Collections.ObjectModel;

namespace Exercices.Immutability;

public class Ex1ImmutabilityV1
{
    private readonly List<PersonImmutableV1> _persons = new();

    public ReadOnlyCollection<PersonImmutableV1> Persons
    {
        get => _persons.AsReadOnly();
    }

    public Ex1ImmutabilityV1(IEnumerable<PersonImmutableV1> personList)
    {
        _persons = new List<PersonImmutableV1>(personList);
    }

    public void AddPerson(PersonImmutableV1 person)
    {
        _persons.Add(person);
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


public class PersonImmutableV1
{
    public string FirstName { get; }
    public string LastName { get; }

    public PersonImmutableV1(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public static class UseImmutableV1
{
    public static void Run()
    {
        var persons = new List<PersonImmutableV1>
        {
            new PersonImmutableV1("John", "Smith"),
            new PersonImmutableV1("Mary", "Jones"),
            new PersonImmutableV1("Peter", "Brown")
        };

        var original = new Ex1ImmutabilityV1(persons);
        var originalPersons = original.Persons;

        //Erreur de compilation
        //original.Persons[0].FirstName = "Johnathan";
        //Erreur de compilation
        //original.Persons.Add(new PersonImmutableV1("Jane", "Doe"));

        original.AddPerson(new PersonImmutableV1("Tim", "Doe"));
        original.DisplayPersons();

        DisplayPersons("Original list", persons);
        DisplayPersons("original.Persons", originalPersons);
    }

    static void DisplayPersons(string tag, IEnumerable<PersonImmutableV1> persons)
    {
        Console.WriteLine();
        Console.WriteLine($"{tag}:");
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}