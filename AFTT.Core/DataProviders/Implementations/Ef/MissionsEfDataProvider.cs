using AFTT.Common.DataProviders.Abstractions;
using AFTT.EF;
using AFTT.EF.Enums;
using AFTT.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace AFTT.Common.DataProviders.Implementations.Ef;

public class MissionsEfDataProvider(MissionContext missionContext) : IMissionsDataProvider
{
    public async Task<IEnumerable<MissionDbEntity>> GetAsync(Guid userGuid, string? title, MissionUrgency? urgency, MissionStatus? status, int pageSize, int pageNumber)
    {
        IQueryable<MissionDbEntity> missions = missionContext.Missions
            .AsNoTracking()
            .Include(m => m.Owner)
            .Where(m => m.Owner.UserGuid == userGuid);

        //will be moved to extension methods later 
        if(string.IsNullOrEmpty(title) is false)
        {
            missions = missions.Where(m => m.Title.ToLower().Contains(title.ToLower()));
        }

        if(urgency is not null)
        {
            missions = missions.Where(m => m.Urgency == urgency);
        }

        if(status is not null)
        {
            missions = missions.Where(m => m.Status == status);
        }

        IQueryable<MissionDbEntity> paginatedMissions = missions
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return await paginatedMissions.ToListAsync();
    }
    public async Task<MissionDbEntity?> GetByIdAsync(int id)
        => await missionContext.Missions
            .Include(m => m.Owner)
            .FirstOrDefaultAsync(m => m.Id == id);

    public Task<MissionDbEntity?> GetByGuidAsync(Guid missionGuid)
        => missionContext.Missions
            .Include(m => m.Owner)
            .FirstOrDefaultAsync(m => m.MissionGuid == missionGuid);

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