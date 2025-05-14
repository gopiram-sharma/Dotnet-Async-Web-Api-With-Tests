using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation.AspNetCore;
using ModernDotNetApi.Application.Services;
using ModernDotNetApi.Infrastructure.Data;
using ModernDotNetApi.Infrastructure.Repositories;
using ModernDotNetApi.Domain.Interfaces;
using ModernDotNetApi.Application.Mapping;
using ModernDotNetApi.Application.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// --- Serilog Configuration ---
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

// --- Add Services to the Container ---

// Add EF Core (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository Pattern
builder.Services.AddScoped<IApiEntryRepository, ApiEntryRepository>();

// Services Layer
builder.Services.AddScoped<IApiEntryService, ApiEntryService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// FluentValidation
builder.Services
    .AddFluentValidationAutoValidation()       // Enable auto-validation
    .AddFluentValidationClientsideAdapters()   // Enable client-side validation adapters (optional)
    .AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<ApiEntryDtoValidator>();

// Health Checks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- Configure the HTTP Request Pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
