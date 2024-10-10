using AMP.EMS.API.Infrastructure;
using AMP.Infrastructure.Middlewares;
using AMP.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AMP.Infrastructure.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.HttpLogging;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add(HeaderNames.ContentType);
    logging.RequestHeaders.Add(HeaderNames.ContentDisposition);
    logging.RequestHeaders.Add(HeaderNames.ContentEncoding);
    logging.RequestHeaders.Add(HeaderNames.ContentLength);

    logging.MediaTypeOptions.AddText("application/json");
    logging.MediaTypeOptions.AddText("multipart/form-data");

    logging.RequestBodyLogLimit = 1024;
    logging.ResponseBodyLogLimit = 1024;
});

builder.Host.ConfigureLogger();

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var authority = config.GetValue<string>("Authority")!;
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OpenIdConnect,
        OpenIdConnectUrl = new Uri($"{authority}.well-known/openid-configuration")
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Add authentication
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = config.GetValue<string>("Authority");
        options.TokenValidationParameters.ValidateAudience = false;
    });

//Add DbContext
builder.Services.AddDbContext<EMSDbContext>(options => options.UseSqlite(config.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DbContext, EMSDbContext>();

//Add Unit of Work with Decorator
builder.Services.ConfigureUnitOfWork<EFUnitOfWork>();

//Add Repositories
builder.Services.AddScoped(typeof(EFRepository<>));

builder.Host.ConfigureLogger();

var app = builder.Build();

app.UseRequestLogging();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EMSDbContext>();
    if (dataContext.Database.GetPendingMigrations().Any())
        dataContext.Database.Migrate();
}

//Add Middleware
app.UseMiddleware<RequestPipelineMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();