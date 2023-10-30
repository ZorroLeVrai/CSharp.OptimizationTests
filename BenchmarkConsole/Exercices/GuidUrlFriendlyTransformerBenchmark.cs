using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Exercices.Transformation;

namespace BenchmarkConsole.Exercices;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[SimpleJob(warmupCount: 5, iterationCount: 10)]
public class GuidUrlFriendlyTransformerBenchmark
{
    private static readonly Guid guidTest = Guid.Parse("e6421c02-1aab-499b-9123-ef02d69f49ba");
    private const string stringIdTest = "AhxC5qsam0mRI_8C1p9Jug";

    private GuidAndUrlSimpleTransformer guidAndUrlSimpleTransformer = new GuidAndUrlSimpleTransformer();
    private GuidAndUrlOptimizedTransformer guidAndUrlOptimizedTransformer = new GuidAndUrlOptimizedTransformer();

    [Benchmark]
    public string GuidToFriendlyUrlSimpleTransformer()
    {
        return guidAndUrlSimpleTransformer.GuidToFriendlyUrl(guidTest);
    }

    [Benchmark]
    public Guid IdToFriendlyUrlSimpleTransformer()
    {
        return guidAndUrlSimpleTransformer.FriendlyUrlToGuid(stringIdTest);
    }

    [Benchmark]
    public string GuidToFriendlyUrlOptimizedTransformer()
    {
        return guidAndUrlOptimizedTransformer.GuidToFriendlyUrl(guidTest);
    }

    [Benchmark]
    public Guid IdToFriendlyUrlOptimizedTransformer()
    {
        return guidAndUrlOptimizedTransformer.FriendlyUrlToGuid(stringIdTest);
    }
}