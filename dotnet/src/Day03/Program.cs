using Aoc2022;
using Aoc2022.Day03;
using Extensions;

string[] lines = InputLoader.LoadLines("Input") ?? throw new Exception("Input is empty");

int result = lines.Sum(line =>
{
    if (line == string.Empty) return 0;

    var (a, b) = line.SplitAtHalf();
    List<char> found = b.FindOccurences(a);
    return found.Aggregate(0, (acc, c) => acc + CharValue.Get(c));
});

Console.WriteLine(result);
Console.ReadLine();
