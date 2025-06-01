using AFTT.Common.DataProviders.Abstractions;
using AFTT.Common.Enums;
using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using AFTT.EF.Model;
using AutoMapper;

namespace AFTT.Core.Implementations;

internal class MissionsService(IMapper mapper,
    IMissionsDataProvider missionsDataProvider) : IMissionsService
{
    //TODO: PLAN AND IMPLEMENT RESTRICTIONS AND VALIDATION RULES

    public async Task<MissionsGetResponse> GetActiveAsync(ActiveMissionsGetBllRequest request)
    {
        IEnumerable<MissionDbEntity> missions = await missionsDataProvider.GetActiveUserMissionsAsync(request.UserGuid);

        IEnumerable<MissionDto> missionsResult = mapper.Map<IEnumerable<MissionDto>>(missions);

        return new MissionsGetResponse
        {
            Missions = missionsResult
        };
    }

    public async Task<MissionsGetResponse> GetFutureAsync(FutureMissionsGetBllRequest request)
    {
        IEnumerable<MissionDbEntity> missions = await missionsDataProvider.GetFutureUserMissionsAsync(request.UserGuid);

        IEnumerable<MissionDto> missionsResult = mapper.Map<IEnumerable<MissionDto>>(missions);

        return new MissionsGetResponse
        {
            Missions = missionsResult
        };
    }

    public async Task<MissionCreateResponse> CreateAsync(MissionCreateBllRequest request)
    {
        MissionDbEntity mission = mapper.Map<MissionDbEntity>(request);

        MissionDbEntity createResult = await missionsDataProvider.CreateAsync(mission);

        MissionDto missionResult = mapper.Map<MissionDto>(createResult);

        return new MissionCreateResponse
        {
            Mission = missionResult
        };
    }

    public async Task<MissionUpdateResponse> UpdateAsync(MissionUpdateBllRequest request)
    {
        MissionDbEntity? mission = await missionsDataProvider.GetByIdAsync(request.Id);

        if (mission == null)
        {
            return new MissionUpdateResponse
            {
                ResponseCode = ResponseCode.MissionNotFound,
                Message = "Mission not found."
            };
        }

        MissionDbEntity updatedMission = mapper.Map<MissionDbEntity>(request);

        MissionDbEntity updateResult = await missionsDataProvider.UpdateAsync(mission);

        MissionDto missionResult = mapper.Map<MissionDto>(updateResult);

        return new MissionUpdateResponse
        {
            Mission = missionResult
        };
    }
}