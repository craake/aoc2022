try
{
    using (var sr = new StreamReader("./Input"))
    {
        string input = sr.ReadToEnd();
        int result = Aoc2022.Day01.Run(input);
        Console.WriteLine($"Day 1 result: {result}");
    }
}
catch (IOException)
{
    Console.WriteLine("Input file not found.");
}
catch (Exception)
{
    Console.WriteLine("Something else unplanned happened while trying to read a file");
}