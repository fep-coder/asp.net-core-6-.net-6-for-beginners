using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(options =>
{
        options.Name = "watermelon";
});

var app = builder.Build();

//app.MapGet("/fruit", async (HttpContext context, IOptions<FruitOptions> FruitOptions) =>
//{
//        FruitOptions options = FruitOptions.Value;
//        await context.Response.WriteAsync($"{options.Name}, {options.Color}");
//});

app.UseMiddleware<FruitMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();