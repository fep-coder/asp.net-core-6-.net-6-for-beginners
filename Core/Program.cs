using Core;

var builder = WebApplication.CreateBuilder(args);

var servicesConfig = builder.Configuration;
builder.Services.Configure<FruitOptions>(servicesConfig.GetSection("Fruit"));

var app = builder.Build();

app.MapGet("/config", async (HttpContext context, IConfiguration config) =>
{
        string defaultDebug = config["Logging:LogLevel:Default"];
        await context.Response.WriteAsync(defaultDebug);
});

app.UseMiddleware<FruitMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();