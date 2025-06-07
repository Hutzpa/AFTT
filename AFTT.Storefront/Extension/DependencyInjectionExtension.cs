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

            bus.AddRequestClient<MissionsGetBllRequest>(new Uri($"queue:{MissionsQueue.GetMissions}"), TimeSpan.FromSeconds(60));
            bus.AddRequestClient<MissionCreateBllRequest>(new Uri($"queue:{MissionsQueue.CreateMission}"), TimeSpan.FromSeconds(60));
            bus.AddRequestClient<MissionUpdateBllRequest>(new Uri($"queue:{MissionsQueue.UpdateMission}"), TimeSpan.FromSeconds(60));
        });
    }
}
