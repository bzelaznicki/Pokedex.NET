using System.Collections.ObjectModel;

namespace PokedexNet.PokeApi;

public class LocationAreaResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }

    public List<NamedApiResource> Results { get; set; }

    public LocationAreaResponse()
    {
        Results = new();
    }
}