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
                cfg.Host("localhost", 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

            });

            bus.AddRequestClient<GetUserMissionsBllRequest>(new Uri($"queue:{MissionsQueue.GetUserMissions}"), TimeSpan.FromSeconds(60));
        });
    }
}
