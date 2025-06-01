namespace AFTT.Common.Models.Request.Presentation.Missions;

public record FutureMissionsGetRequest
{
    public Guid UserGuid { get; init; }
}