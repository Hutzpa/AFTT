using AFTT.EF.Enums;

namespace AFTT.Common.Models.Request.Presentation.Missions;
public record MissionUpdateRequest
{
    public required Guid MissionGuid { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public MissionUrgency? Urgency { get; init; }
    public MissionStatus? Status { get; init; }
    public DateTime? PredictedCompletion { get; init; }
}