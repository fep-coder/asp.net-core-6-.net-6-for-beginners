using Core;
using Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IResponseFormatter, GuidService>();

var app = builder.Build();

//IResponseFormatter formatter = new TextResponseFormatter();

app.MapGet("/formatter1", async (HttpContext context, IResponseFormatter formatter) =>
{
        await formatter.Format(context, "Formatter 1");
});

app.MapGet("/formatter2", async (HttpContext context, IResponseFormatter formatter) =>
{
        await formatter.Format(context, "Formatter 2");
});

app.UseMiddleware<CustomMiddleware>();
//app.UseMiddleware<CustomMiddleware2>();

app.MapGet("/endpoint", CustomEndpoint.Endpoint);

app.MapGet("/", () => "Hello World!");

app.Run();