namespace Aoc2022.Day02;

public static class GameClient
{
    public static int PlayOutcome(string input)
    {
        return Play(GameMode.Outcome, input);
    }

    public static int PlayShape(string input)
    {
        return Play(GameMode.Move, input);
    }

    private static int Play(GameMode mode, string input)
    {
        var lines = input.Split("\n");

        return mode switch
        {
            GameMode.Outcome => new CalculateOutcomeEngine().Run(lines),
            GameMode.Move => new CalculateMoveEngine().Run(lines),
            _ => throw new NotSupportedException(),
        };
    }
}