string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");
string input = Aoc2022.InputLoader.Load(inputPath) ?? "";
int result = Aoc2022.Day01.Run(input);
Console.WriteLine($"Day 1 result: {result}");

Console.ReadLine();