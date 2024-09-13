
using AMP.Identity.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.Clients);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseIdentityServer();

app.Run();
