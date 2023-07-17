namespace Aoc2022.Day02;

public enum OutcomeType : int
{
    Lose = 0,
    Draw = 3,
    Win = 6
}

public class Outcome
{
    public OutcomeType Type { get; }
    public int Value => (int)Type;

    public Outcome(char c)
    {
        Type = c switch
        {
            'X' => OutcomeType.Lose,
            'Y' => OutcomeType.Draw,
            'Z' => OutcomeType.Win,
            _ => throw new NotSupportedException(),
        };
    }
}
