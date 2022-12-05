using Common;

namespace DirectoryCleaner;

public class StopTrackingAllDirs : Command
{
    public override bool Execute(string[] args, Settings settings)
    {
        settings.DirectorySettingsList.Clear();
        return true;
    }

    public override Range NumberOfArguments { get; } = 0..0;
    public override string CommandName => "stop-tracking-all";
    public override string[] ArgumentsNames => Array.Empty<string>();
}