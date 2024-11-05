using Exercices.Asynchrones;
using Exercices.Linq;
using Exercices.Multithreading;

var task = new GenerateBinaryParallelNumbers(10).DisplayAsync();
task.Wait();

Console.ReadLine();