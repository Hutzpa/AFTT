using AFTT.Common.MappingProfiles;
using AFTT.Core.Abstractions;
using AFTT.Core.Extensions;
using AFTT.Core.Implementations;
using AFTT.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IMissionsService, MissionsService>();

builder.Services.AddAutoMapper(typeof(MissionsMappingProfile).Assembly);

builder.AddRabbitMq();

builder.Services.AddDbContext<MissionContext>(options =>
{
    //will be moved to configuration later
    options.UseSqlServer("Server=DESKTOP-F1IL65P\\SQLEXPRESS;Database=AFTT;Trusted_Connection=True;TrustServerCertificate=True;",
        b => b.MigrationsAssembly("AFTT.Core"));
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "AFTT.Core is alive");

app.Run();