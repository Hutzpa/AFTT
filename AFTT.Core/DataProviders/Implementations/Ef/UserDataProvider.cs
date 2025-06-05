using AFTT.Core.DataProviders.Abstractions;
using AFTT.EF;
using AFTT.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AFTT.Core.DataProviders.Implementations.Ef;

internal class UserDataProvider(MissionContext missionContext) : IUserDataProvider
{
    public async Task<UserDbEntity> CreateUserAsync(string username)
    {
        UserDbEntity user = new()
        {
            UserGuid = Guid.NewGuid(),
            Username = username
        };

        missionContext.Users.Add(user);

        await missionContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserDbEntity> GetUserByGuidAsync(Guid userGuid)
        => await missionContext.Users.AsNoTracking().FirstAsync(user => user.UserGuid == userGuid);
}