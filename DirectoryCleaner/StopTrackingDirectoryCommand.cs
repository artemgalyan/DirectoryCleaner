using Common;

namespace DirectoryCleaner;

public class StopTrackingDirectoryCommand : Command
{
    public override bool Execute(string[] args, Settings settings)
    {
        if (!NumberOfArguments.Contains(args.Length))
        {
            throw new ArgumentException(nameof(args.Length));
        }

        var result = false;
        foreach (var directory in args)
        {
            var dir = settings.DirectorySettingsList.FirstOrDefault(d => d.Directory == directory);
            result |= dir is not null && settings.DirectorySettingsList.Remove(dir);
        }

        return result;
    }

    public override Range NumberOfArguments { get; } = 1..int.MaxValue;
    public override string CommandName => "stop-tracking";
    public override string[] ArgumentsNames => new[] { "[dirs...]" };
}