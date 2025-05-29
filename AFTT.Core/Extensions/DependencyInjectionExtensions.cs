using AFTT.Common.Bus;
using AFTT.Core.Consumers;
using MassTransit;

namespace AFTT.Core.Extensions;

internal static class DependencyInjectionExtensions
{
    internal static void AddRabbitMq(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.AddConsumer<GetAllUserMissionsConsumer>().Endpoint(e => e.Name = MissionsQueue.GetUserMissions);

            bus.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);


                bus.AddLogging(log =>
                {
                    log.AddConsole(); // Якщо потрібно, додай логгер
                });
            });
        });
    }
}
