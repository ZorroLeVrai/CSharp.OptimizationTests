using CsvHelper.Configuration;

namespace BinomeFinderApp;

internal class ParticipantDTO
{
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Absent { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Nom} {Prenom} {Absent}";
    }

    public Participant GetParticipantInfo()
    {
        return new Participant(Prenom, Nom);
    }
}
