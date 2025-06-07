using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using AutoMapper;
using MassTransit;

namespace AFTT.Storefront.Implementations;

internal class MissionsService(
    IMapper mapper,
    IRequestClient<MissionsGetBllRequest> getUserMissionsRequestClient,
    IRequestClient<MissionCreateBllRequest> createMissionRequestClient,
    IRequestClient<MissionUpdateBllRequest> updateMissionRequestClient
    ) : IMissionsService
{
    public async Task<MissionsGetResponse> GetAsync(MissionsGetBllRequest request)
    {
        // add validation 
        Response<MissionsGetResponse> response = await getUserMissionsRequestClient
            .GetResponse<MissionsGetResponse>(request);

        return response.Message;
    }

    public async Task<MissionCreateResponse> CreateAsync(MissionCreateRequest request, Guid userGuid)
    {
        //add validation
        MissionCreateBllRequest bllRequest = mapper.Map<MissionCreateBllRequest>(request, opts =>
        {
            opts.AfterMap((src, dest) =>
            {
                dest.UserGuid = userGuid; 
            });
        });

        Response<MissionCreateResponse> response = await createMissionRequestClient
            .GetResponse<MissionCreateResponse>(request);

        return response.Message;
    }

    public async Task<MissionUpdateResponse> UpdateAsync(MissionUpdateRequest request, Guid userGuid)
    {
        // add validation 
        MissionUpdateBllRequest bllRequest = mapper.Map<MissionUpdateBllRequest>(request, opts =>
        {
            opts.AfterMap((src, dest) =>
            {
                dest.UserGuid = userGuid;
            });
        });

        Response<MissionUpdateResponse> response = await updateMissionRequestClient
            .GetResponse<MissionUpdateResponse>(request);

        return response.Message;
    }
}