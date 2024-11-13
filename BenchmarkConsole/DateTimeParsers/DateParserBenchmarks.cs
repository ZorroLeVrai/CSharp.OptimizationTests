using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using OptimizationTests.DateTimeParsers;

namespace BenchmarkConsole.DateTimeParsers;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class DateParserBenchmarks
{
    private const string DateTimeInString = "2023-09-28T16:33:06Z";
    private static readonly DateTimeParser DtParsers = new();

    [Benchmark(Baseline = true)]
    public void TryParseDateTimeFromString()
    {
        DtParsers.TryParseDateTimeFromStr(DateTimeInString, out DateTime dt);
    }

    //[Benchmark]
    //public void TryParseDateTimeFromSpan()
    //{
    //    DtParsers.TryParseDateFromSpan(DateTimeInString, out DateTime dt);
    //}

    [Benchmark]
    public void TryParseDateTimeUsingSplits()
    {
        DtParsers.TryParseDateUsingSplits(DateTimeInString, out DateTime dt);
    }

    [Benchmark]
    public void TryParseDateTimeUsingSplices()
    {
        DtParsers.TryParseDateUsingSlices(DateTimeInString, out DateTime dt);
    }

    [Benchmark]
    public void TryParseDateTimeUsingSplicesCustomParser()
    {
        DtParsers.TryParseDateUsingSlicesCustomParser(DateTimeInString, out DateTime dt);
    }
}
