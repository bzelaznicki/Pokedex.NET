using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class MapBackCommand : ICommand
{
    public string Name => "mapb";
    public string Description => "Displays previous 20 location areas";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {
        if (state.PreviousLocationsUrl == null)
        {
            Console.WriteLine("you're on the first page");
            return;
        }
        try
        {
            var response = await state.PokeApiClient.FetchLocationAreasAsync(state.PreviousLocationsUrl);
            foreach (var location in response.Results)
            {
                Console.WriteLine(location.Name);
            }
            state.NextLocationsUrl = response.Next;
            state.PreviousLocationsUrl = response.Previous;


        }
        catch
        {
            Console.WriteLine("Error fetching data");
        }

    }
}