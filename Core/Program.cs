var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/https", async context =>
{
        await context.Response.WriteAsync($"HTTPS Request: {context.Request.IsHttps}");
});

app.MapGet("/", () => "Hello World!");

app.Run();