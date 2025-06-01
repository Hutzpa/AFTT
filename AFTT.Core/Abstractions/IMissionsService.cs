using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Core.Abstractions;

internal interface IMissionsService
{
    Task<MissionsGetResponse> GetActiveAsync(ActiveMissionsGetBllRequest request);
    Task<MissionsGetResponse> GetFutureAsync(FutureMissionsGetBllRequest request);
    Task<MissionCreateResponse> CreateAsync(MissionCreateBllRequest request);
    Task<MissionUpdateResponse> UpdateAsync(MissionUpdateBllRequest request);
}