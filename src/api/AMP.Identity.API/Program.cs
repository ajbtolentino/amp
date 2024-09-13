
using AMP.Identity.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddIdentityServer()
        .AddInMemoryApiScopes(Config.ApiScopes)
        .AddInMemoryClients(Config.Clients);

var app = builder.Build();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapGet("/", () => "Hello World!");

app.UseIdentityServer();

app.Run();
