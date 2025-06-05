using AFTT.EF.Model;

namespace AFTT.Common.DataProviders.Abstractions;

public interface IMissionsDataProvider
{
    Task<IEnumerable<MissionDbEntity>> GetActiveUserMissionsAsync(Guid userGuid);
    Task<IEnumerable<MissionDbEntity>> GetFutureUserMissionsAsync(Guid userGuid);
    Task<MissionDbEntity?> GetByIdAsync(int id);
    Task<MissionDbEntity?> GetByGuidAsync(Guid missionGuid);
    Task<MissionDbEntity> CreateAsync(MissionDbEntity mission);
    Task<MissionDbEntity> UpdateAsync(MissionDbEntity mission);
    Task DeleteAsync(int id);
}