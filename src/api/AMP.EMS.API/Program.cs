using System.Text.Json.Serialization;
using AMP.EMS.API.Infrastructure;
using AMP.Infrastructure.Extensions;
using AMP.Infrastructure.Middlewares;
using AMP.Infrastructure.Repository;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

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
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

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
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
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
builder.Services.AddDbContext<EmsDbContext>(config, "AMP.EMS.API.Migrations");

builder.Services.AddHttpContextAccessor();

//Add Unit of Work with Decorator
builder.Services.ConfigureUnitOfWork<EFUnitOfWork>();

//Add Repositories
builder.Services.AddScoped(typeof(EFRepository<>));

builder.Host.ConfigureLogger();

var app = builder.Build();

var migrate = args.Any(x => x == "/migrate");
if (migrate) app.Services.Migrate<EmsDbContext>(config);

var seed = args.Any(x => x == "/seed");
if (seed)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<EmsDbContext>();
    var seedData = new SeedData(context);
    seedData.Seed();
}

if (seed || migrate) return;

app.UseRequestLogging();

app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

//Add Middleware
app.UseMiddleware<RequestPipelineMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();