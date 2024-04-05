using BenchmarkConsole.Collections;
using BenchmarkConsole.DateTimeParsers;
using BenchmarkConsole.Exercices;
using BenchmarkConsole.Multithreading;
using BenchmarkDotNet.Running;
using Exercices.Calculs;
using OptimizationTests.DateTimeParsers;

BenchmarkRunner.Run<SumInverseBenchmark>();

//var col1 = new List<int>() { 1, 2, 3, 4, 5 };
//var col2 = col1.Select(x => x + 1);
//Console.WriteLine(string.Join(",", col1));
//Console.WriteLine(string.Join(",", col2));
