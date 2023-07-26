using System;

namespace Extensions;

public static class StringExtensions
{
    public static List<char> FindCommonChars(this string s1, string s2)
    {
        List<char> found = new();

        foreach (var c in s2)
        {
            if (s1.Contains(c) && !found.Contains(c))
            {
                found.Add(c);
            }
        }

        return found;
    }

    public static List<char> FindCommonChars(this string s1, string s2, string s3)
    {
        var common1 = s2.FindCommonChars(s1);

        if (common1.Count == 0) return common1;

        var common2 = s3.FindCommonChars(new string(common1.ToArray()));

        return common2;
    }

    public static (string, string) SplitAtHalf(this string s)
    {
        var half = s.Length / 2;
        var a = s.Substring(0, half);
        var b = s.Substring(half);

        return (a, b);
    }
}