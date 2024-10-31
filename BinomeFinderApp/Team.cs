namespace BinomeFinderApp;

internal record Team(Participant Participant1, Participant? Participant2 = null)
{
    public override string ToString()
    {
        if (Participant2 != null)
            return $"[{Participant1}, {Participant2}]";

        return $"[{Participant1}]";
    }
}