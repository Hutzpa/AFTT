using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Core.Abstractions;

internal interface IMissionsService
{
    Task<GetUserMissionsResponse> GetAllAsync(GetUserMissionsBllRequest request);
}