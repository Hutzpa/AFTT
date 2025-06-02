using AFTT.Common.DataProviders.Abstractions;
using AFTT.EF;
using AFTT.EF.Enums;
using AFTT.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace AFTT.Common.DataProviders.Implementations.Ef;

public class MissionsEfDataProvider(MissionContext missionContext) : IMissionsDataProvider
{
    public async Task<IEnumerable<MissionDbEntity>> GetActiveUserMissionsAsync(Guid userGuid)
    {
        IEnumerable<MissionDbEntity> missionDbEntities = await GetUserMissionsByStatusAsync(userGuid, MissionStatus.InProgress);

        return missionDbEntities;
    }

    public async Task<IEnumerable<MissionDbEntity>> GetFutureUserMissionsAsync(Guid userGuid)
    {
        IEnumerable<MissionDbEntity> missionDbEntities = await GetUserMissionsByStatusAsync(userGuid, MissionStatus.Planned);

        return missionDbEntities;
    }

    private async Task<IEnumerable<MissionDbEntity>> GetUserMissionsByStatusAsync(Guid userGuid, MissionStatus status)
        => await missionContext.Missions
            .Include(m => m.Owner)
            .Where(m => m.Owner.UserGuid == userGuid && m.Status == status)
            .ToListAsync();

    public async Task<MissionDbEntity?> GetByIdAsync(int id)
    {
        return await missionContext.Missions
            .Include(m => m.Owner)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MissionDbEntity> CreateAsync(MissionDbEntity mission)
    {
        await missionContext.Missions.AddAsync(mission);
        await missionContext.SaveChangesAsync();

        return mission;
    }

    public async Task<MissionDbEntity> UpdateAsync(MissionDbEntity mission)
    {
        missionContext.Missions.Update(mission);
        await missionContext.SaveChangesAsync();

        return mission;
    }

    public async Task DeleteAsync(int id)
    {
        var mission = await missionContext.Missions.FindAsync(id);
        if (mission is not null)
        {
            missionContext.Missions.Remove(mission);
            await missionContext.SaveChangesAsync();
        }
    }
}