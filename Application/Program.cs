using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Dependencies;
using RpaSuite.Infrastructure.Scheduling.Hangfire;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

// ConnectionStrings em appsettings.json
builder.AddInfrastructure();
builder.Services.AddHangfireSetup(builder.Configuration);

var app = builder.Build();

// schedule recurring jobs (uses Hangfire recurring jobs registered in Project.Infrastructure)
HangfireConfig.ScheduleRecurringJobs();

// pipeline MVC
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
