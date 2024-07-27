using PhoenixFramework.Core;

namespace UserManagement.Domain.RoleAgg.Services
{
    public interface IRoleValidatorService : IDomainService
    {
        bool IsNameDuplicated(string name);
        bool IsNameDuplicated(string name, int id);
    }
}
