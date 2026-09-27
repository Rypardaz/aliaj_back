using AM.Domain.UserAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class UserRepository(AliajCommandContext aliajCommandContext) : BaseRepository<int, User>(aliajCommandContext), IUserRepository
{
    public User GetByUsername(string username)
    {
        return aliajCommandContext.Users
            .FirstOrDefault(x => x.Username == username);
    }

    public long GetIdBy(Guid guid)
    {
        return aliajCommandContext.Users
                .FirstOrDefault(x => x.Guid == guid).Id
            ;
    }
}