using PokedexNet.PokeApi;

namespace PokedexNet.Tests;

public class PokeCacheTests 
{

    private readonly PokeCache _cache;

    public PokeCacheTests()
    {
        _cache = new PokeCache(30);
    }

    [Fact]
    public void Get_ReturnsCachedValue()
    {
        
        string key = "https://example.com";
        string value = "testdata";

        _cache.Add(key, value);
        string? cached = _cache.Get<string>(key);

        Assert.Equal(value, cached);   
    }

    [Fact]
    public void Get_ReturnsNull_WhenKeyIsMissing()
    {
        string? cached = _cache.Get<string>("nothing");

        Assert.Null(cached);
    }

    [Fact]
    public void Add_WhenKeyAlreadyExists_ReplacesCachedValue()
    {
        string key = "https://example.com";
        string oldValue = "testdata";
        string newValue = "newdata";

        _cache.Add(key, oldValue);

        _cache.Add(key, newValue);

        string? cached = _cache.Get<string>(key);

        Assert.Equal(cached, newValue);
        
    }
}