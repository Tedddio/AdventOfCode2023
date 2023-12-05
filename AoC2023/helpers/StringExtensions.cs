namespace AoC2023;

public static class StringExtensions
{
    public static int GetIndex(this string line, string value, bool fromEnd = false)
    {
        return fromEnd ? line.LastIndexOf(value)
            : line.IndexOf(value);
    }
}
