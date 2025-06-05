using AFTT.EF.Models;

namespace AFTT.Core.DataProviders.Abstractions;

public interface IUserDataProvider
{
    Task<UserDbEntity> GetUserByGuidAsync(Guid userGuid);

    Task<UserDbEntity> CreateUserAsync(string username);
}
