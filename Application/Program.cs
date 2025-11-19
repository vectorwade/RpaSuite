using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Dependencies;
using RpaSuite.Infrastructure.Scheduling.Hangfire;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

// ConnectionStrings em appsettings.json
builder.AddInfrastructure();
builder.Services.AddHangfireSetup(builder.Configuration);

var app = builder.Build();

// schedule recurring jobs (register via IRecurringJobManager from DI)
var recurringManager = app.Services.GetRequiredService<Hangfire.IRecurringJobManager>();
HangfireConfig.ScheduleRecurringJobs(recurringManager);

// pipeline MVC
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Hangfire dashboard (restricted to local requests) — only allow local IPs to access
app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/hangfire") && (ctx.Connection.RemoteIpAddress != null && System.Net.IPAddress.IsLoopback(ctx.Connection.RemoteIpAddress)), branch =>
{
	branch.UseHangfireDashboard();
});

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
