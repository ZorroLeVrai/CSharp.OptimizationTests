using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Immutability;

internal class Ex1ImmutabilityV2
{
    private readonly List<IPerson> _persons = new();

    public IReadOnlyList<IPerson> Persons
    {
        get => _persons;
        //get => new List<IPerson>(_persons);
    }

    public Ex1ImmutabilityV2(IEnumerable<PersonMutableV2> personList)
    {
        _persons = new List<IPerson>(personList);
    }

    public void AddPerson(IPerson person)
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

interface IPerson
{
    string FirstName { get; }
    string LastName { get; }
}

public class PersonMutableV2 : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public PersonMutableV2(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public static class UseImmutableV2
{
    public static void Run()
    {
        var persons = new List<PersonMutableV2>
        {
            new PersonMutableV2("John", "Smith"),
            new PersonMutableV2("Mary", "Jones"),
            new PersonMutableV2("Peter", "Brown")
        };

        var original = new Ex1ImmutabilityV2(persons);
        var originalPersons = original.Persons;

        //Erreur de compilation
        //original.Persons[0].FirstName = "Johnathan";
        //Erreur de compilation
        //original.Persons.Add(new PersonImmutableV1("Jane", "Doe"));

        original.AddPerson(new PersonMutableV2("Tim", "Doe"));
        original.DisplayPersons();

        DisplayPersons("Original list", persons);
        DisplayPersons("original.Persons", originalPersons);
    }

    static void DisplayPersons(string tag, IEnumerable<IPerson> persons)
    {
        Console.WriteLine();
        Console.WriteLine($"{tag}:");
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}