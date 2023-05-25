namespace Aoc2022;

public class CalorieCounter
{
    public delegate int CountFinished<T>(ICollection<T> data);

    private CountFinished<int>? _resultStrategy;
    private CountFinished<int> _defaultStrategy = (ICollection<int> c) => c.Max();

    public CalorieCounter() { }

    public CalorieCounter(CountFinished<int> d) => this._resultStrategy = d;

    public int Count(string input)
    {
        string[] lines = input.Trim().Split('\n');
        List<int> calories = new List<int>();
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
