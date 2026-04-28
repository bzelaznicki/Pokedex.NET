namespace PokedexNet.PokeApi;

public class NamedApiResource
{
    public string Name { get; set; }
    public string Url { get; set; }

    public NamedApiResource()
    {
        Name = "";
        Url = "";
    }
}