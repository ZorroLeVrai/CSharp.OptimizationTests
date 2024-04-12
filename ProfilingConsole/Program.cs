// See https://aka.ms/new-console-template for more information

using ConsoleApp;

//await DisplayBinariesAsync(10);

//DisplayBinaries(10);

GenerateBinaryNumbers.GenerateBinariesAsap(10);

Console.ReadLine();

async Task DisplayBinariesAsync(int nb)
{
    await foreach(var resultItem in GenerateBinaryNumbers.GenerateBinariesAsync(nb))
        Console.WriteLine(resultItem);
}

void DisplayBinaries(int nb)
{
    foreach (var resultItem in GenerateBinaryNumbers.GenerateParallelBinaries(nb))
        Console.WriteLine(resultItem.Result);
}

//new ConwaySeries()
//    .Run();
