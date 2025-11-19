using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RpaSuite.Infrastructure.Scheduling.Hangfire;
using RpaSuite.Application.Interfaces;
using RpaSuite.Application.Services;
using RpaSuite.Presentation.Wpf.Views;
using RpaSuite.Presentation.Wpf.ViewModels;

namespace RpaSuite.Presentation.Wpf.Bootstrap;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(cfg =>
            {
                cfg.AddJsonFile("Config/appsettings.json", optional: false);
            })
            .ConfigureServices((ctx, services) =>
            {
                services.AddHangfireSetup(ctx.Configuration);
                services.AddScoped<IRpaOrquestrador, RpaOrquestrador>();
                services.AddScoped<RpaJob>();
                services.AddScoped<DashboardViewModel>();
            });

        var host = builder.Build();

        HangfireConfig.ScheduleRecurringJobs();

        using (host)
        {
            host.Start();

            var app = new System.Windows.Application();
            var view = new DashboardView
            {
                DataContext = host.Services.GetRequiredService<DashboardViewModel>()
            };
            app.Run(view);
        }
    }
}
