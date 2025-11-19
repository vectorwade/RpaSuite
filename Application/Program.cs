var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

// ConnectionStrings em appsettings.json
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// pipeline MVC
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
