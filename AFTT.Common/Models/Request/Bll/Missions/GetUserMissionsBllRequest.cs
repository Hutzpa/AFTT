namespace AFTT.Common.Models.Request.Bll.Missions;

public record GetUserMissionsBllRequest
{
    public Guid UserGuid { get; init; }
}