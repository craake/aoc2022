namespace Extensions;

public static class StringExtensions
{
    public static List<char> FindOccurences(this string haystack, string needle)
    {
        List<char> found = new();

        foreach (var c in needle)
        {
            if (haystack.Contains(c) && !found.Contains(c))
            {
                found.Add(c);
            }
        }

        return found;
    }

    public static (string, string) SplitAtHalf(this string s)
    {
        var half = s.Length / 2;
        var a = s.Substring(0, half);
        var b = s.Substring(half);

        return (a, b);
    }
}