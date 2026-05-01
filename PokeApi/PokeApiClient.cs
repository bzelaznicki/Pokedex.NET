using System.Net.Http.Json;

namespace PokedexNet.PokeApi;

public class PokeApiClient
{
    private static readonly string BaseUrl = "https://pokeapi.co/api/v2";

    private static readonly HttpClient HttpClient = new();

    private readonly PokeCache _pokeCache;


    public PokeApiClient(int cacheInternal)
    {
        _pokeCache = new(cacheInternal);
    }


    public async Task<LocationAreaResponse> FetchLocationAreasAsync(string? pageUrl = null)
    {
        string url = $"{BaseUrl}/location-area?limit=20";

        if (pageUrl != null)
        {
            url = pageUrl;
        }
        var cached = _pokeCache.Get<LocationAreaResponse>(url);

        if (cached != null)
        {
            return cached;
        }
        var res = await HttpClient.GetFromJsonAsync<LocationAreaResponse>(url);


        if (res == null)
        {
            throw new InvalidOperationException("Cannot fetch data");
        }

        _pokeCache.Add(url, res);
        return res;
    }

    public async Task<Location> FetchLocationAsync(string locationName)
    {
        var url = $"{BaseUrl}/location-area/{locationName}";
        var cached = _pokeCache.Get<Location>(url);

        if (cached != null)
        {
            return cached;
        }

        var res = await HttpClient.GetFromJsonAsync<Location>(url);

        if (res == null)
        {
            throw new InvalidOperationException("Cannot fetch data");
        }

        _pokeCache.Add(url, res);

        return res;

    }

}