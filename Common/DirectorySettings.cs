namespace Common;

public class DirectorySettings
{
    public string Directory { get; set; }
    public TimeSpan? MaxFileLifeTime { get; set; }
    public bool CleanSubdirs { get; set; } = false;

    public override string ToString()
    {
        return $"{nameof(Directory)}: {Directory}, {nameof(MaxFileLifeTime)}: {MaxFileLifeTime}, {nameof(CleanSubdirs)}: {CleanSubdirs}";
    }
}