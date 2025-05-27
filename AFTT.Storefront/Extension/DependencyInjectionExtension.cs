using AFTT.Common.Bus;
using AFTT.Common.Models.Request.Bll.Missions;
using MassTransit;

namespace AFTT.Storefront.Extension;

internal static class DependencyInjectionExtension
{
    internal static void AddRabbitMq(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(builder.Configuration["RabbitMQ:Host"], h =>
                {
                    h.Username(builder.Configuration["RabbitMQ:Username"]);
                    h.Password(builder.Configuration["RabbitMQ:Password"]);
                });
            });

            bus.AddRequestClient<GetUserMissionsBllRequest>(new Uri($"queue:{MissionsQueue.GetUserMissions}"), TimeSpan.FromSeconds(60));
        });
    }
}
