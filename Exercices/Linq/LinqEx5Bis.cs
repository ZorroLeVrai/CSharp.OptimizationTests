namespace Exercices.Linq;

internal class LinqEx5Bis : RunBase<IEnumerable<LinqEx5Bis.Student>, Dictionary<string, int>>
{
    public override IEnumerable<Student> Init()
    {
        return new Student[]
        {

            new Student("Alice", new string[] { "Math", "Science" } ),
            new Student("Bob", new string[] { "History", "English", "Science" } ),
            new Student("Charlie", new string[] { "Math", "Physics", "Chemistry" } )
        };
    }
    public override Dictionary<string, int> Process()
    {
        //return Input!.SelectMany(etudiant => etudiant.Courses)
        //    .GroupBy(item => item)
        //    .ToDictionary(group => group.Key, group => group.Count());

        return Input!.SelectMany(etudiant => etudiant.Courses)
            .ToLookup(item => item)
            .ToDictionary(group => group.Key, group => group.Count());


    }

    public override void DisplayResult()
    {
        Console.WriteLine(Output!.ToPrettyString());
    }

    public record Student(string Name, IEnumerable<string> Courses);
}
