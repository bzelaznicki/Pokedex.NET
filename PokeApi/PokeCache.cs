namespace PokedexNet.PokeApi;

public class PokeCache
{
    
    private readonly Dictionary<string, CacheEntry<object>> _cache = new();
    private TimeSpan Interval;
    Timer? reapTimer;

    public PokeCache(int interval)
    {
        Interval = TimeSpan.FromSeconds(interval);
        startReapLoop();
    }

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

    private void startReapLoop()
    {
        reapTimer = new Timer(reap, null, TimeSpan.Zero, Interval);
    }


    private void reap(object? state)
    {
        var now = DateTimeOffset.UtcNow;

        foreach (var item in _cache.ToList())
        {
            if (item.Value.CreatedAt < now - Interval)
            {
                _cache.Remove(item.Key);
            }
        }
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