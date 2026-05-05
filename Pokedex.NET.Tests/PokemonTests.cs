using System.Text.Json;
using PokedexNet.PokeApi;

namespace PokedexNet.Tests;

public class PokemonTests
{
    [Fact]
    public void Deserialize_PopulatesStatsTypesAndMoves()
    {
        const string json = """
        {
          "name": "pikachu",
          "base_experience": 112,
          "height": 4,
          "weight": 60,
          "stats": [
            {
              "base_stat": 35,
              "effort": 0,
              "stat": { "name": "hp", "url": "https://pokeapi.co/api/v2/stat/1/" }
            }
          ],
          "types": [
            {
              "slot": 1,
              "type": { "name": "electric", "url": "https://pokeapi.co/api/v2/type/13/" }
            }
          ],
          "moves": [
            {
              "move": { "name": "thunder-shock", "url": "https://pokeapi.co/api/v2/move/84/" }
            }
          ]
        }
        """;

        var pokemon = JsonSerializer.Deserialize<Pokemon>(
            json,
            new JsonSerializerOptions(JsonSerializerDefaults.Web));

        Assert.NotNull(pokemon);
        Assert.Equal("hp", pokemon.Stats.Single().Stat.Name);
        Assert.Equal("electric", pokemon.Types.Single().Type.Name);
        Assert.Equal("thunder-shock", pokemon.Moves.Single().Move.Name);
    }
}
