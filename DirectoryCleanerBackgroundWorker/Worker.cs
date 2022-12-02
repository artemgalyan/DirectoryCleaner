using Models;

namespace DirectoryCleanerBackgroundWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var settings = Settings.LoadFromFile(Constants.SettingsFile);
            if (settings is null)
            {
                Console.WriteLine($"{Constants.SettingsFile} doesn't exits");
                await StopAsync(stoppingToken);
                return;
            }

            foreach (var directory in settings.DirectorySettingsList)
            {
                var maxLifeTime = directory.MaxFileLifeTime ?? settings.GlobalMaxLifeTime;
                DeleteOldFiles(directory.Directory, maxLifeTime, directory.CleanSubdirs);
            }

            int delayTime = settings.DeleteInterval.Milliseconds;
            await Task.Delay(millisecondsDelay: delayTime, stoppingToken);
        }
    }

    private void DeleteOldFiles(string dir, TimeSpan maxLifeTime, bool clearSubDirs)
    {
        if (!Directory.Exists(dir))
        {
            Console.WriteLine($"{dir} doesn't exist");
            return;
        }

        if (clearSubDirs)
        {
            var subdirs = Directory.GetDirectories(dir);
            foreach (var subdir in subdirs)
            {
                DeleteOldFiles(subdir, maxLifeTime, clearSubDirs);
            }
        }

        var files = Directory.GetFiles(dir);
        foreach (var file in files)
        {
            DeleteIfOld(file, maxLifeTime);
        }
    }

    private static void DeleteIfOld(string path, TimeSpan maxLifeTime)
    {
        if (!File.Exists(path))
        {
            return;
        }

        var lastWriteTime = File.GetLastWriteTime(path);
        var lifeTime = DateTime.Now - lastWriteTime;
        if (lifeTime <= maxLifeTime) return;
        try
        {
            File.Delete(path);
        }
        catch (Exception)
        {
            Console.WriteLine($"Failed to delete {path} file");
        }
    }
}