namespace Exercices.Transformation;

internal class Ex01GuidToFriendlyUrl : RunBase<Guid, string>
{
    private static readonly Guid TEST_GUID = new Guid("e6421c02-1aab-499b-9123-ef02d69f49ba");
    private IGuidAndUrlFriendly guidToUrlFriendlyTransformer;

    public Ex01GuidToFriendlyUrl(IGuidAndUrlFriendly guidTransformer)
    {
        guidToUrlFriendlyTransformer = guidTransformer;
    }

    public override Guid Init()
    {
        return TEST_GUID;
    }

    public override string Process()
    {
        return guidToUrlFriendlyTransformer.GuidToFriendlyUrl(Input);
    }

    public override void DisplayResult()
    {
        Console.WriteLine($"Guid: {Input}");
        Console.WriteLine($"URL friendly: {Output}");
    }
}
