using NUnit.Framework;
using OptimizationTests.DateTimeParsers;
using OptimizationTests.Exercices;

namespace OptimizationTestsUnitTests;

[TestFixture]
internal class CommonListTests
{
    private RetrieveCommonListScenario commonListScenario = new RetrieveCommonListScenario();

    [OneTimeSetUp]
    public void Init()
    {
        commonListScenario = new RetrieveCommonListScenario();
    }

    [Test]
    public void GetIntersectionUsingList()
    {
        var result = commonListScenario.GetIntersectionUsingList().ToList();
        Assert.AreEqual(153, result.Count);
    }

    [Test]
    public void GetIntersectionUsingListLinqVersion()
    {
        var result = commonListScenario.GetIntersectionUsingListLinqVersion().ToList();
        Assert.AreEqual(153, result.Count);
    }

    [Test]
    public void GetIntersectionUsingHashSet()
    {
        var result = commonListScenario.GetIntersectionUsingHashSet().ToList();
        Assert.AreEqual(153, result.Count);
    }
}
