using Common;

namespace DirectoryCleaner;

public class PrintDirectoriesCommand : Command
{
    public override bool Execute(string[] args, Settings settings)
    {
        if (settings.DirectorySettingsList.Count == 0)
        {
            Console.Write("There are no tracking directories");
            return true;
        }

        foreach (var dir in settings.DirectorySettingsList)
        {
            Console.WriteLine($"> {dir}");
        }

        return true;
    }

    public override Range NumberOfArguments => 0..0;
    public override string CommandName => "print-directories";
    public override string[] ArgumentsNames => Array.Empty<string>();
}