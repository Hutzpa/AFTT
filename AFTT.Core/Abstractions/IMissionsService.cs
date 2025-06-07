using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Core.Abstractions;

internal interface IMissionsService
{
    Task<MissionsGetResponse> GetAsync(MissionsGetBllRequest request);
    Task<MissionCreateResponse> CreateAsync(MissionCreateBllRequest request);
    Task<MissionUpdateResponse> UpdateAsync(MissionUpdateBllRequest request);
}