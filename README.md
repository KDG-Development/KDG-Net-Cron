# Getting started

> **Important:** Ensure your application is always running, otherwise your jobs wont execute as expected. 

1. Configure the CRON service prior to building the application
```csharp
var pgCronService = new KDG.Cron.CronService.PostgreSql();

pgCronService.ConfigureServices(serviceCollection, "postgres-connection-string");
```csharp
2. initialize the cron server and dashboard after building the application

```csharp
KDG.Cron.CronService.InitializeCronServer(webApp, "/optional-cron-job-url", optionalConfiguration);
```

3. Initialize the cron scheduler and start scheduling jobs

```csharp

var cronScheduler = new KDG.Cron.CronScheduler();

// initialize an ICronJob class
public class HelloWorldJob : KDG.Cron.ICronJob {
  public async Task Execute(){
    Console.WriteLine("Hello World!");
    await Task.CompletedTask;
  }
}

// register the new HelloWorldJob class to the service provider
services.AddSingleton<HelloWorldJob>();

// register the recurring job
cronScheduler.ScheduleRecurringJob(
  "unique-job-identifier",
  app.Services.GetRequiredService<HelloWorldJob>(),
  Hangfire.Cron.Minutely
);

```

## Support

For support, please open an issue on our [GitHub Issues page](https://github.com/KDG-Development/KDG-Net-Cron/issues) and provide your questions or feedback. We strive to address all inquiries promptly.

## Contributing

To contribute to this project, please follow these steps:

1. Fork the repository to your own GitHub account.
2. Make your changes and commit them to your fork.
3. Submit a pull request to the original repository with a clear description of what your changes do and why they should be included.
