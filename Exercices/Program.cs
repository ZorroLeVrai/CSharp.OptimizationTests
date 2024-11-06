using Exercices.Asynchrones;
using Exercices.Calculs;
using Exercices.Linq;
using Exercices.Multithreading;


var result = new Ex01FibonacciNumbers().LinqParallelFiboV2(20);
Console.WriteLine(result);

Console.ReadLine();