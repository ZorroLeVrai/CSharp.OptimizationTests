namespace Exercices.Linq;

internal class LinqEx6 : RunBase<LinqEx6.InputData, IEnumerable<LinqEx6.IdNote>>
{
    public override InputData Init()
    {
        var personnes = new Personne[] {
            new Personne(Prenom: "John", Nom: "Smith", Id: "JS"),
            new Personne("Mary", "Jones", "MJ"),
            new Personne("Peter", "Brown", "PB")
        };

        var etudiants = new Etudiant[] {
            new Etudiant(Prenom: "John", Nom: "Smith", Note: 11),
            new Etudiant("Mary", "Jones", 14.5),
            new Etudiant("Peter", "Brown", 12.5)
        };

        return new InputData(personnes, etudiants);
    }
    public override IEnumerable<IdNote> Process()
    {
        var (personnes, etudiants) = Input!;
        //Join is the equivalent of an inner join
        return personnes.Join(etudiants,
            per => new { per.Prenom, per.Nom },
            etd => new { etd.Prenom, etd.Nom },
            (per, etd) => new IdNote(per.Id, etd.Note));
    }

    public override void DisplayResult()
    {
        Console.WriteLine(Output?.ToPrettyString());
    }

    public record Personne(string Prenom, string Nom, string Id);
    public record Etudiant(string Prenom, string Nom, double Note);
    public record InputData(IEnumerable<Personne> Personnes, IEnumerable<Etudiant> Etudiant);
    public record IdNote(string Id, double Note);
}