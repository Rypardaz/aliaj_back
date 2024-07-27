using UserManagement.Domain.Feature;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Acl.UserGroup
{
    public class UserGroupAcl : IUserGroupAcl
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IRoleRepository _roleRepository;

        public UserGroupAcl(IFeatureRepository featureRepository, IRoleRepository roleRepository)
        {
            _featureRepository = featureRepository;
            _roleRepository = roleRepository;
        }

        public bool CheckUserHasPermission(int userGroupId, string permission)
        {
            var featureId = _featureRepository.GetIdBy(permission);

            if (featureId == 0) return false;

            return _roleRepository.HasPermission(userGroupId, featureId);
        }
    }
}