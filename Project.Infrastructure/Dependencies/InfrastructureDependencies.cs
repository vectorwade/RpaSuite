using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Interfaces;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(cfg.GetConnectionString("Default")));
        services.AddScoped<IProcessoRepository, ProcessoRepository>();
        return services;
    }
}
