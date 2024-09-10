using AMP.Core.DbContext;
using AMP.EMS.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EFDbContext>(options => options.UseSqlite("Data Source=ems.db"));
builder.Services.AddScoped<IApplicationDbContext>((a) => a.GetService<EFDbContext>());

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<EFDbContext>();
    dataContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();