using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.Storefront.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AFTT.Storefront.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissionsController(IMissionsService missionsService) : ControllerBase
{
    Guid userGuid = Guid.Parse("C26528F4-6588-420B-BB14-05D65699BA00"); // Temporary hardcoded user GUID for testing

    //TODO: GET USER GUID FROM AUTHENTICATION CONTEXT INSTEAD OF QUERY PARAMETER
    [HttpGet("get-active")]
    [ProducesResponseType(typeof(MissionsGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetActiveAsync()
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

    //TODO: GET USER GUID FROM AUTHENTICATION CONTEXT
    [HttpGet("get-future")]
    [ProducesResponseType(typeof(MissionsGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFutureAsync()
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
        MissionCreateResponse response = await missionsService.CreateAsync(request, userGuid); //Add userGuid obtaining 

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
        MissionUpdateResponse response = await missionsService.UpdateAsync(request, userGuid);

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }
}