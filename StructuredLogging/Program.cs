using LoggingDemo.Repositories;
using LoggingWebApi;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<BookContext>(options =>
{
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});
builder.Services.AddScoped<IBookRepository, BookRepository>();


builder.Host.UseSerilog((context,services, configuration)=>
{
    configuration.ReadFrom.Configuration(context.Configuration);
    configuration.ReadFrom.Services(services);

    configuration.WriteTo.Async(a =>
    {
        a.Console();
        a.File("logs/MyAppLog-.txt", rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 30);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
