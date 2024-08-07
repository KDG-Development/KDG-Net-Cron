using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Hangfire;
using Hangfire.PostgreSql;
using KDG.Cron.Interfaces;

namespace KDG.Cron;

public class CronService {
    public class PostgreSql:IServiceConfiguration {
        public void ConfigureServices(IServiceCollection services, string connection)
        {
            services
                .AddHangfire(configuration => {
                    configuration.UsePostgreSqlStorage(x => {
                        x.UseNpgsqlConnection(connection);
                    });
                })
                .AddHangfireServer();
        }
    }

    public static void InitializeCronServer(WebApplication app,string? cronURL, DashboardOptions? configureDashboard)
    {
        app.UseHangfireDashboard(cronURL ?? "/cron", configureDashboard);
    }
    
}
