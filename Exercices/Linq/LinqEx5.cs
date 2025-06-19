namespace Exercices.Linq;

public class LinqEx5 : RunBase<IEnumerable<LinqEx5.Student>, Dictionary<string, int>>
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

    public Dictionary<string, int> ProcessCountByToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses)
            .CountBy(course => course)
            .ToDictionary();
    }

    public Dictionary<string, int> ProcessGroupByToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses)
            .GroupBy(course => course)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    public Dictionary<string, int> ProcessAggregateToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses)
            .Aggregate(new Dictionary<string, int>(), (acc, cur) =>
            {
                if (acc.TryGetValue(cur, out int occurence))
                    acc[cur] = occurence + 1;
                else
                    acc.Add(cur, 1);
                return acc;
            });
    }

    public override Dictionary<string, int> Process()
    {
        if (Input == null)
            throw new ArgumentNullException("input");

        return ProcessCountByToDictionary(Input);
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
