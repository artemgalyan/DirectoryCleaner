using Models;

namespace DirectoryCleaner;

public abstract class Command
{
    public abstract bool Execute(string[] args, Settings settings);
    public abstract Range NumberOfArguments { get; }
    public abstract string CommandName { get; }
    public abstract string[] ArgumentsNames { get; }

    public override string ToString()
    {
        var @params = string.Join(" ", ArgumentsNames);
        if (@params.Length == 0)
        {
            @params = "no arguments";
        }
        return $"command: {CommandName}, number of arguments: {NumberOfArguments.ToNormalizedString()}, arguments: {@params}";
    }
}