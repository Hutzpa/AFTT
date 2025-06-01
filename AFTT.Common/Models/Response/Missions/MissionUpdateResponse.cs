namespace AFTT.Common.Models.Response.Missions;
public record MissionUpdateResponse : BaseResponse
{
    public MissionDto? Mission { get; init; }
}