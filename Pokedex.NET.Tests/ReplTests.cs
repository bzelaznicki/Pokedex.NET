using PokedexNet.Repl;

namespace PokedexNet.Tests;

public class ReplTests
{
    public static IEnumerable<object[]> CleanInputCases()
    {
        yield return new object[]
        {
            "  hello  world  ",
            new[] { "hello", "world" }
        };

        yield return new object[]
        {
            "Charmander Bulbasaur PIKACHU",
            new[] { "charmander", "bulbasaur", "pikachu" }
        };

        yield return new object[]
        {
            "   ",
            Array.Empty<string>()
        };
    }

    [Theory]
    [MemberData(nameof(CleanInputCases))]
    public void CleanInput_ReturnsExpectedWords(string input, string[] expected)
    {
        string[] actual = InputParser.CleanInput(input);

        Assert.Equal(expected, actual);
    }
}
