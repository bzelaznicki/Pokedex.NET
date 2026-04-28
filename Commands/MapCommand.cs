using PokedexNet.Repl;

namespace PokedexNet.Commands;

public sealed class MapCommand : ICommand
{
    public string Name => "map";
    public string Description => "Displays next 20 location areas";

    public async Task ExecuteAsync(ReplState state, string[] args)
    {
        try
        {
            var response = await state.PokeApiClient.FetchLocationAreasAsync(state.NextLocationsUrl);
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