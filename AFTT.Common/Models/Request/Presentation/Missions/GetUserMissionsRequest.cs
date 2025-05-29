namespace AFTT.Common.Models.Request.Presentation.Missions;

public record GetUserMissionsRequest
{
    public Guid UserGuid { get; init; }
}