using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers.Missions;

internal class GetAllActiveUserMissionsConsumer(IMissionsService missionsService) : IConsumer<MissionsGetBllRequest>
{
    public async Task Consume(ConsumeContext<MissionsGetBllRequest> context)
    {
        MissionsGetResponse response = await missionsService.GetAsync(context.Message);

        await context.RespondAsync(response);
    }
}