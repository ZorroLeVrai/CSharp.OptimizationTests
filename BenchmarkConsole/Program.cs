using BenchmarkConsole.DateTimeParsers;
using BenchmarkConsole.Exercices;
using BenchmarkDotNet.Running;
using Exercices.Calculs;
using OptimizationTests.DateTimeParsers;

BenchmarkRunner.Run<FibonacciBenchmark>();

//Ex01FibonacciNumbers fiboNumbers = new Ex01FibonacciNumbers();
//var result = fiboNumbers.RecursiveFibo(60);
//Console.WriteLine("Resultat: {0}", result);

//var test = new GetCommonList();
//test.SetupData();
//test.GetIntersectionUsingListLinqVersion();
