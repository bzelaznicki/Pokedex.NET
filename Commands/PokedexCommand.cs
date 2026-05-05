using PokedexNet.Repl;

namespace PokedexNet.Commands;

public class PokedexCommand : ICommand
{
    public string Name => "pokedex";
    public string Description => "Shows all caught Pokémon.";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {
        if (state.Pokemon.Count == 0)
        {
            Console.WriteLine("Your Pokédex is empty. Try catching some Pokémon first!");
            return;
        }

        Console.WriteLine($"Your Pokédex contains {state.Pokemon.Count} Pokémon:");
        foreach (var pokemon in state.Pokemon)
        {
            Console.WriteLine($"- {pokemon.Value.Name}");
        }
    }
}