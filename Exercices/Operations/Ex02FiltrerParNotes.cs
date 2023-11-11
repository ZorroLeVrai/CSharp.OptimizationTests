using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.Operations;

internal class Input
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

internal class Ex02FiltrerParNotes : RunBase<Input, IEnumerable<Eleve>>
{
    const string student_file = "CSV_Files/football_players.csv";

    private List<Eleve>? _eleves;

    public override Input Init()
    {
        _eleves = GetStudents().ToList();

        return new Input
        {
            MinNote = 8,
            MaxNote = 12
        };

        IEnumerable<Eleve> GetStudents()
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
        return _eleves!.Where(eleve => eleve.Note >= Input!.MinNote && eleve.Note <= Input.MaxNote);
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Les élèves sélectionnés sont:");
        if (_eleves is null)
            return;

        foreach(var eleve in _eleves)
        {
            Console.WriteLine(eleve);
        }
    }
}
