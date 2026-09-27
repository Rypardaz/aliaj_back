using Ex.Application.Contracts.Role;
using Ex.Domain.RoleAgg;
using Ex.Domain.RoleAgg.Services;
using Lab.Infrastructure.Query.Contracts.Role;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class RoleApplication(
    IRoleRepository roleRepository,
    IRoleValidatorService roleValidatorService,
    IClaimHelper claimHelper,
    IQueryBus queryBus) :
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