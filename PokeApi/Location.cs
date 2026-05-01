using System.Text.Json.Serialization;
namespace PokedexNet.PokeApi;

public class Location
{
    public required string Name { get; set; }

    [JsonPropertyName("pokemon_encounters")]
    public PokemonEncounter[] PokemonEncounters { get; set; } = [];
}

public class PokemonEncounter
{
    public NamedApiResource Pokemon {get;set;} = new();
}
