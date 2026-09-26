using Ex.Domain.RoleAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class RoleRepository(AliajCommandContext aliajCommandContext) : BaseRepository<int, Role>(aliajCommandContext), IRoleRepository
{
    public bool HasPermission(int userGroupId, int featureId) =>
        aliajCommandContext.Roles
            .SelectMany(x => x.Permissions)
            .Any(x => x.FeatureId == featureId);

    public List<int> GetIdBatchBy(List<Guid> guids) =>
        aliajCommandContext.Roles
            .Where(x => guids.Contains(x.Guid))
            .Select(x => x.Id)
            .ToList();
}