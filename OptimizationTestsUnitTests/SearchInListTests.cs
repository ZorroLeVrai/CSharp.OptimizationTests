using Exercices.Operations;
using NUnit.Framework;

namespace OptimizationTestsUnitTests;

[TestFixture]
internal class SearchInListTests
{
    private int[] _uniqueNumbers = { 5, 3, 2, 8, 4, 1, 6, 7, 10 };
    private int[] _numbers = { 5, 3, 5, 3, 2, 5, 2, 8, 4, 2, 1, 6, 5, 7, 4, 6, 10, 8, 7, 1 };
    private Ex03SearchInList? _searchInList;
    private Ex03SearchPositionInList? _searchPositionInList;
    private Ex03SearchPositionInListWithDuplicates? _searchPositionInListWithDuplicates;

    [OneTimeSetUp]
    public void Init()
    {
        _searchInList = new Ex03SearchInList(_uniqueNumbers);
        _searchPositionInList = new Ex03SearchPositionInList(_uniqueNumbers);
        _searchPositionInListWithDuplicates = new Ex03SearchPositionInListWithDuplicates(_numbers);
    }

    [Test]
    public void SearchInList()
    {
        Assert.IsNotNull(_searchInList);
        Assert.IsTrue(_searchInList!.Contains(3));
        Assert.IsTrue(_searchInList!.Contains(8));
        Assert.IsFalse(_searchInList!.Contains(9));
    }

    [Test]
    public void SearchPositionInList()
    {
        Assert.IsNotNull(_searchPositionInList);

        if (_searchPositionInList == null)
            return;

        Assert.AreEqual((true, 1), _searchPositionInList.Find(3));
        Assert.AreEqual((true, 3), _searchPositionInList.Find(8));
        Assert.AreEqual((false, -1), _searchPositionInList.Find(9));
    }

    [Test]
    public void SearchPositionInListWithDuplicates()
    {
        Assert.IsNotNull(_searchPositionInListWithDuplicates);

        if (_searchPositionInListWithDuplicates == null)
            return;

        var (isPresent, positions) = _searchPositionInListWithDuplicates.Find(3);
        Assert.IsTrue(isPresent);
        CollectionAssert.AreEqual(new int[] { 1, 3 }, positions);
        (isPresent, positions) = _searchPositionInListWithDuplicates.Find(8);
        Assert.IsTrue(isPresent);
        CollectionAssert.AreEqual(new int[] { 7, 17 }, positions);
        (isPresent, positions) = _searchPositionInListWithDuplicates.Find(9);
        Console.WriteLine(isPresent);
        Assert.IsFalse(isPresent);
        CollectionAssert.AreEqual(Enumerable.Empty<int>(), positions);
    }
}
