using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Storefront.Abstractions;

public interface IMissionsService
{
    Task<MissionsGetResponse> GetActiveAsync(ActiveMissionsGetRequest request);
    Task<MissionsGetResponse> GetFutureAsync(FutureMissionsGetRequest request);
    Task<MissionCreateResponse> CreateAsync(MissionCreateRequest request);
    Task<MissionUpdateResponse> UpdateAsync(MissionUpdateRequest request);
}