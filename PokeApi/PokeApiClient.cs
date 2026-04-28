using System.Net.Http.Json;

namespace PokedexNet.PokeApi;

public class PokeApiClient
{
    private static readonly string BaseUrl = "https://pokeapi.co/api/v2";

    private static readonly HttpClient HttpClient = new();


    public async Task<LocationAreaResponse> FetchLocationAreasAsync(string? pageUrl = null)
    {
        string url = $"{BaseUrl}/location-area?limit=20";

        if (pageUrl != null)
        {
            url = pageUrl;
        }
        var res = await HttpClient.GetFromJsonAsync<LocationAreaResponse>(url);


        if (res == null)
        {
            throw new InvalidOperationException("Cannot fetch data");
        }
        return res;
    }

}