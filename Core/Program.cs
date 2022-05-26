using Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
        if (context.Request.Path == "/short")
        {
                await context.Response.WriteAsync("Request short-circuited");
        }
        else
        {
                await next();
        }
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");

app.Run();