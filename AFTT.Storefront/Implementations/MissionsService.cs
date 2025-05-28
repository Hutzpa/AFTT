using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using AutoMapper;
using MassTransit;

namespace AFTT.Storefront.Implementations;

internal class MissionsService(
    IMapper mapper,
    IRequestClient<GetUserMissionsBllRequest> getAllUserMissionsRequestClient
    ) : IMissionsService
{
    public async Task<GetUserMissionsResponse> GetAllAsync(GetUserMissionsRequest request)
    {
        GetUserMissionsBllRequest bllRequest = mapper.Map<GetUserMissionsBllRequest>(request);

        Response<GetUserMissionsResponse> response = await getAllUserMissionsRequestClient
            .GetResponse<GetUserMissionsResponse>(bllRequest);

        return response.Message;
    }
}