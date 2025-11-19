using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Interfaces;
using Project.Infrastructure.Context;
using Project.Infrastructure.Repositories;
using RpaSuite.Common.Automations;
using Project.Infrastructure.Automation.Implementations;
using Project.Infrastructure.Automation;

namespace Project.Infrastructure.Dependencies;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(cfg.GetConnectionString("Default")));
        services.AddScoped<IProcessoRepository, ProcessoRepository>();
        // Register automations and orchestrator
        services.AddScoped<IAutomation, Project.Infrastructure.Automation.Implementations.SampleAutomation>();
        services.AddScoped<IAutomationOrchestrator, Project.Infrastructure.Automation.AutomationOrchestrator>();
        return services;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
        return builder;
    }
}
