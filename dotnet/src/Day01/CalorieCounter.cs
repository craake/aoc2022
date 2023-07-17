namespace Aoc2022;

public class CalorieCounter
{
    private readonly Func<ICollection<int>, int>? _resultStrategy;
    private readonly Func<ICollection<int>, int> _defaultStrategy = c => c.Max();

    public CalorieCounter() { }

    public CalorieCounter(Func<ICollection<int>, int> rs) => _resultStrategy = rs;

    public int Count(string input)
    {
        string[] lines = input.Trim().Split('\n');
        List<int> calories = new();
        int currentCalories = 0;

        foreach (var line in lines)
        {
            if (line.Equals(String.Empty))
            {
                calories.Add(currentCalories);
                currentCalories = 0;
                continue;
            }

            try
            {
                int lineCalories = Int32.Parse(line);
                currentCalories += lineCalories;
            }
            catch (Exception)
            {
                Console.WriteLine($"Cannot parse {line} to int32");
            }
        }

        return _resultStrategy?.Invoke(calories) ?? _defaultStrategy(calories);
    }
}
