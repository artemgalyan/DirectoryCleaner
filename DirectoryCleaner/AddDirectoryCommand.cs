using Models;

namespace DirectoryCleaner;

public class AddDirectoryCommand : Command
{
    public override bool Execute(string[] args, Settings settings)
    {
        if (!NumberOfArguments.Contains(args.Length))
        {
            throw new ArgumentException(nameof(args.Length));
        }
        var (dirName, maxLifeTime, cleanSubdirs) = ParseArgs(args);
        var info = new DirectorySettings();

        if (!bool.TryParse(cleanSubdirs, out var cleanSubdirsValue))
        {
            Console.WriteLine("Failed to parse --clean-subdirs parameter");
            return false;
        }

        info.CleanSubdirs = cleanSubdirsValue;
        if (string.IsNullOrEmpty(dirName))
        {
            Console.WriteLine("Failed to parse --dir parameter");
            return false;
        }

        if (!Directory.Exists(dirName))
        {
            Console.WriteLine($"{dirName} doesn't exist");
            return false;
        }

        info.Directory = dirName;
        
        if (maxLifeTime == "global")
        {
            settings.DirectorySettingsList.Add(info);
            return true;
        }

        if (!TimeSpan.TryParse(maxLifeTime, out var ts))
        {
            Console.WriteLine($"Failed to parse --lifetime parameter");
            return false;
        }

        info.MaxFileLifeTime = ts;
        settings.DirectorySettingsList.Add(info);
        return true;
    }

    private (string dirName, string maxLifeTime, string cleanSubdirs) ParseArgs(string[] args)
    {
        string dirName = string.Empty, maxLifeTime = string.Empty, cleanSubdirs = string.Empty;
        for (int i = 0; i < args.Length; ++i)
        {
            switch (args[i])
            {
                case "--dir":
                {
                    dirName = args[++i];
                    break;
                }
                case "--lifetime":
                {
                    maxLifeTime = args[++i];
                    break;
                }
                case "--clean-subdirs":
                {
                    cleanSubdirs = args[++i];
                    break;
                }
            }
        }

        return (dirName, maxLifeTime, cleanSubdirs);
    }

    public override Range NumberOfArguments { get; } = 6..6;
    public override string CommandName => "add";

    public override string[] ArgumentsNames => new[]
    { "--dir", "[path]", "--lifetime", "[max-lifetime]", "--clean-subdirs", "[true, false]" };
}