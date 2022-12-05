using System.Text.Json;
using Common;

namespace DirectoryCleaner;

public static class Program
{
    public static void Main(string[] args)
    {
        var settings = Settings.LoadFromFile(Constants.SettingsFile) ?? new Settings();
        if (args.Length == 0)
        {
            Console.WriteLine("Run DirectoryCleaner help for help");
            return;
        }
        var list = new CommandsList(settings)
                   .AddCommand(new AddDirectoryCommand())
                   .AddCommand(new StopTrackingDirectoryCommand())
                   .AddCommand(new StopTrackingAllDirs())
                   .AddCommand(new UpdateGlobalPropertyCommand())
                   .AddCommand(new PrintDirectoriesCommand());
        
        if (list.Execute(args))
        {
            Console.WriteLine($"Current settings file contains following info: {settings}");
            Save(settings, Constants.SettingsFile);
        }
    }

    private static void Save(Settings settings, string filepath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        using StreamWriter writer = File.CreateText(filepath);
        string jsonString = JsonSerializer.Serialize(settings, options);
        writer.Write(jsonString);
    }
}