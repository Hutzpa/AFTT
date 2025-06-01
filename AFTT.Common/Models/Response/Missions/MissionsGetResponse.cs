namespace AFTT.Common.Models.Response.Missions;
public record MissionsGetResponse : BaseResponse
{
    public IEnumerable<MissionDto> Missions { get; set; } = new List<MissionDto>();
}