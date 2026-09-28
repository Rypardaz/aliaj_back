using AM.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class UserRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<int, User>(aliajCommandContext), IUserRepository
{
    public User? GetByUsername(string username)
    {
        return aliajCommandContext.Users.FirstOrDefault(x => x.Username == username);
    }
}