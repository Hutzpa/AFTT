using AFTT.EF.Enums;

namespace AFTT.Common.Models.Request.Bll.Missions;

public record MissionsGetBllRequest
{
    public Guid UserGuid { get; init; }
    public string? Title { get; init; }
    public MissionUrgency? Urgency { get; init; }
    public MissionStatus? Status { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}