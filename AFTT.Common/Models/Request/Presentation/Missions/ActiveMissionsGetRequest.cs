namespace AFTT.Common.Models.Request.Presentation.Missions;

public record ActiveMissionsGetRequest
{
    public Guid UserGuid { get; init; }
}