using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Core.Abstractions;

namespace AFTT.Core.Implementations;

internal class MissionsService : IMissionsService
{
    //Create lib with EF connection
    //Create lib with data provider
    //Inject data provider here
    public Task<GetUserMissionsResponse> GetAllAsync(GetUserMissionsBllRequest request)
    {
        throw new NotImplementedException();
    }
}