namespace Aoc22.Day01.Tests;

public class CalorieCounterTests
{
    private string _input;

    [SetUp]
    public void Setup()
    {
        _input = "1000\n2000\n3000\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n10000";
    }

    [Test]
    public void Count_HandlesDirtyInput()
    {
        var input = "\n1000\nxxxxx\n3000\n\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n\n\n10000\nyyyy";
        var result = new Aoc2022.CalorieCounter().Count(input);
        Assert.That(result, Is.EqualTo(24000));
    }

    [Test]
    public void Count_HandlesMultipleEmptyLineInput()
    {
        var input = "\n1000\n2000\n3000\n\n\n4000\n5000\n6000\n\n7000\n8000\n9000\n\n\n\n10000";
        var result = new Aoc2022.CalorieCounter().Count(input);
        Assert.That(result, Is.EqualTo(24000));
    }

    [Test]
    public void Count_CallsDefaultResultStrategy()
    {
        var result = new Aoc2022.CalorieCounter().Count(_input);
        Assert.That(result, Is.EqualTo(24000));
    }

    [Test]
    public void Count_CallsGivenResultStrategy()
    {
        CalorieCounter.CountFinished<int> d = (ICollection<int> c) => c.Min();
        var result = new Aoc2022.CalorieCounter(d).Count(_input);
        Assert.That(result, Is.EqualTo(6000));
    }
}