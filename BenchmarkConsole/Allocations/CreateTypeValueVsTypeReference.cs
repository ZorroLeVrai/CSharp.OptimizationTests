using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkConsole.Allocations;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class CreateTypeValueVsTypeReference
{
    [Benchmark]
    public void CreateReferenceType()
    {
        var obj = new ReferenceTypeInteger(1);
    }

    [Benchmark]
    public void CreateValueType()
    {
        var obj = new ValueTypeInteger(1);
    }

    private class ReferenceTypeInteger
    {
        public int Value { get; }
        public ReferenceTypeInteger(int value) { Value = value; }
    }

    private struct ValueTypeInteger
    {
        public int Value { get; }
        public ValueTypeInteger(int value) { Value = value; }
    }
}
