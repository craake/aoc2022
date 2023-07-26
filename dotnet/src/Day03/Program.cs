using System;
using Aoc2022;
using Aoc2022.Day03;
using Extensions;

string[] lines = InputLoader.LoadLines("Input") ?? throw new Exception("Input is empty");
lines = lines.Where(l => l != "").ToArray();

// Part 1
int result1 = lines.Sum(line =>
{
    if (line == string.Empty) return 0;

    var (a, b) = line.SplitAtHalf();
    List<char> found = b.FindCommonChars(a);
    return found.Aggregate(0, (acc, c) => acc + CharValue.Get(c));
});

// Part 2
var result2 = 0; 
var cursor = 0;
var step = 3;

while (cursor < lines.Length)
{
    var group = lines[cursor..(cursor + step)];
    List<char> found = group[0].FindCommonChars(group[1], group[2]);
    result2 += found.Aggregate(0, (acc, c) => acc + CharValue.Get(c));

    cursor += step;
}

Console.WriteLine(result2);
Console.ReadLine();
