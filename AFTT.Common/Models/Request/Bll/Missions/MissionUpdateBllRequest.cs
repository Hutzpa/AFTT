using AFTT.EF.Enums;

namespace AFTT.Common.Models.Request.Bll.Missions;
public record MissionUpdateBllRequest
{
    public required Guid UserGuid { get; set; }
    public required Guid MissionGuid { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public MissionUrgency? Urgency { get; init; }
    public MissionStatus? Status { get; init; }
    public DateTime? PredictedCompletion { get; init; }
}