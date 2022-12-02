namespace Models;

public class DirectorySettings
{
    public string Directory { get; set; }
    public TimeSpan? MaxFileLifeTime { get; set; }
    public bool CleanSubdirs { get; set; } = false;
}