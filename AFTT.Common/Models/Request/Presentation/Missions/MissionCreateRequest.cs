using AFTT.EF.Enums;

namespace AFTT.Common.Models.Request.Presentation.Missions;
public record MissionCreateRequest
{
    public required string Title { get; init; }
    public string? Description { get; init; }
    public DateTime PredictedCompletion { get; init; }
    public MissionUrgency Urgency { get; init; }
}