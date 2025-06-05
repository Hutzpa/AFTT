using AFTT.Common.Bus;
using AFTT.Common.DataProviders.Abstractions;
using AFTT.Common.DataProviders.Implementations.Ef;
using AFTT.Core.Abstractions;
using AFTT.Core.Consumers.Missions;
using AFTT.Core.DataProviders.Abstractions;
using AFTT.Core.DataProviders.Implementations.Ef;
using AFTT.Core.Implementations;
using MassTransit;

namespace AFTT.Core.Extensions;

internal static class DependencyInjectionExtensions
{
    internal static void AddDataProviders(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMissionsDataProvider, MissionsEfDataProvider>();
        builder.Services.AddScoped<IUserDataProvider, UserDataProvider>();
    }

    internal static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMissionsService, MissionsService>();
    }

    internal static void AddRabbitMq(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(bus =>
        {
            bus.AddConsumer<GetAllActiveUserMissionsConsumer>().Endpoint(e => e.Name = MissionsQueue.GetActiveMissions);
            bus.AddConsumer<GetAllFutureUserMissionsConsumer>().Endpoint(e => e.Name = MissionsQueue.GetFutureMissions);
            bus.AddConsumer<UpdateMissionConsumer>().Endpoint(e => e.Name = MissionsQueue.UpdateMission);
            bus.AddConsumer<CreateMissionConsumer>().Endpoint(e => e.Name = MissionsQueue.CreateMission);

            bus.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}