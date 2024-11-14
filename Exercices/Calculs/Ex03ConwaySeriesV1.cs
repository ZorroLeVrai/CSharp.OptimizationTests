namespace Exercices.Calculs;

/// <summary>
/// Compute the Conway series using a string
/// </summary>
public class Ex03ConwaySeriesV1 : RunBase<int, string>
{
    private string _originalTerm = "1";

    public override int Init()
    {
        return 6;
    }

    public string Process(int terme)
    {
        var currentItem = _originalTerm;
        for (int i = 0; i < terme; ++i)
        {
            currentItem = GetNextIteration(currentItem);
        }
        return currentItem;

        string GetNextIteration(string currentSb)
        {
            var strLength = currentSb.Length;
            if (strLength == 0)
                return string.Empty;

            var result = string.Empty;
            var previousChar = currentSb[0];
            var nbOccurences = 1;

            for (int i = 1; i < strLength; ++i)
            {
                var currentChar = currentSb[i];
                if (previousChar == currentChar)
                    ++nbOccurences;
                else
                {
                    result += nbOccurences.ToString();
                    result += previousChar;
                    previousChar = currentChar;
                    nbOccurences = 1;
                }
            }

            result += nbOccurences.ToString();
            result += previousChar;

            return result;
        }
    }

    public override string Process()
    {
        return Process(Input);
    }

    public override void DisplayResult()
    {
        Console.WriteLine("Résultat: {0}", Output);
        Console.WriteLine("Longeur du résultat: {0}", Output?.Length);
    }
}