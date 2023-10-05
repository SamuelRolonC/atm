using Core;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<Core.Interfaces.Repositories.ICardRepository, CardRepository>();
builder.Services.AddTransient<IOperationRepository, OperationRepository>();
builder.Services.AddTransient<IOperationTypeRepository, OperationTypeRepository>();

builder.Services.AddScoped<Core.Interfaces.Services.ICardService, CardService>();
builder.Services.AddScoped<IOperationService, OperationService>();

builder.Services.AddCors(o => o.AddPolicy("NoCors", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddDbContext<AtmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemParameters.ConnectionString.AtmContext)));

var app = builder.Build();

app.UseCors("NoCors");

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
