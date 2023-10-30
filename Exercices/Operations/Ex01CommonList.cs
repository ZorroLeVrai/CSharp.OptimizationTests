using CsvHelper;
using System.Globalization;

namespace Exercices.Operations;

internal class FilePaths
{
    public string FilePath1 { get; init; } = string.Empty;
    public string FilePath2 { get; init; } = string.Empty;
}

internal class Person
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

internal class Ex01CommonList : RunBase<FilePaths, IEnumerable<Person>>
{
    const string football_players = "CSV_Files/football_players.csv";
    const string tennis_players = "CSV_Files/tennis_players.csv";
    public override FilePaths Init()
    {
        return new FilePaths {
            FilePath1 = football_players,
            FilePath2 = tennis_players
        };
    }

    public override IEnumerable<Person> Process(FilePaths input)
    {
        var personSet1 = GetPersons(input.FilePath1);
        var personSet2 = GetPersons(input.FilePath2);

        if (personSet1 == null || personSet2 == null)
            return Enumerable.Empty<Person>();

        personSet1.IntersectWith(personSet2);
        return personSet1;

        HashSet<Person> GetPersons(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new HashSet<Person>(csv.GetRecords<Person>(), new PersonEqualityComparer());
            }
        }
    }

    public override void DisplayResult(IEnumerable<Person> output)
    {
        Console.WriteLine("La liste commune de personnes est: ");
        var nb_persons = 0;
        foreach (var person in output)
        {
            Console.WriteLine(person);
            ++nb_persons;
        }

        Console.WriteLine("Nb persons: {0}", nb_persons);
    }
}
