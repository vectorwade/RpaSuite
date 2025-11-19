using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RpaSuite.Infrastructure.Scheduling.Hangfire;

public static class HangfireConfig
{
    public static IServiceCollection AddHangfireSetup(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddHangfire(config => config
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(cfg.GetConnectionString("SqlServerLogs")!, new SqlServerStorageOptions
            {
                PrepareSchemaIfNecessary = true,
                QueuePollInterval = TimeSpan.FromSeconds(15)
            }));

        services.AddHangfireServer();
        return services;
    }

    public static void ScheduleRecurringJobs()
    {
        RecurringJob.AddOrUpdate<RpaJob>("rpa-execucao", job => job.ExecutarAsync(), Cron.Minutely);
    }
}
