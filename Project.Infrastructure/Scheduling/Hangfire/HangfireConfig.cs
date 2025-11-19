using Hangfire;
using Hangfire.Common;
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

    public static void ScheduleRecurringJobs(IRecurringJobManager recurringJobManager)
    {
        // Use service-based API to schedule recurring jobs so JobStorage.Current is not required.
        var job = Job.FromExpression<RpaJob>(j => j.ExecutarAsync());
        recurringJobManager.AddOrUpdate("rpa-execucao", job, Cron.Minutely(), new RecurringJobOptions());
    }
}
