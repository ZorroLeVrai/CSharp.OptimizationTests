// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using ConsoleApp.Profiling;
using System.Text;


IEnumerable<int> resultat = func();
foreach (var item in resultat)
{
    Console.WriteLine(item);
}

IEnumerable<int> func()
{
    var entiers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
    var nb = 2;
    var resultat = entiers.Where(e => e > nb);
    nb = 10;
    return resultat;
}


//new ConwaySeries()
//    .Run();

await new GenerateBinaryNumbers(10).DisplayAsync();

//new FibonacciSequence().Run();

//new ConwaySeries().Run();

//new WaitBeforeAction().Run();

//new TestRandomizeArray().Run();


