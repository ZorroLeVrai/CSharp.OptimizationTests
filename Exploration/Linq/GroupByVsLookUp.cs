namespace Exploration.Linq;

internal class GroupByVsLookUp
{
    private IEnumerable<Student> _students;

    public GroupByVsLookUp()
    {
        _students = new Student[]{

            new Student("Alice", new string[] { "Math", "Science" }),
            new Student("Bob", new string[] { "History", "English", "Science" }),
            new Student("Charlie", new string[] { "Math", "Physics", "Chemistry" })
        };
    }

    public void RunUsingGroupBy()
    {
        var courseGrouping = GetGroupedByCourse(_students);

        foreach (var grouping in courseGrouping)
        {
            Console.WriteLine(grouping.Key);
            Console.WriteLine(string.Join(", ", grouping));
        }

        static IEnumerable<IGrouping<string, string>> GetGroupedByCourse(IEnumerable<Student> students)
        {
            return students
            .SelectMany(student => student.Courses.Select(course => new { Course = course, Student = student.Name }))
            .GroupBy(item => item.Course, item => item.Student);
        }
    }

    public void RunUsingToLookup()
    {
        var courseGrouping = GetToLookupCourse(_students);

        foreach (var grouping in courseGrouping)
        {
            Console.WriteLine(grouping.Key);
            Console.WriteLine(string.Join(", ", grouping));
        }

        static ILookup<string, string> GetToLookupCourse(IEnumerable<Student> students)
        {
            return students
            .SelectMany(student => student.Courses.Select(course => new { Course = course, Student = student.Name }))
            .ToLookup(item => item.Course, item => item.Student);
        }
    }

    public void Run()
    {
        Console.WriteLine("Execution Par GroupBy");
        RunUsingGroupBy();
        Console.WriteLine();

        Console.WriteLine("Execution Par ToLookup");
        RunUsingToLookup();
    }

    private record Student(string Name, IEnumerable<string> Courses);
}
