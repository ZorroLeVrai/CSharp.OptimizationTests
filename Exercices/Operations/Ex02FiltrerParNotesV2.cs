using CsvHelper;
using System.Globalization;

namespace Exercices.Operations;

public class Ex02FiltrerParNotesV2 : RunBase<Input, IEnumerable<Eleve>>
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
                return csv.GetRecords<Eleve>()
                    .OrderBy(eleve => eleve.Note)
                    .ToList();
            }
        }
    }

    public override IEnumerable<Eleve> Process()
    {
        if (_eleves is null || Input is null)
            return Enumerable.Empty<Eleve>();

        var selectedStudents = new List<Eleve>();
        var nbElements = _eleves.Count;
        Func<Eleve, bool> minValuePredicate = eleve => eleve.Note >= Input.MinNote;
        var index = GetFirstItemIndex(0, nbElements - 1);
        if (index.HasValue)
        {
            var currentIndex = index.Value;
            
            while (currentIndex < nbElements && _eleves[currentIndex].Note < Input.MaxNote)
            {
                selectedStudents.Add(_eleves[currentIndex]);
                ++currentIndex;
            }
        }

        return selectedStudents;


        int? GetFirstItemIndex(int minIndex, int maxIndex) {
            if (maxIndex - minIndex < 2) {
                if (minValuePredicate(_eleves![minIndex]))
                    return minIndex;
                if (minValuePredicate(_eleves![maxIndex]))
                    return maxIndex;
            }
            else
            {
                var midIndex = (maxIndex + minIndex) / 2;
                if (minValuePredicate(_eleves![midIndex]))
                    return GetFirstItemIndex(minIndex, midIndex);
                else
                    return GetFirstItemIndex(midIndex, maxIndex);
            }

            return null;
        }
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
