using AMP.Core.Repository;
using AMP.EMS.API.Entities;
using AMP.EMS.API.Infrastructure;
using AMP.Infrastructure.Decorators;
using AMP.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            ClientCredentials = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "openid" },
                    { "profile", "profile" },
                    { "scope1", "scope1" },
                    { "scope2", "scope2" }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

//Add authentication
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidateAudience = false;
    });

//Add DbContext
builder.Services.AddDbContext<EMSDbContext>(options => options.UseSqlite("Data Source=ems.db"));
builder.Services.AddScoped<DbContext, EMSDbContext>();

//Add Unit of Work with Decorator
builder.Services.AddScoped<EFUnitOfWork>();
builder.Services.AddScoped<IUnitOfWork>(provider =>
{
    var unitOfWork = provider.GetRequiredService<EFUnitOfWork>();
    var logger = provider.GetRequiredService<ILogger<UnitOfWorkDecorator>>();

    return new UnitOfWorkDecorator(unitOfWork, logger);
});

//Add Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

var app = builder.Build();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EMSDbContext>();
    dataContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();