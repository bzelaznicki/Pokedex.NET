namespace PokedexNet.Commands;

public sealed class CommandRegistry
{
    private readonly Dictionary<string, ICommand> _commands = new();

    public IReadOnlyCollection<ICommand> All => _commands.Values;

    public void Register(ICommand command)
    {
        _commands[command.Name] = command;
    }

    public bool TryGet(string name, out ICommand? command)
    {
        return _commands.TryGetValue(name, out command);
    }

    public static CommandRegistry CreateDefault()
    {
        var registry = new CommandRegistry();

        registry.Register(new HelpCommand(registry));
        registry.Register(new ExitCommand());

        return registry;
    }
}