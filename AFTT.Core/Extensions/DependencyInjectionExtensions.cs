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
                cfg.Host(builder.Configuration["RabbitMQ:Host"], h =>
                {
                    h.Username(builder.Configuration["RabbitMQ:Username"]);
                    h.Password(builder.Configuration["RabbitMQ:Password"]);
                });
            });
        });
    }

}
