namespace PokedexNet.Repl;

public sealed class ReplSession
{
    public void Start()
    {
        while (true) {
            Console.Write("Pokedex > ");

            string? input = Console.ReadLine();

            if (input is null)
            {
                return;
            }

            string[] words = InputParser.CleanInput(input);

            if (words.Length == 0)
            {
                continue;
            }

            string commandName = words[0];

            if (commandName == "exit")
            {
                return;
            }

            Console.WriteLine($"Unknown command: {commandName}");
        }
    }
}