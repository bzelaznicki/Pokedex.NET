using System.Security.Cryptography;
using PokedexNet.Repl;

namespace PokedexNet.Commands;
public class CatchCommand : ICommand
{
    public string Name => "catch";
    public string Description => "Catches the Pokémon. Usage: catch <pokemon>";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("You must provide the name of a Pokemon.");
            return;
        }

        string pokemonName = args[0];

        if (state.Pokemon.ContainsKey(pokemonName))
        {
            Console.WriteLine($"You've already caught {pokemonName}!");
            return;
        }

        try {
            var targetPokemon = await state.PokeApiClient.FetchPokemonAsync(pokemonName);

            Console.WriteLine($"Throwing a Pokeball at {pokemonName}...");

            int chance = Convert.ToInt32(100 - Math.Sqrt(targetPokemon.BaseExperience) * 5);

            if (chance < 10)
            {
                chance = 10;
            } else if (chance > 90)
            {
                chance = 90;
            }

            int r = RandomNumberGenerator.GetInt32(100);

            if (r < chance)
            {
                Console.WriteLine($"{targetPokemon.Name} was caught!");
                state.Pokemon.Add(pokemonName, targetPokemon);
            } else
            {
                Console.WriteLine($"{targetPokemon.Name} escaped!");
            }
 
        } 
        catch
        {
            Console.WriteLine("Pokemon not found");
        }
    }
}