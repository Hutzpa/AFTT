using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers.Missions;

internal class UpdateMissionConsumer(IMissionsService missionsService) : IConsumer<MissionUpdateBllRequest>
{
    public async Task Consume(ConsumeContext<MissionUpdateBllRequest> context)
    {
        MissionUpdateResponse response = await missionsService.UpdateAsync(context.Message);

        await context.RespondAsync(response);
    }
}