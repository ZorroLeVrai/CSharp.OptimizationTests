namespace Exercices.Transformation;

internal class Ex01FriendlyUrlToGuid : RunBase<string, Guid>
{
    private const string TEST_STRING_ID = "AhxC5qsam0mRI_8C1p9Jug";
    private IGuidAndUrlFriendly guidToUrlFriendlyTransformer;

    public Ex01FriendlyUrlToGuid(IGuidAndUrlFriendly guidTransformer)
    {
        guidToUrlFriendlyTransformer = guidTransformer;
    }

    public override string Init()
    {
        return TEST_STRING_ID;
    }

    public override Guid Process()
    {
        return guidToUrlFriendlyTransformer.FriendlyUrlToGuid(Input!);
    }

    public override void DisplayResult()
    {
        Console.WriteLine($"URL friendly: {Input}");
        Console.WriteLine($"Guid: {Output}");
    }
}
