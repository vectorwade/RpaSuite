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

        // Register Selenium runner
        services.AddScoped<RpaSuite.Infrastructure.Automation.Selenium.ISeleniumRunner, RpaSuite.Infrastructure.Automation.Selenium.SeleniumRunner>();

        // Register orchestrator implementation
        services.AddScoped<IAutomationOrchestrator, Project.Infrastructure.Automation.AutomationOrchestrator>();

        // Auto-register all IAutomation implementations found in loaded assemblies
        var automationInterface = typeof(RpaSuite.Common.Automations.IAutomation);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var asm in assemblies)
        {
            Type[] types;
            try { types = asm.GetTypes(); } catch { continue; }
            foreach (var t in types.Where(t => automationInterface.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract))
            {
                services.AddScoped(typeof(RpaSuite.Common.Automations.IAutomation), t);
            }
        }

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
