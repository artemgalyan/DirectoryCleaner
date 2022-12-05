using System.Diagnostics;

namespace DirectoryCleanerBackgroundWorkerStartupService;

public class Worker : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var startupInfo = new ProcessStartInfo
        { 
            FileName = Path.Combine(AppContext.BaseDirectory, "DirectoryCleanerBackgroundWorker.exe"), 
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true 
        };
        try
        {
            Process.Start(startupInfo);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Failed to start the application");
        }
        return Task.CompletedTask;
    }
}