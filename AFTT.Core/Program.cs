using AFTT.Core.Abstractions;
using AFTT.Core.Extensions;
using AFTT.Core.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IMissionsService, MissionsService>();

//Add redis 
//Mappings 
builder.AddRabbitMq();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "AFTT.Core is alive");

app.Run();
