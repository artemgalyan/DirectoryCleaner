using DirectoryCleanerBackgroundWorker;

IHost host = Host.CreateDefaultBuilder(args)    
                 .ConfigureServices(services => { services.AddHostedService<Worker>(); })
                 .Build();

host.StartAsync();
// host.Run();