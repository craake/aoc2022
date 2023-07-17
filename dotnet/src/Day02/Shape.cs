namespace Aoc2022.Day02;

public enum ShapeType : int
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}

public class Shape : IEquatable<Shape>
{
    public ShapeType Type { get; }
    public int Value => (int)Type;

    public Shape(char c)
    {
        Type = c switch
        {
            'X' or 'A' => ShapeType.Rock,
            'Y' or 'B' => ShapeType.Paper,
            'Z' or 'C' => ShapeType.Scissors,
            _ => throw new NotSupportedException()
        };
    }

    public Shape(ShapeType t) => Type = t;

    public Shape Beats()
    {
        return Type switch
        {
            ShapeType.Rock => new Shape(ShapeType.Scissors),
            ShapeType.Paper => new Shape(ShapeType.Rock),
            ShapeType.Scissors => new Shape(ShapeType.Paper),
            _ => throw new NotSupportedException()
        };
    }

    public Shape GetsBeatenBy()
    {
        return Type switch
        {
            ShapeType.Rock => new Shape(ShapeType.Paper),
            ShapeType.Paper => new Shape(ShapeType.Scissors),
            ShapeType.Scissors => new Shape(ShapeType.Rock),
            _ => throw new NotSupportedException()
        };
    }

    public bool Equals(Shape? shape)
    {
        if (shape == null)
        {
            return false;
        }

        return Value == shape.Value;
    }
}
