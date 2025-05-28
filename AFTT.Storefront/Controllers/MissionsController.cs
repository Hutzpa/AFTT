using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AFTT.Storefront.Controllers;

[ApiController]
[Route("[controller]")]
internal class MissionsController(IMissionsService missionsService) : ControllerBase
{
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetUserMissionsRequest request)
    {
        GetUserMissionsResponse response = await missionsService.GetAllAsync(request);

        return Ok(response);
    }
    //Get relevant user missions
    //Add mission
    //Add sidemission
    //Update mission
}
