namespace AFTT.Common.Models.Response.Missions;
public record MissionCreateResponse : BaseResponse
{
    public required MissionDto Mission { get; init; }
}