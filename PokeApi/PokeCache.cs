namespace PokedexNet.PokeApi;

public class PokeCache
{
    
    private readonly Dictionary<string, CacheEntry<object>> _cache = new();

    public void Add<T>(string key, T value)
    {
        _cache[key] = new CacheEntry<object>(value);
    }

    public T? Get<T>(string key)
    {
        if (!_cache.TryGetValue(key, out CacheEntry<object>? entry))
        {
            return default;
        }

        if (entry.Value is T value)
        {
            return value;
        }
        return default;
    }
}

public class CacheEntry<T>
{
    public DateTimeOffset CreatedAt { get; }
    public T? Value { get; set; }

    public CacheEntry(T? value)
    {
        CreatedAt = DateTimeOffset.UtcNow;
        Value = value;
    }
}