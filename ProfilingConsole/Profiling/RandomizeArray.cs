using ProfilingConsole;

namespace ConsoleApp.Profiling;

internal class RandomizeArray<T>
{
    private T[] _array;

    public RandomizeArray(T[] array)
    {
        _array = array;
    }

    public T[] GenerateNbElements(int nbElements)
    {
        var random = new Random();
        var result = new T[nbElements];
        var selectedPosition = new List<int>();
        for (var i = 0; i < nbElements; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = random.Next(_array.Length);
            } while (selectedPosition.Contains(randomIndex));
            selectedPosition.Add(randomIndex);
            result[i] = _array[randomIndex];
        }

        return result;
    }
}


internal class TestRandomizeArray : IRunnable
{
    public void Run()
    {
        var nbElements = 500_000;
        var myArray = new int[nbElements];
        for (var i = 0; i < nbElements; ++i)
        {
            myArray[i] = i;
        }

        var randomizeArray = new RandomizeArray<int>(myArray);
        var randomArray = randomizeArray.GenerateNbElements(nbElements);

        Console.WriteLine("Tableau généré:");
        Console.WriteLine("[{0}]", string.Join(", ", randomArray));
    }
}