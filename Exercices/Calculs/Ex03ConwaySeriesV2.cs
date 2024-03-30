using System.Text;

namespace Exercices.Calculs;

/// <summary>
/// Compute the Conway series using a StringBuilder
/// </summary>
public class Ex03ConwaySeriesV2 : RunBase<int, string>
{
    private StringBuilder _originalTerm = new StringBuilder("1");

    public override int Init()
    {
        return 40;
    }

    public override string Process()
    {
        var currentItem = _originalTerm;
        for (int i=0; i<Input; ++i)
        {
            currentItem = GetNextIteration(currentItem);
        }
        return currentItem.ToString();

        StringBuilder GetNextIteration(StringBuilder currentSb)
        {
            var strLength = currentSb.Length;
            if (strLength == 0)
                return new StringBuilder();

            var result = new StringBuilder(strLength);
            var previousChar = currentSb[0];
            var nbOccurences = 1;

            for (int i = 1; i < strLength; ++i)
            {
                var currentChar = currentSb[i];
                if (previousChar == currentChar)
                    ++nbOccurences;
                else
                {
                    result.Append(nbOccurences);
                    result.Append(previousChar);
                    previousChar = currentChar;
                    nbOccurences = 1;
                }
            }
            result.Append(nbOccurences);
            result.Append(previousChar);

            return result;
        }
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Résultat: {0}", Output);
        Console.WriteLine("Longeur du résultat: {0}", Output?.Length);
    }
}
