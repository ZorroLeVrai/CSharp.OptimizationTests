using BenchmarkConsole.Collections;
using BenchmarkConsole.DateTimeParsers;
using BenchmarkConsole.Exercices;
using BenchmarkConsole.Multithreading;
using BenchmarkDotNet.Running;
using Exercices.Calculs;
using OptimizationTests.DateTimeParsers;
using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;

var summary = BenchmarkRunner.Run<DateParserBenchmarks>();

