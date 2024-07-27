using System.Runtime.CompilerServices;

namespace UserManagement.Acl.UserGroup
{
    public interface IUserGroupAcl
    {
        bool CheckUserHasPermission(int userGroupId, string permission);
    }
}