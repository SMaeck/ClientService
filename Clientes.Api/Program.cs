using Microsoft.EntityFrameworkCore;
using Clientes.Infrastructure;
using Clientes.Infrastructure.Repositories;
using Clientes.Api.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexto de base de datos
builder.Services.AddDbContext<ClienteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Serilog
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
                                      .Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Repositorios
builder.Services.AddScoped<ClientesRepository>();

// Servicios
builder.Services.AddScoped<ClientesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
