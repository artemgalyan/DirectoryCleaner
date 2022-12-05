using Common;

namespace DirectoryCleaner;

public class HelpCommand : Command
{
    private readonly List<Command> _commands;

    public HelpCommand(List<Command> commands)
    {
        _commands = commands;
    }

    public override bool Execute(string[] args, Settings settings)
    {
        Console.WriteLine("[!] Time format: days:hours:minutes:seconds");
        int alignment = _commands.MaxBy(c => c.CommandName.Length)!.CommandName.Length;
        foreach (var command in _commands)
        {
            Console.WriteLine(CommandToString(command));
        }
        return true;
    }

    private string CommandToString(Command c)
    {
        
        var @params = string.Join(" ", c.ArgumentsNames);
        if (@params.Length == 0)
        {
            @params = "no arguments";
        }
        return
            $"> {c.CommandName}, number of arguments: {c.NumberOfArguments.ToNormalizedString()}, arguments: {@params}";
    }

    public override Range NumberOfArguments { get; } = 0..0;
    public override string CommandName => "help";
    public override string[] ArgumentsNames => Array.Empty<string>();
}