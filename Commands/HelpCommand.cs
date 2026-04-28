using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class HelpCommand : ICommand
{

    private readonly CommandRegistry _commands;

    public HelpCommand(CommandRegistry commands)
    {
        _commands = commands;
    }

    public string Name => "help";
    public string Description => "Displays a help message";

    public void Execute(ReplState state, string[] args)
    {
        Console.WriteLine("Welcome to the Pokedex!");
        Console.WriteLine("Usage:");
        Console.WriteLine();
        foreach (ICommand command in _commands.All)
        {
            Console.WriteLine($"{command.Name}: {command.Description}");
        }
    }


}