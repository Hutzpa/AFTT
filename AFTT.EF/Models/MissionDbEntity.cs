using AFTT.EF.Enums;
using AFTT.EF.Models;
using System.ComponentModel.DataAnnotations;

namespace AFTT.EF.Model;

public record MissionDbEntity
{
    [Key]
    public int Id { get; init; }
    public Guid MissionGuid { get; init; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreationDate { get; init; }
    public DateTime PredictedCompletion { get; set; }
    public DateTime? ActualCompletion { get; set; }
    public MissionUrgency Urgency { get; set; }
    public MissionStatus Status { get; set; }

    public int OwnerId { get; init; }
    public required UserDbEntity Owner { get; init; }
}