namespace BinomeFinderApp;

internal record class Participant(string Prenom, string Nom)
{
    public override string ToString()
    {
        return $"{Prenom} {Nom}";
    }
}

