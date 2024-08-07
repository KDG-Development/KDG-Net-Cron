using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace KDG.Cron.Interfaces;

public interface IServiceConfiguration {
    public void ConfigureServices(IServiceCollection services, string databaseConnectionString);
}