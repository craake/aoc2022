namespace Aoc2022.Day02;

public class CalculateMoveEngine : IGameEngine
{
    public int Run(string[] input)
    {
        return input.Aggregate(0, (acc, line) =>
        {
            if (line.Length != 3) // Valid line is: ["X", " ", "Y"]
            {
                return 0;
            }

            var s1 = new Shape(line[0]);
            var outcome = new Outcome(line[2]);

            var s2 = outcome.Type switch
            {
                OutcomeType.Draw => s1,
                OutcomeType.Lose => s1.Beats(),
                OutcomeType.Win => s1.GetsBeatenBy(),
                _ => throw new NotSupportedException()
            };

            return acc + s2.Value + outcome.Value;
        });
    }
}

