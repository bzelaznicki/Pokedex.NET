using PokedexNet.Repl;

namespace PokedexNet.Commands;

public interface ICommand
{
    string Name { get; }
    string Description { get; }
    void Execute(ReplState state, string[] args);
}