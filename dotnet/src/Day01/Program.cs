using Aoc2022;

string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");
string input = InputLoader.Load(inputPath) ?? "";
CaloriesCountStrategy<int> caloriesCountDel = (ICollection<int> coll) => coll.Max();
CaloriesCountStrategy<int> caloriesCountDel2 = (ICollection<int> coll) => coll.Order().TakeLast(3).Sum();

int result = new Aoc2022.Day01(caloriesCountDel2).Run(input);
Console.WriteLine($"Day 1 result: {result}");

Console.ReadLine();