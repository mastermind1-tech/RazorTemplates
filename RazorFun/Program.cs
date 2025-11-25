using Microsoft.AspNetCore.Components;
using RazorFun;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();

var app = builder.Build();

app.MapGet("/", () => Results.Razor(Templates.Home()));

app.MapGet("/string", async (IServiceProvider services, string name = "World") =>
{
    var user = new User { Name = name, Age = 32 };
    return await Templates.Card(user).RenderAsync(services);
});

app.MapGet("/iresult", (string name = "World") =>
{
    var user = new User { Name = name, Age = 32 };
    return Results.Razor(Templates.Card(user));
});

app.Run();
