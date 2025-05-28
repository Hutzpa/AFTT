using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AutoMapper;

namespace AFTT.Common.MappingProfiles;

public class MissionsMappingProfile : Profile
{
    public MissionsMappingProfile()
    {
        CreateMap<GetUserMissionsRequest, GetUserMissionsBllRequest>();
    }
}