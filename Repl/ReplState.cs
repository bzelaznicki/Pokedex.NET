using PokedexNet.PokeApi;

namespace PokedexNet.Repl;

public sealed class ReplState
{
    public bool ShouldExit { get; set; }
    public PokeApiClient PokeApiClient { get; set; }
    public string? NextLocationsUrl { get; set; }
    public string? PreviousLocationsUrl { get; set; }

    public Dictionary<string, Pokemon> Pokemon = [];

    public ReplState()
    {
        PokeApiClient = new PokeApiClient(10000);
    }

}
