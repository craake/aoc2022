namespace Aoc2022;

public class Day01
{
    public static int Run(string input)
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
                break;
            }
        }

        return calories.Order().TakeLast(3).Sum();
    }
}
