// See https://aka.ms/new-console-template for more information

using ConsoleApp;

DisplayBinaries(10);

void DisplayBinaries(int nb)
{
    var results = GenerateBinaryNumbers.GenerateBinaries(nb);

    foreach (var resultItem in results)
        Console.WriteLine(resultItem);
}

//new ConwaySeries()
//    .Run();
