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

        Console.WriteLine($"Exploring {location}...");
        Console.WriteLine("Found Pokemon");
    }
    }