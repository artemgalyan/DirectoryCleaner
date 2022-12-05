using Common;

namespace DirectoryCleaner;

public class UpdateGlobalPropertyCommand : Command
{
    public override bool Execute(string[] args, Settings settings)
    {
        if (!NumberOfArguments.Contains(args.Length))
        {
            throw new ArgumentException(nameof(args.Length));
        }
        
        if (!TimeSpan.TryParse(args[1], out var value))
        {
            Console.WriteLine($"Failed to parse ${args[1]}, make sure it matches type of {args[0]}");
            return false;
        }

        if (args[0] == nameof(settings.DeleteInterval))
        {
            settings.DeleteInterval = value;
            return true;
        }
        if (args[0] == nameof(settings.GlobalMaxLifeTime))
        {
            settings.GlobalMaxLifeTime = value;
            return true;
        }

        Console.WriteLine($"Non-existent field {args[0]}");
        return false;
    }

    public override Range NumberOfArguments { get; } = 2..2;
    public override string CommandName => "update-global";

    public override string[] ArgumentsNames => new[]
    { $"[{nameof(Settings.DeleteInterval)}|{nameof(Settings.GlobalMaxLifeTime)}]", "[value]" };
}