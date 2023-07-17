namespace Aoc2022.Day02.Tests;

public class GameTests
{
    private string _input = "";

    [SetUp]
    public void Setup()
    {
        _input = "A Y\nB X\nC Z";
    }

    [Test]
    public void Test_ResolvesResultOfOutcomeProperly()
    {
        Assert.That(GameClient.PlayOutcome(_input), Is.EqualTo(15));
    }

    [Test]
    public void Test_ResolvesResultOfShapeProperly()
    {
        Assert.That(GameClient.PlayShape(_input), Is.EqualTo(12));
    }
}
