using AFTT.EF.Enums;
using AFTT.EF.Model;

namespace AFTT.Common.DataProviders.Abstractions;

public interface IMissionsDataProvider
{
    Task<IEnumerable<MissionDbEntity>> GetAsync(Guid userGuid, string? title, MissionUrgency? urgency, MissionStatus? status, int pageSize, int pageNumber);
    Task<MissionDbEntity?> GetByIdAsync(int id);
    Task<MissionDbEntity?> GetByGuidAsync(Guid missionGuid);
    Task<MissionDbEntity> CreateAsync(MissionDbEntity mission);
    Task<MissionDbEntity> UpdateAsync(MissionDbEntity mission);
    Task DeleteAsync(int id);
}