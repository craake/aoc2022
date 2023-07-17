using Aoc2022;

string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");
string input = InputLoader.Load(inputPath) ?? "";

// Day 1 part 1
Func<ICollection<int>, int> getMax = c => c.Max();

// Day 1 part 2
Func<ICollection<int>, int> getTopThree = c => c.Order().TakeLast(3).Sum();

int result = new Aoc2022.CalorieCounter(getTopThree).Count(input);

Console.WriteLine($"Day 1 result: {result}");
Console.ReadLine();