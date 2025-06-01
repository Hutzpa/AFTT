using AFTT.EF.Enums;

namespace AFTT.Common.Models.Response.Missions;
public record MissionDto
{
    public int Id { get; init; }
    public Guid MissionGuid { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime PredictedCompletion { get; init; }
    public MissionUrgency Urgency { get; init; }
    public MissionStatus Status { get; init; }

    public int OwnerId { get; init; }
}