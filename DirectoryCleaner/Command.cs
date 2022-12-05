using Common;

namespace DirectoryCleaner;

public abstract class Command
{
    public abstract bool Execute(string[] args, Settings settings);
    public abstract Range NumberOfArguments { get; }
    public abstract string CommandName { get; }
    public abstract string[] ArgumentsNames { get; }
}