using Aoc2022;
using Aoc2022.Day02;

string? input = InputLoader.Load("Input");

if (input == null)
{
    Console.WriteLine("Input file cannot be found");
}
else
{
    // Day 2 part 1
    //int result = GameClient.PlayOutcome(input);

    // Day 2 part 2
    int result = GameClient.PlayShape(input);

    Console.WriteLine(result.ToString());
    Console.ReadLine();
}
