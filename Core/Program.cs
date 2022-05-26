using Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", branch =>
{
        branch.Run(new Middleware().Invoke);
});

app.UseMiddleware<Middleware>();

app.MapGet("/", () => "Hello World!");

app.Run();