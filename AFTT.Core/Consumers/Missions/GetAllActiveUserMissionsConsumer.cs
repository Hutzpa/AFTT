using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers.Missions;

internal class GetAllActiveUserMissionsConsumer(IMissionsService missionsService) : IConsumer<ActiveMissionsGetBllRequest>
{
    public async Task Consume(ConsumeContext<ActiveMissionsGetBllRequest> context)
    {
        MissionsGetResponse response = await missionsService.GetActiveAsync(context.Message);

        await context.RespondAsync(response);
    }
}