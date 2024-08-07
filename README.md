# Getting started

>Important! - Ensure your application is always running, otherwise your jobs wont execute as expected. 

1. Configure the CRON service prior to building the application
```
var pgCronService = new KDG.Cron.CronService.PostgreSql();

pgCronService.ConfigureServices(serviceCollection, "postgres-connection-string");
```
2. initialize the cron server and dashboard after building the application

```
KDG.Cron.CronService.InitializeCronServer(webApp, "/optional-cron-job-url", optionalConfiguration);
```

3. Initialize the cron scheduler and start scheduling jobs

```
var cronScheduler = new KDG.Cron.CronScheduler();

cronScheduler.ScheduleRecurringJob(
  "unique-job-identifier",
  () => Console.WriteLine("Hello World!"),
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
