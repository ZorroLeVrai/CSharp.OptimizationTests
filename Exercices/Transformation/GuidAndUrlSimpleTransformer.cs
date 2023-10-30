using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace Exercices.Transformation;

public interface IGuidAndUrlFriendly
{
    string GuidToFriendlyUrl(Guid guid);
    Guid FriendlyUrlToGuid(string id);
}

internal static class StringConstants
{
    internal const char SLASH_CHARACTER = '/';
    internal const char PLUS_CHARACTER = '+';
    internal const char DASH_CHARACTER = '-';
    internal const char UNDERSCORE_CHARACTER = '_';
    internal const char EQUAL_CHARACTER = '=';

    internal const byte SLASH_BYTE = (byte)'/';
    internal const byte PLUS_BYTE = (byte)'+';

    internal const string BASE64_POSTFIX = "==";
}

public class GuidAndUrlSimpleTransformer : IGuidAndUrlFriendly
{
    public string GuidToFriendlyUrl(Guid guid)
    {
        var base64Id = Convert.ToBase64String(guid.ToByteArray())
            .Replace(StringConstants.SLASH_CHARACTER, StringConstants.DASH_CHARACTER)
            .Replace(StringConstants.PLUS_CHARACTER, StringConstants.UNDERSCORE_CHARACTER);
        return base64Id.Substring(0, base64Id.Length - 2);
    }

    public Guid FriendlyUrlToGuid(string id)
    {
        var guidStr = string.Concat(id.Replace(StringConstants.DASH_CHARACTER, StringConstants.SLASH_CHARACTER)
            .Replace(StringConstants.UNDERSCORE_CHARACTER, StringConstants.PLUS_CHARACTER), StringConstants.BASE64_POSTFIX);

        return new Guid(Convert.FromBase64String(guidStr));
    }
}

public class GuidAndUrlOptimizedTransformer : IGuidAndUrlFriendly
{
    public Guid FriendlyUrlToGuid(string urlFriendlyId)
    {
        Span<char> guidBase64Characters = stackalloc char[24];

        for (int i = 0; i < 22; ++i)
        {
            guidBase64Characters[i] = urlFriendlyId[i] switch
            {
                StringConstants.DASH_CHARACTER => StringConstants.SLASH_CHARACTER,
                StringConstants.UNDERSCORE_CHARACTER => StringConstants.PLUS_CHARACTER,
                _ => urlFriendlyId[i]
            };
        }

        guidBase64Characters[22] = StringConstants.EQUAL_CHARACTER;
        guidBase64Characters[23] = StringConstants.EQUAL_CHARACTER;

        Span<byte> guidBytes = stackalloc byte[16];
        Convert.TryFromBase64Chars(guidBase64Characters, guidBytes, out _);

        return new Guid(guidBytes);
    }

    public string GuidToFriendlyUrl(Guid guid)
    {
        Span<byte> guidBytes = stackalloc byte[16];
        Span<byte> guidBase64Bytes = stackalloc byte[24];

        MemoryMarshal.TryWrite(guidBytes, ref guid);
        Base64.EncodeToUtf8(guidBytes, guidBase64Bytes, out _, out _);

        Span<char> base64UrlFriendlyCharacters = stackalloc char[22];

        for (var i = 0; i < 22; ++i)
        {
            base64UrlFriendlyCharacters[i] = guidBase64Bytes[i] switch
            {
                StringConstants.SLASH_BYTE => StringConstants.DASH_CHARACTER,
                StringConstants.PLUS_BYTE => StringConstants.UNDERSCORE_CHARACTER,
                _ => (char)guidBase64Bytes[i]
            };
        }

        return new string(base64UrlFriendlyCharacters);
    }
}