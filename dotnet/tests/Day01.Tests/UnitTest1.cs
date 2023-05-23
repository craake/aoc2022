namespace Aoc22.Day01.Tests;

public class Tests
{
    private string _input;

    [SetUp]
    public void Setup()
    {
        _input = "1000\n2000\n3000\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n10000";
    }

    [Test]
    public void TestRun()
    {
        var result = Aoc2022.Day01.Run(_input);
        Assert.That(result, Is.EqualTo(24000));
    }
}