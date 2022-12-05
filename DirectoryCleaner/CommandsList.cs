using Common;

namespace DirectoryCleaner;

public class CommandsList
{
    private readonly List<Command> _commands = new();
    private readonly Settings _settings;

    public CommandsList(Settings settings)
    {
        _settings = settings;
        AddCommand(new HelpCommand(_commands));
    }

    public bool Execute(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException("Empty args");
        }

        var command = _commands.FirstOrDefault(c => c.CommandName == args[0]);
        if (command is null)
        {
            Console.WriteLine($"Command {args[0]} is not found");
            Console.WriteLine("Run DirectoryCleaner help to get info about available commands.");
            return false;
        }

        int countOfArguments = args.Length - 1;
        if (!command.NumberOfArguments.Contains(countOfArguments))
        {
            Console.WriteLine(
                $"Wrong number of arguments provided. Command {command.CommandName} requires {command.NumberOfArguments} args");
            return false;
        }
        return command.Execute(args[1..], _settings);
    }

    public CommandsList AddCommand(Command command)
    {
        _commands.Add(command);
        return this;
    } 
}