using CsvHelper;
using System.Globalization;

namespace Exercices.Operations;

public class Input
{ 
    public decimal MinNote { get; init; } = decimal.MinValue;

    public decimal MaxNote { get; init; } = decimal.MaxValue;
}

public class Eleve
{
    public int Id { get; set; }
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public decimal Note { get; set; } = 0;

    public override string ToString()
    {
        return $"{Prenom} {Nom} (Note: {Note})";
    }
}

public class Ex02FiltrerParNotesV1 : RunBase<Input, IEnumerable<Eleve>>
{
    const string student_file = "CSV_Files/eleves_notes.csv";

    private List<Eleve>? _eleves;

    public override Input Init()
    {
        _eleves = GetStudents();

        return new Input
        {
            MinNote = 8,
            MaxNote = 12
        };

        List<Eleve> GetStudents()
        {
            using (var reader = new StreamReader(student_file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Eleve>().ToList();
            }
        }
    }

    public override IEnumerable<Eleve> Process()
    {        
        return _eleves!.Where(eleve => eleve.Note >= Input!.MinNote && eleve.Note < Input.MaxNote)
            .OrderBy(eleve => eleve.Note)
            .ToList();
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