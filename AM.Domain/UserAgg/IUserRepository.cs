using PhoenixFramework.Domain;

namespace Ex.Domain.UserAgg;

public interface IUserRepository : IRepository<int, User>
{
    User GetByUsername(string username);
    int GetIdBy(Guid guid);
}