using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;

namespace AFTT.Storefront.Abstractions;

internal interface IMissionsService
{
    Task<GetUserMissionsResponse> GetAllAsync(GetUserMissionsRequest request);
}