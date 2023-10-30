using NUnit.Framework;
using OptimizationTests.DateTimeParsers;

namespace UnitTests.DateTimeParsers;

[TestFixture]
public class DateParserTests
{
    private const string DateTimeInString = "2023-09-28T01:02:03Z";
    private DateTimeParser dateTimeParser = new();

    [OneTimeSetUp]
    public void Init()
    {
        dateTimeParser = new DateTimeParser();
    }


    [Test]
    public void DateParserDateTimeFromStr_ParseWellFormatedDate_ReturnsDateTime()
    {
        DateTime dt;
        Assert.IsTrue(dateTimeParser.TryParseDateTimeFromStr(DateTimeInString, out dt));
        Assert.AreEqual(new DateTime(2023, 09, 28, 1, 2, 3, DateTimeKind.Utc), dt);
    }

    [Test]
    public void DateParserDateTimeFromParse_ParseWellFormatedDate_ReturnsDateTime()
    {
        DateTime dt;
        Assert.IsTrue(dateTimeParser.TryParseDateFromSpan(DateTimeInString, out dt));
        Assert.AreEqual(new DateTime(2023, 09, 28, 1, 2, 3, DateTimeKind.Utc), dt);
    }

    [Test]
    public void DateParserUsingSplits_ParseWellFormatedDate_ReturnsDateTime()
    {
        DateTime dt;
        Assert.IsTrue(dateTimeParser.TryParseDateUsingSplits(DateTimeInString, out dt));
        Assert.AreEqual(new DateTime(2023, 09, 28, 1, 2, 3, DateTimeKind.Utc), dt);
    }

    [Test]
    public void DateParserUsingSplices_ParseWellFormatedDate_ReturnsDateTime()
    {
        DateTime dt;
        Assert.IsTrue(dateTimeParser.TryParseDateUsingSlices(DateTimeInString, out dt));
        Assert.AreEqual(new DateTime(2023, 09, 28, 1, 2, 3, DateTimeKind.Utc), dt);
    }

    [Test]
    public void DateParserUsingSplicesCustomParser_ParseWellFormatedDate_ReturnsDateTime()
    {
        DateTime dt;
        Assert.IsTrue(dateTimeParser.TryParseDateUsingSlicesCustomParser(DateTimeInString, out dt));
        Assert.AreEqual(new DateTime(2023, 09, 28, 1, 2, 3, DateTimeKind.Utc), dt);
    }
}
