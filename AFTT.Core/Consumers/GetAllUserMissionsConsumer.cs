using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers;

internal class GetAllUserMissionsConsumer(IMissionsService missionsService) : IConsumer<GetUserMissionsBllRequest>
{
    public async Task Consume(ConsumeContext<GetUserMissionsBllRequest> context)
    {
        GetUserMissionsResponse response = await missionsService.GetAllAsync(context.Message);

        await context.RespondAsync(response);
    }
}