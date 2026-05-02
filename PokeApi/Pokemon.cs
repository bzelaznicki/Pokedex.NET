using System.Text.Json.Serialization;

namespace PokedexNet.PokeApi;

public class Pokemon
{
    public required string Name {get;set;}

    [JsonPropertyName("base_experience")]
    public int BaseExperience {get;set;}
}