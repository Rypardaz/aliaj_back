using System;
using System.Collections.Generic;
using PhoenixFramework.Domain;

namespace UserManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<int, Role>
    {
        bool HasPermission(int userGroupId, int featureId);
        List<int> GetIdBatchBy(List<Guid> guids);
    }
}