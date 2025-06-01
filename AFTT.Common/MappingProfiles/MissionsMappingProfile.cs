using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.EF.Model;
using AutoMapper;

namespace AFTT.Common.MappingProfiles;

public class MissionsMappingProfile : Profile
{
    public MissionsMappingProfile()
    {
        CreateMap<ActiveMissionsGetRequest, ActiveMissionsGetBllRequest>();
        CreateMap<FutureMissionsGetRequest, FutureMissionsGetBllRequest>();
        CreateMap<MissionCreateRequest, MissionCreateBllRequest>();
        CreateMap<MissionUpdateRequest, MissionUpdateBllRequest>();

        CreateMap<MissionDbEntity, MissionDto>();
    }
}