namespace AFTT.EF.Model;

public record MissionDbEntity
{
    public int Id { get; init; }
    public Guid MissionGuid { get; init; }
    public required string Title { get; init; }
    public DateTime CreationDate { get; init; }
}