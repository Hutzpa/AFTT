using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using MassTransit;

namespace AFTT.Core.Consumers.Missions;

internal class GetAllFutureUserMissionsConsumer(IMissionsService missionsService) : IConsumer<FutureMissionsGetBllRequest>
{
    public async Task Consume(ConsumeContext<FutureMissionsGetBllRequest> context)
    {
        MissionsGetResponse response = await missionsService.GetFutureAsync(context.Message);

        await context.RespondAsync(response);
    }
}