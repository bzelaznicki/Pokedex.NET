using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class ExploreCommand : ICommand
{
    public string Name => "explore";
    public string Description => "Explores a location";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("You must provide a location");
            return;
        }

        string location = args[0];        
        try
        {
            Console.WriteLine($"Exploring {location}...");
            var locationData = await state.PokeApiClient.FetchLocationAsync(location);

            Console.WriteLine("Found Pokemon:"); 
            foreach(var encounter in locationData.PokemonEncounters)
            {
                Console.WriteLine($" - {encounter.Pokemon.Name}");
            }


        } catch 
        {
            Console.WriteLine($"Location not found: {location}");
        }

    }
    }