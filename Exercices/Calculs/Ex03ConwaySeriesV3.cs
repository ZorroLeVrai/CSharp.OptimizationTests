using System.Text;

namespace Exercices.Calculs;

public class Ex03ConwaySeriesV3 : RunBase<int, string>
{
    private List<byte> _originalTerm = new List<byte> { 1 };

    public override int Init()
    {
        return 6;
    }

    public override string Process()
    {
        return Process(Input);
    }

    public string Process(int terme)
    {
        IReadOnlyList<byte> currentItem = _originalTerm;
        for (int i = 0; i < terme; ++i)
        {
            currentItem = GetNextIteration(currentItem);
        }
        return ListToString(currentItem);

        IReadOnlyList<byte> GetNextIteration(IReadOnlyList<byte> currentSb)
        {
            var strLength = currentSb.Count;
            if (strLength == 0)
                return new List<byte>();

            var result = new List<byte>(strLength);
            var previousChar = currentSb[0];
            byte nbOccurences = 1;

            for (int i = 1; i < strLength; ++i)
            {
                var currentChar = currentSb[i];
                if (previousChar == currentChar)
                    ++nbOccurences;
                else
                {
                    result.Add(nbOccurences);
                    result.Add(previousChar);
                    previousChar = currentChar;
                    nbOccurences = 1;
                }
            }
            result.Add(nbOccurences);
            result.Add(previousChar);

            return result;
        }
    }

    private string ListToString(IReadOnlyList<byte> list)
    {
        var sb = new StringBuilder(list.Count);
        foreach (var item in list)
        {
            sb.Append(item);
        }
        return sb.ToString();
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Résultat: {0}", Output);
        Console.WriteLine("Longeur du résultat: {0}", Output?.Length);
    }
}
