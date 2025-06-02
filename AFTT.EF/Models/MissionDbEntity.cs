using AFTT.EF.Enums;
using AFTT.EF.Models;
using System.ComponentModel.DataAnnotations;

namespace AFTT.EF.Model;

public record MissionDbEntity
{
    [Key]
    public int Id { get; init; }
    public Guid MissionGuid { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime PredictedCompletion { get; init; }
    public DateTime? ActualCompletion { get; init; }
    public MissionUrgency Urgency { get; init; }
    public MissionStatus Status { get; init; }

    public int OwnerId { get; init; }
    public required UserDbEntity Owner { get; init; }
}