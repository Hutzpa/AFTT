namespace AFTT.Common.Models.Request.Bll.Missions;

public record ActiveMissionsGetBllRequest
{
    public Guid UserGuid { get; init; }
}