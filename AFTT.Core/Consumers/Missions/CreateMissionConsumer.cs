using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers.Missions;

internal class CreateMissionConsumer(IMissionsService missionsService) : IConsumer<MissionCreateBllRequest>
{
    public async Task Consume(ConsumeContext<MissionCreateBllRequest> context)
    {
        MissionCreateResponse response = await missionsService.CreateAsync(context.Message);

        await context.RespondAsync(response);
    }
}