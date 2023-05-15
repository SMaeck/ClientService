using Microsoft.EntityFrameworkCore;
using Serilog;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddDbContext<CursoMicroContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CursoMicroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Serilog
var logger = new LoggerConfiguration()
 .ReadFrom.Configuration(builder.Configuration)
 .Enrich.FromLogContext()
 .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Repositorios
builder.Services.AddScoped<TransferenciaRepository>();

// Servicios
builder.Services.AddScoped<TransferenciaService>();

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
