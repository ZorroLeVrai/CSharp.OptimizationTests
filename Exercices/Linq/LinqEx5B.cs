using Exercices.Operations;

namespace Exercices.Linq;

public class LinqEx5B : RunBase<IEnumerable<LinqEx5B.Student>, Dictionary<string, IEnumerable<string>>>
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

    public Dictionary<string, IEnumerable<string>> ProcessGroupByToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses, (student, course) => (Course: course, Student: student.Name))
            .GroupBy(item => item.Course, item => item.Student)
            .ToDictionary(group => group.Key, group => group.AsEnumerable());
    }

    public Dictionary<string, IEnumerable<string>> ProcessAggregateToDictionary(IEnumerable<Student> students)
    {
        return students.SelectMany(student => student.Courses, (student, course) => (Course: course, Student: student.Name))
            .Aggregate(new Dictionary<string, List<string>>(), (acc, cur) =>
            {
                if (!acc.TryGetValue(cur.Course, out var studentsList))
                {
                    studentsList = new List<string>();
                    acc[cur.Course] = studentsList;
                }
                studentsList.Add(cur.Student);
                return acc;
            })
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.AsEnumerable());
    }

    public override Dictionary<string, IEnumerable<string>> Process()
    {
        if (Input == null)
            throw new ArgumentNullException(nameof(Input));

        return ProcessAggregateToDictionary(Input);
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
