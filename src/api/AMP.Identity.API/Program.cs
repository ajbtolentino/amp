using AMP.Identity.API;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddCors();

var app = builder
.ConfigureServices()
.ConfigurePipeline();

app.UseIdentityServer();

app.Run();
