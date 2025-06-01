using System.ComponentModel.DataAnnotations;

namespace AFTT.EF.Models;
public record UserSettings
{
    [Key]
    public int Id { get; init; }

    public required string Language { get; init; } = "en-US"; // Default to English (United States)
    public required string Timezone { get; init; } = "UTC"; // Default to UTC


    public int OwnerId { get; init; }
    public required UserDbEntity Owner { get; init; }
}