namespace Exercices.Immutability;

public class Ex1Ennonce
{
    public List<Person> Persons { get; set; }

    public Ex1Ennonce(List<Person> personList)
    {
        Persons = personList;
    }

    public void AddPerson(Person person)
    {
        Persons.Add(person);
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

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

public static class UseEx1Ennonce
{
    public static void Run()
    {
        var persons = new List<Person>
        {
            new Person("John", "Smith"),
            new Person("Mary", "Jones"),
            new Person("Peter", "Brown")
        };

        var original = new Ex1Ennonce(persons);

        var originalPersons = original.Persons;

        //Interdit
        original.Persons[0].FirstName = "Johnathan";
        //Interdit
        original.Persons.Add(new Person("Jane", "Doe"));

        original.AddPerson(new Person("Tim", "Doe"));
        original.DisplayPersons();

        DisplayPersons("Original list", persons);
        DisplayPersons("original.Persons", originalPersons);
    }

    static void DisplayPersons(string tag, IEnumerable<Person> persons)
    {
        Console.WriteLine();
        Console.WriteLine($"{tag}:");
        foreach (var person in persons)
        {
            Console.WriteLine(person);
        }
    }
}
