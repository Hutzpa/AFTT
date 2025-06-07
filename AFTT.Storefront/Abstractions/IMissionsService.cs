using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Storefront.Abstractions;

public interface IMissionsService
{
    Task<MissionsGetResponse> GetAsync(MissionsGetBllRequest request);
    Task<MissionCreateResponse> CreateAsync(MissionCreateRequest request, Guid userGuid);
    Task<MissionUpdateResponse> UpdateAsync(MissionUpdateRequest request, Guid userGuid);
}