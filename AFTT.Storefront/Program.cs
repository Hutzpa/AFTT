using AFTT.Common.MappingProfiles;
using AFTT.Storefront.Abstractions;
using AFTT.Storefront.Extension;
using AFTT.Storefront.Implementations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);

builder.Services.AddScoped<IMissionsService, MissionsService>();

builder.Services.AddAutoMapper(typeof(MissionsMappingProfile).Assembly);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

builder.Services.AddControllers();

builder.AddRabbitMq();

//FluentValidation

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();//New Swagger
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "AFTT.Storefront is alive");

app.Run();