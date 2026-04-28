using System.Diagnostics.CodeAnalysis;
using PokedexNet.Commands;

namespace PokedexNet.Repl;

public sealed class ReplSession
{

    private readonly CommandRegistry _commands = CommandRegistry.CreateDefault();
    private readonly ReplState _state = new();

    public async Task StartAsync()
    {
        while (!_state.ShouldExit)
        {
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
            string[] args = words.Skip(1).ToArray();

            if (!_commands.TryGet(commandName, out ICommand? command))
            {
                Console.WriteLine("Unknown command");
                continue;
            }

            await command.ExecuteAsync(_state, args);


        }
    }
}