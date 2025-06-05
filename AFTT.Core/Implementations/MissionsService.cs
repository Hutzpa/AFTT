using AFTT.Common.DataProviders.Abstractions;
using AFTT.Common.Enums;
using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;
using AFTT.Core.DataProviders.Abstractions;
using AFTT.EF.Enums;
using AFTT.EF.Model;
using AFTT.EF.Models;
using AutoMapper;

namespace AFTT.Core.Implementations;

internal class MissionsService(IMapper mapper,
    IMissionsDataProvider missionsDataProvider,
    IUserDataProvider userDataProvider) : IMissionsService
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
        UserDbEntity user = await userDataProvider.CreateUserAsync("DefaultUser");

        //UserDbEntity userDbEntity = await userDataProvider.GetUserByGuidAsync(request.UserGuid);

        MissionDbEntity mission = new()
        {
            MissionGuid = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreationDate = DateTime.UtcNow,
            PredictedCompletion = request.PredictedCompletion,
            Status = MissionStatus.Planned,
            Urgency = request.Urgency,
            Owner = user
        };

        MissionDbEntity createResult = await missionsDataProvider.CreateAsync(mission);

        MissionDto missionResult = mapper.Map<MissionDto>(createResult);

        return new MissionCreateResponse
        {
            Mission = missionResult
        };
    }

    public async Task<MissionUpdateResponse> UpdateAsync(MissionUpdateBllRequest request)
    {
        MissionDbEntity? mission = await missionsDataProvider.GetByGuidAsync(request.MissionGuid);

        if (mission == null)
        {
            return new MissionUpdateResponse
            {
                ResponseCode = ResponseCode.MissionNotFound,
                Message = "Mission not found."
            };
        }

        UserDbEntity user = await userDataProvider.GetUserByGuidAsync(request.UserGuid);

        if (mission.OwnerId != user.Id)
        {
            return new MissionUpdateResponse
            {
                ResponseCode = ResponseCode.NotCurrentUserMission,
                Message = "Hey hey hey, taking other people's stuff isn't nice"
            };
        }

        mission = PerformUpdate(mission, request);

        MissionDbEntity updateResult = await missionsDataProvider.UpdateAsync(mission);

        MissionDto missionResult = mapper.Map<MissionDto>(updateResult);

        return new MissionUpdateResponse
        {
            Mission = missionResult
        };
    }

    private static MissionDbEntity PerformUpdate(MissionDbEntity targetEntity, MissionUpdateBllRequest updatedEntity)
    {
        targetEntity.Title = updatedEntity.Title ?? targetEntity.Title;
        targetEntity.Description = updatedEntity.Description ?? targetEntity.Description;
        targetEntity.Urgency = updatedEntity.Urgency ?? targetEntity.Urgency;
        targetEntity.Status = updatedEntity.Status ?? targetEntity.Status;
        targetEntity.PredictedCompletion = updatedEntity.PredictedCompletion ?? targetEntity.PredictedCompletion;

        return targetEntity;
    }
}