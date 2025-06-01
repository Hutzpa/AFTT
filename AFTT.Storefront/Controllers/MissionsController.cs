using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AFTT.Storefront.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissionsController(IMissionsService missionsService) : ControllerBase
{
    //TODO: GET USER GUID FROM AUTHENTICATION CONTEXT INSTEAD OF QUERY PARAMETER
    [HttpGet("get-active")]
    [ProducesResponseType(typeof(MissionsGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetActiveAsync([FromQuery] Guid userGuid)
    {
        MissionsGetResponse response = await missionsService.GetActiveAsync(new ActiveMissionsGetRequest
        {
            UserGuid = userGuid
        });

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    //TODO: GET USER GUID FROM AUTHENTICATION CONTEXT INSTEAD OF QUERY PARAMETER
    [HttpGet("get-future")]
    [ProducesResponseType(typeof(MissionsGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFutureAsync([FromQuery] Guid userGuid)
    {
        MissionsGetResponse response = await missionsService.GetFutureAsync(new FutureMissionsGetRequest
        {
            UserGuid = userGuid
        });

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(MissionCreateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync([FromBody] MissionCreateRequest request)
    {
        MissionCreateResponse response = await missionsService.CreateAsync(request);

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    [HttpPut("update")]
    [ProducesResponseType(typeof(MissionUpdateResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync([FromBody] MissionUpdateRequest request)
    {
        MissionUpdateResponse response = await missionsService.UpdateAsync(request);

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }
}