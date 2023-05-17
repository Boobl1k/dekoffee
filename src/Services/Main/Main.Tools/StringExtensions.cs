using System.Diagnostics.Contracts;

namespace Main.Tools;

public static class StringExtensions
{
    [Pure]
    public static Guid ToGuid(this string str) =>
        Guid.Parse(str);
}