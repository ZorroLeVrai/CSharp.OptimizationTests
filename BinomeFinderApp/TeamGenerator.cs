using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomeFinderApp;

internal class TeamGenerator
{
    private IReadOnlyList<Participant> participants;
    private Random random;
    private int nbParticipants;

    internal TeamGenerator()
    {
        participants = ParticipantLoader.LoadParticipants();
        nbParticipants = participants.Count;
        random = new Random();
    }

    internal IReadOnlyList<Team> GenerateTeam()
    {
        var randomParticipants = participants.OrderBy(participant => random.Next()).ToArray();

        var teams = new Team[nbParticipants + 1 / 2];
        for (var i = 0; i < nbParticipants; i += 2)
        {
            var secondParticipant = (i + 1 < nbParticipants) ? randomParticipants[i + 1] : null;
            teams[i / 2] = new Team(randomParticipants[i], secondParticipant);
        }

        return teams;
    }
}
