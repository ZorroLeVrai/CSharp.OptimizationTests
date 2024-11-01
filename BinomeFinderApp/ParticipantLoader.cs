using CsvHelper;
using System.Globalization;

namespace BinomeFinderApp;

internal static class ParticipantLoader
{
    private static string FILE_PATH = @"D:\Users\Amine\Prgm\Cours\CSharp\CSharp_Optimisation_Orsys\Participants.csv";

    internal static IReadOnlyList<Participant> LoadParticipants()
    {
        using (var reader = new StreamReader(FILE_PATH))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<ParticipantDTO>();

            return records.Where(participant => string.IsNullOrEmpty(participant.Absent))
                .Select(participant => participant.GetParticipantInfo())
                .ToList();
        }
    }
}
