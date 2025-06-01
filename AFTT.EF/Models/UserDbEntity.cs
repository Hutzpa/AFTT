using AFTT.EF.Model;
using System.ComponentModel.DataAnnotations;

namespace AFTT.EF.Models;
public record UserDbEntity
{
    [Key]
    public int Id { get; set; }
    public Guid UserGuid { get; init; }
    public required string Username { get; init; }
    public ICollection<MissionDbEntity> Missions { get; init; } = new List<MissionDbEntity>();

    public int SettingsId { get; init; }
    public required UserSettings Settings { get; init; }
}