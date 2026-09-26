using Ex.Domain.RoleAgg;
using PhoenixFramework.Domain;

namespace Ex.Domain.UserAgg;

public class UserRole(int userId, int roleId) : EntityBase<long>
{
    public int UserId { get; private set; } = userId;
    public int RoleId { get; private set; } = roleId;
    public User User { get; private set; }
    public Role Role { get; private set; }
}