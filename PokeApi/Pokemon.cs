using System.Text.Json.Serialization;

namespace PokedexNet.PokeApi;

public class Pokemon
{
    public required string Name {get;set;}

    [JsonPropertyName("base_experience")]
    public int BaseExperience {get;set;}
    
    public int Height {get;set;}
    public int Weight {get;set;}

    public PokemonAbility[] Abilities {get;set;} = [];

    public PokemonMove[] Moves { get; set; } = [];

    public PokemonStat[] Stats { get; set; } = [];

    public PokemonType[] Types { get; set; } = [];
}

public class PokemonAbility
{
    public required NamedApiResource Ability {get;set;}

    public bool IsHidden {get;set;}
    public int Slot {get;set;}
}

public class PokemonStat
{
    [JsonPropertyName("base_stat")]
    public int BaseStat {get;set;}
    public int Effort {get;set;}
    public required NamedApiResource Stat {get;set;}
}

public class PokemonType
{
    public int Slot {get;set;}
    public required NamedApiResource Type {get;set;}
}

public class PokemonMove
{
    public required NamedApiResource Move {get;set;}
}
