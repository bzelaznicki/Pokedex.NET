using PokedexNet.PokeApi;
using PokedexNet.Repl;

namespace PokedexNet.Commands;

public class InspectCommand : ICommand
{
    public string Name => "inspect";
    public string Description => "Inspects a caught Pokémon. Usage: inspect <pokemon>";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("You must provide a Pokémon name");
            return;
        }

        string pokemonName = args[0];

    
        var found = state.Pokemon.TryGetValue(pokemonName, out var pokemon);

        if (!found || pokemon is null)
        {
            Console.WriteLine($"{pokemonName} was not found in your Pokédex. Try catching it first!");
            return;
        }

        Console.WriteLine($"Name: {pokemon.Name}");
        Console.WriteLine($"Height: {pokemon.Height}");
        Console.WriteLine($"Weight: {pokemon.Weight}");

        Console.WriteLine("Stats:");
        foreach (var stat in pokemon.Stats)
        {
            Console.WriteLine($" -{stat.Stat.Name}: {stat.BaseStat}");
        }

        Console.WriteLine("Types:");
        foreach (var type in pokemon.Types)
        {
            Console.WriteLine($" -{type.Type.Name}");
        }
        Console.WriteLine("Moves:");
        foreach (var move in pokemon.Moves)
        {
            Console.WriteLine($" -{move.Move.Name}");
        }

        
    }
}
