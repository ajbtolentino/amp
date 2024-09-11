using AMP.Core.Repository;
using AMP.EMS.API.Entities;
using AMP.EMS.API.Infrastructure;
using AMP.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EMSDbContext>(options => options.UseSqlite("Data Source=ems.db"));

builder.Services.AddScoped<IRepository<EMSDbContext, Event>, Repository<EMSDbContext, Event>>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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