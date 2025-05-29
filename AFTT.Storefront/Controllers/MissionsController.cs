using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AFTT.Storefront.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissionsController(IMissionsService missionsService) : ControllerBase
{
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        GetUserMissionsResponse response = await missionsService.GetAllAsync(new GetUserMissionsRequest //mapped request
        {
            UserGuid = Guid.NewGuid()
        });

        return Ok(response);
    }
    //Get relevant user missions
    //Add mission
    //Add sidemission
    //Update mission
}
