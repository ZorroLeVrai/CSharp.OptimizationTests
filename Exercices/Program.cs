using Exercices.Calculs;
using Exercices.Linq;
using Exercices.Multithreading;
using Exercices.Operations;
using System.Threading.Channels;

uint num = 100_000_000;
var ex = new Ex01SommeInverse();
Console.WriteLine(ex.SplitParallelProcess(num));
Console.WriteLine(ex.SplitParallelProcessV2(num));
