using AM.Application.Contracts.Role;
using AM.Domain.RoleAgg;
using AM.Domain.RoleAgg.Services;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class RoleCommandHandler(
    IRoleRepository roleRepository,
    IRoleValidatorService roleValidatorService,
    IClaimHelper claimHelper) :
    ICommandHandler<CreateRole>,
    ICommandHandler<EditRole>,
    ICommandHandler<DeleteRole>
{
    private static List<RolePermission> ProducePermissions(IEnumerable<int> permissions)
    {
        return [.. permissions.Select(permission => new RolePermission(permission))];
    }

    public void Handle(CreateRole command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var permissions = ProducePermissions(command.Permissions);

        var role = new Role(creator, command.Title, permissions, roleValidatorService);

        roleRepository.Create(role);
    }

    public void Handle(EditRole command)
    {
        var role = roleRepository.Load(command.Guid, "Permissions");
        var permissions = ProducePermissions(command.Permissions);
        role.Edit(command.Title, permissions, roleValidatorService);
    }

    public void Handle(DeleteRole command)
    {
        var role = roleRepository.Load(command.Guid);
        roleRepository.Delete(role);
    }
}