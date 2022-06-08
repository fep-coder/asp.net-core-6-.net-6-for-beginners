using Core.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});

builder.Services.AddDbContext<IdentityContext>(options =>
{
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllers();

app.MapDefaultControllerRoute();

app.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Users}/{action=Index}/{id?}"
);

app.UseStaticFiles();

app.UseAuthorization();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.Run();