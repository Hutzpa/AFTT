using AFTT.EF.Enums;

namespace AFTT.Common.Models.Request.Bll.Missions;
public record MissionCreateBllRequest
{
    public Guid UserGuid { get; set; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public DateTime PredictedCompletion { get; init; }
    public MissionUrgency Urgency { get; init; }
}