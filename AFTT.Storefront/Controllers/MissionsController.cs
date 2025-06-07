using AFTT.Common.Models.Request.Bll.Missions;
using AFTT.Common.Models.Request.Presentation.Missions;
using AFTT.Common.Models.Response.Missions;
using AFTT.EF.Enums;
using AFTT.Storefront.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AFTT.Storefront.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissionsController(IMissionsService missionsService) : ControllerBase
{
    Guid userGuid = Guid.Parse("C26528F4-6588-420B-BB14-05D65699BA00"); // Temporary hardcoded user GUID for testing

    //TODO: GET USER GUID FROM AUTHENTICATION CONTEXT INSTEAD OF QUERY PARAMETER
    [HttpGet]
    [ProducesResponseType(typeof(MissionsGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAsync(
        [FromQuery] string? title = null,
        [FromQuery] MissionUrgency? urgency = null,
        [FromQuery] MissionStatus? status = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        MissionsGetResponse response = await missionsService.GetAsync(new MissionsGetBllRequest
        {
            UserGuid = userGuid,
            Title = title,
            Urgency = urgency,
            Status = status,
            PageNumber = pageNumber,
            PageSize = pageSize
        });

        if (response.IsSuccess == false)
        {
            return BadRequest(response.Message);
        }

        return Ok(response);
    }

    [HttpPost]
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

    [HttpPut]
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