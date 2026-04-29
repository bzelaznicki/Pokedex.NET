namespace PokedexNet.PokeApi;

public class PokeCache : IDisposable
{
    
    private readonly Dictionary<string, CacheEntry<object>> _cache = new();
    private readonly TimeSpan _interval;
    Timer? _reapTimer;

    public PokeCache(int interval)
    {
        _interval = TimeSpan.FromMilliseconds(interval);
        StartReapLoop();
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

    private void StartReapLoop()
    {
        _reapTimer = new Timer(Reap, null, _interval, _interval);
    }


    private void Reap(object? state)
    {
        var now = DateTimeOffset.UtcNow;

        foreach (var item in _cache.ToList())
        {
            if (item.Value.CreatedAt < now - _interval)
            {
                _cache.Remove(item.Key);
            }
        }
    }

    public void StopReapLoop()
    {
        _reapTimer?.Dispose();
        _reapTimer = null;
    }

    public void Dispose()
    {
        StopReapLoop();
        GC.SuppressFinalize(this);
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