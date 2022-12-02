using Models;

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
        Console.WriteLine("Time format: days:hours:minutes:seconds");
        foreach (var command in _commands)
        {
            Console.WriteLine(command.ToString());
        }
        return true;
    }

    public override Range NumberOfArguments { get; } = 0..0;
    public override string CommandName => "help";
    public override string[] ArgumentsNames => Array.Empty<string>();
}