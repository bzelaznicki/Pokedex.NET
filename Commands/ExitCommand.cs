using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class ExitCommand : ICommand
{
    public string Name => "exit";
    public string Description => "Exits the Pokedex";

    public Task ExecuteAsync(ReplState state, string[] args)
    {
        Console.WriteLine("Closing the Pokedex... Goodbye!");
        state.ShouldExit = true;
        return Task.CompletedTask;
    }
}