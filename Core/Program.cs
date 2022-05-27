var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/config", async (HttpContext context, IConfiguration config) =>
{
        string defaultDebug = config["Logging:LogLevel:Default"];
        await context.Response.WriteAsync(defaultDebug);
});

app.MapGet("/", () => "Hello World!");

app.Run();