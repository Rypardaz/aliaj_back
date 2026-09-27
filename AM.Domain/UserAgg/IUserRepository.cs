using PhoenixFramework.Domain;

namespace AM.Domain.UserAgg;

public interface IUserRepository : IRepository<int, User>
{
    User GetByUsername(string username);
    int GetIdBy(Guid guid);
}