namespace Exercices.Linq;

internal class LinqEx5 : RunBase<IEnumerable<LinqEx5.Student>, Dictionary<string, int>>
{
    public override IEnumerable<Student> Init()
    {
        return new Student[]
        {
            new Student { Name = "Alice", Courses = new string[] { "Math", "Science" } },
            new Student { Name = "Bob", Courses = new string[] { "History", "English", "Science" } },
            new Student { Name = "Charlie", Courses = new string[] { "Math", "Physics", "Chemistry" } }
        };
    }
    public override Dictionary<string, int> Process(IEnumerable<Student> input)
    {
        return input.SelectMany(etudiant => etudiant.Courses)
            .GroupBy(item => item)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    public override void DisplayResult(Dictionary<string, int> output)
    {
        Console.WriteLine(output.ToPrettyString());
    }

    public class Student
    {
        public required string Name { get; init; }
        public required IEnumerable<string> Courses { get; init; }
    }
}
