namespace Aoc2022.Day02;

public class CalculateOutcomeEngine : IGameEngine
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
            var s2 = new Shape(line[2]);
            var outcome = s1.Equals(s2) ? OutcomeType.Draw : (s2.Beats().Equals(s1) ? OutcomeType.Win : OutcomeType.Lose);

            return acc + s2.Value + (int)outcome;
        });
    }
}
