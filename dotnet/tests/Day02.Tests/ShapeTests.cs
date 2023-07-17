namespace Aoc2022.Day02.Tests;

public class ShapeTests
{
	[Test]
	public void Test_ResolvesShapeProperly()
	{
		var s1 = new Shape('X'); // Rock
        var s2 = new Shape('B'); // Paper
        var s3 = new Shape('Z'); // Scissors
        var s4 = new Shape('C'); // Scissors

        Assert.That(s1.Type, Is.EqualTo(ShapeType.Rock));
        Assert.That(s2.Type, Is.EqualTo(ShapeType.Paper));
        Assert.That(s3.Type, Is.EqualTo(s4.Type));
    }

    [Test]
    public void Test_ResolvesOutcomeProperly()
    {
        var s1 = new Shape('X'); // Rock
        var s2 = new Shape('B'); // Paper
        var s3 = new Shape('Z'); // Scissors

        Assert.That(s1.Beats().Equals(s2), Is.False);
        Assert.That(s1.Beats().Equals(s3), Is.True);
        Assert.That(s1.Beats(), Is.EqualTo(s3));
        Assert.That(s2.Beats(), Is.EqualTo(s1));
    }
}
