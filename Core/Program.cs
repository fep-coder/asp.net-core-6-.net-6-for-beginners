var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHsts(options =>
{
        options.MaxAge = TimeSpan.FromDays(1);
        options.IncludeSubDomains = true;
});

var app = builder.Build();

app.MapGet("/https", async context =>
{
        await context.Response.WriteAsync($"HTTPS Request: {context.Request.IsHttps}");
});

app.UseHttpsRedirection();

if (app.Environment.IsProduction())
{
        app.UseHsts();
}

app.MapGet("/", () => "Hello World!");

app.Run();