using PokedexNet.PokeApi;

namespace PokedexNet.Tests;

public class PokeCacheTests 
{

    [Fact]
    public void Get_ReturnsCachedValue()
    {
        using var cache = new PokeCache(300);

        string key = "https://example.com";
        string value = "testdata";

        cache.Add(key, value);
        string? cached = cache.Get<string>(key);

        Assert.Equal(value, cached);
    }


    [Fact]
    public void Get_ReturnsNull_WhenKeyIsMissing()
    {
        using var cache = new PokeCache(300);
        string? cached = cache.Get<string>("nothing");

        Assert.Null(cached);
    }

    [Fact]
    public void Add_WhenKeyAlreadyExists_ReplacesCachedValue()
    {
        using var cache = new PokeCache(300);
        string key = "https://example.com";
        string oldValue = "testdata";
        string newValue = "newdata";

        cache.Add(key, oldValue);

        cache.Add(key, newValue);

        string? cached = cache.Get<string>(key);

        Assert.Equal(newValue, cached);
        
    }

    [Fact]
    public async Task Add_ItemsGetRemovedFromCacheAfterExpiry()
    {
        int interval = 300;
        using var cache = new PokeCache(interval);
        string key = "https://example.com";
        string value = "testdata";

        cache.Add(key, value);

        await Task.Delay(interval * 2 + 100);

        string? cached = cache.Get<string>(key);

        Assert.Null(cached);
    }


    [Fact]
    public async Task StopReapLoop_PreventsExpiryCleanup()
    {
        int interval = 300;
        using var cache = new PokeCache(interval);
        string key = "https://example.com";
        string value = "testdata";

        cache.Add(key, value);
        cache.StopReapLoop();

        await Task.Delay(interval * 2 + 100);

        string? cached = cache.Get<string>(key);

        Assert.Equal(value, cached);

    }

    [Fact]
    public void Get_ReturnsNull_WhenTypeDoesNotMatch()
    {
        using var cache = new PokeCache(300);

        string key = "https://example.com";
        string value = "testdata";

        cache.Add<string>(key, value);
        var cached = cache.Get<LocationAreaResponse>(key);

        Assert.Null(cached);       
    }

}