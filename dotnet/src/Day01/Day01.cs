namespace Aoc2022;

public delegate int CaloriesCountStrategy<T>(ICollection<T> data);

public class Day01
{
    private CaloriesCountStrategy<int>? _countingDelegate;
    private CaloriesCountStrategy<int> _defaultCountStrategy = (ICollection<int> coll) => coll.Max();

    public Day01() {}

    public Day01(CaloriesCountStrategy<int> del) => this._countingDelegate = del;

    public int Run(string input)
    {
        this._countingDelegate = this._countingDelegate ?? this._defaultCountStrategy;

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
                break;
            }
        }

        return this._countingDelegate(calories);
    }
}
