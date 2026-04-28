using System.Text.RegularExpressions;

namespace PokedexNet.Repl;

public static class InputParser
{
    public static string[] CleanInput(string input)
    {
        return Regex
            .Split(input.Trim().ToLowerInvariant(), @"\s+")
            .Where(word => word.Length > 0)
            .ToArray();
    }
}
