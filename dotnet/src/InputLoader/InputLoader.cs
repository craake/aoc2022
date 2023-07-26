namespace Aoc2022;

public class InputLoader
{
    public static string? Load(string path)
    {
        try
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
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

        return null;
    }

    public static string[]? LoadLines(string path)
    {
        var str = Load(path);

        return str?.Split("\n");
    }
}
