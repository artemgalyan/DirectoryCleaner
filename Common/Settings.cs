using System.Text.Json;

namespace Common;

public class Settings
{
    public TimeSpan DeleteInterval { get; set; } = TimeSpan.FromHours(1);
    public TimeSpan GlobalMaxLifeTime { get; set; } = TimeSpan.FromDays(7);
    public List<DirectorySettings> DirectorySettingsList { get; set; } = new();

    public static Settings? LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"File {path} doesn't exist");
            return null;
        }

        using FileStream jsonStream = File.Open(path, FileMode.Open);
        try
        {
            return JsonSerializer.Deserialize<Settings>(jsonStream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public override string ToString()
    {
        return
            $"{nameof(DeleteInterval)}: {DeleteInterval}, {nameof(GlobalMaxLifeTime)}: {GlobalMaxLifeTime}, dirs count: {DirectorySettingsList.Count}";
    }
}