using PokedexNet.Repl;

namespace PokedexNet.Commands;

public interface ICommand
{
    string Name { get; }
    string Description { get; }
    Task ExecuteAsync(ReplState state, string[] args);
}