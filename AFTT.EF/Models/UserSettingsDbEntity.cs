using System.ComponentModel.DataAnnotations;

namespace AFTT.EF.Models;
public record UserSettingsDbEntity
{
    [Key]
    public int Id { get; init; }

    public string Language { get; init; } = "en-US"; // Default to English (United States)
    public string Timezone { get; init; } = "UTC"; // Default to UTC


    public int OwnerId { get; init; }
    public required UserDbEntity Owner { get; init; }
}