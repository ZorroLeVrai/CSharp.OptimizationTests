using CsvHelper;
using System.Globalization;

namespace Exercices.Operations;


internal class EleveComparer : IComparer<Eleve>
{
    public int Compare(Eleve? x, Eleve? y)
    {
        if (x is null) return -1;
        if (y is null) return 1;

        var result = x.Note.CompareTo(y.Note);
        if (result != 0) return result;

        result = x.Nom.CompareTo(y.Nom);
        if (result != 0) return result;

        result = x.Prenom.CompareTo(y.Prenom);
        if (result != 0) return result;

        return x.Id.CompareTo(y.Id);
    }
}

public class Ex02FiltrerParNotesV3 : RunBase<Input, IEnumerable<Eleve>>
{
    const string student_file = "CSV_Files/eleves_notes.csv";

    private SortedSet<Eleve>? _eleves;

    public override Input Init()
    {
        _eleves = GetStudents();

        return new Input
        {
            MinNote = 8,
            MaxNote = 12
        };

        SortedSet<Eleve> GetStudents()
        {
            using (var reader = new StreamReader(student_file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new SortedSet<Eleve>(csv.GetRecords<Eleve>(), new EleveComparer());
            }
        }
    }

    public override IEnumerable<Eleve> Process()
    {
        var studentLowerValue = new Eleve { Note = Input!.MinNote };

        var studentUpperValue = new Eleve { Note = Input.MaxNote };

        return _eleves!.GetViewBetween(studentLowerValue, studentUpperValue);
    }

    public override void DisplayResult()
    {
        if (Output is null)
            return;

        Console.WriteLine("Nb élèves sélectionnés: {0}", Output.Count());

        foreach (var eleve in Output)
            Console.WriteLine(eleve);
    }
}
