namespace Exercices.Linq;

internal class LinqEx9 : RunBase<LinqEx9.InputData, IEnumerable<LinqEx9.PersonneMontant>>
{
    public override InputData Init()
    {
        var personnes = new Personne[] {
            new Personne(Prenom: "John", Nom: "Smith", Id: "JS"),
            new Personne("Mary", "Jones", "MJ"),
            new Personne("Peter", "Brown", "PB")
        };

        var comptes = new Compte[]
        {
            new Compte(IdPersonne: "JS", IdCompte: 1, Somme: 100),
            new Compte(IdPersonne: "PB", IdCompte: 2, Somme: 50),
            new Compte(IdPersonne: "JS", IdCompte: 3, Somme: 200)
        };

        return new InputData(personnes, comptes);
    }

    public override IEnumerable<PersonneMontant> Process()
    {
        var (personnes, comptes) = Input!;

        IEnumerable<(string Prenom, string Nom, IEnumerable<Compte> Compte)> resultGroupJoin = personnes
            .GroupJoin(comptes, p => p.Id, c => c.IdPersonne, (p, c) => (p.Prenom, p.Nom, Compte: c));

        IEnumerable<PersonneMontant> resultat = resultGroupJoin
            .Select(item => new PersonneMontant(item.Prenom, item.Nom, item.Compte.Sum(c => c.Somme)));

        return resultat;
    }

    public override void DisplayResult()
    {
        foreach (var personItem in Output!)
        {
            Console.WriteLine(personItem);
        }
    }

    public record class Personne(string Prenom, string Nom, string Id);
    public record class Compte(string IdPersonne, int IdCompte, double Somme)
    {
        public override string ToString() => $"Id: {IdCompte}, Somme: {Somme}";
    }

    public record class PersonneMontant(string Prenom, string Nom, double Somme)
    {
        public override string ToString() => $"{Prenom} {Nom} - Somme: {Somme}";
    }

    public record class InputData(IEnumerable<Personne> Personnes, IEnumerable<Compte> Comptes);
}
