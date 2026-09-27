using PhoenixFramework.Domain;

namespace AM.Domain.RoleAgg;

public interface IRoleRepository : IRepository<int, Role>
{
    bool HasPermission(int userGroupId, int featureId);
    List<int> GetIdBatchBy(List<Guid> guids);
}