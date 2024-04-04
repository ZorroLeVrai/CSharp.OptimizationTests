using Exercices.Operations;

namespace Exercices.Linq;

internal class LinqEx5B : RunBase<IEnumerable<LinqEx5B.Student>, Dictionary<string, IEnumerable<string>>>
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

    public override Dictionary<string, IEnumerable<string>> Process()
    {
        if (Input == null)
            throw new ArgumentNullException(nameof(Input));

        return Input.SelectMany(student => student.Courses.Select(course => new { Course = course, Student = student.Name }))
            .GroupBy(item => item.Course, item => item.Student)
            .ToDictionary(group => group.Key, group => group.AsEnumerable());
    }

    public override void DisplayResult()
    {
        if (Output is null)
            return;

        foreach(var (course, students) in Output)
        {
            Console.WriteLine($"{course}: {students.ToPrettyString()}");
        }
    }

    public record Student(string Name, IEnumerable<string> Courses);
}
