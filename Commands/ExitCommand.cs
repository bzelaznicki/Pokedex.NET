using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class ExitCommand : ICommand
{
    public string Name => "exit";
    public string Description => "Exits the Pokedex";

    public void Execute(ReplState state, string[] args)
    {
        Console.WriteLine("Closing the Pokedex... Goodbye!");
        state.ShouldExit = true;
    }
}