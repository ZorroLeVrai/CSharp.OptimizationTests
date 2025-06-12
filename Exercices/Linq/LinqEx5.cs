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

    public Dictionary<string, int> ProcessToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses)
            .CountBy(course => course)
            .ToDictionary();
    }

    public Dictionary<string, int> ProcessToDictionary2(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses)
            .GroupBy(course => course)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    public override Dictionary<string, int> Process()
    {
        if (Input == null)
            throw new ArgumentNullException("input");

        return ProcessToDictionary(Input);
    }

    public override void DisplayResult()
    {
        Console.WriteLine(Output!.ToPrettyString());
    }

    public class Student
    {
        public required string Name { get; init; }
        public required IEnumerable<string> Courses { get; init; }
    }
}
