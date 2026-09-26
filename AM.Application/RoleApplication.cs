using Ex.Application.Contracts.Role;
using Ex.Domain.RoleAgg;
using Ex.Domain.RoleAgg.Services;
using Lab.Infrastructure.Query.Contracts.Role;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class RoleApplication(
    IRoleRepository roleRepository,
    IRoleValidatorService roleValidatorService,
    IClaimHelper claimHelper,
    IQueryBus queryBus)
    : IRoleApplication
{
    public void Create(CreateRole command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var permissions = ProducePermissions(command.Permissions);

        var role = new Role(creator, command.Title, permissions, roleValidatorService);

        roleRepository.Create(role);
        roleRepository.SaveChanges();
    }

    private static List<RolePermission> ProducePermissions(IEnumerable<int> permissions)
    {
        return permissions.Select(permission => new RolePermission(permission))
            .ToList();
    }

    public void Edit(EditRole command)
    {
        var role = roleRepository.Load(command.Guid, "Permissions");
        var permissions = ProducePermissions(command.Permissions);
        role.Edit(command.Title, permissions, roleValidatorService);
        roleRepository.SaveChanges();
    }

    public List<RoleViewModel> List()
    {
        return queryBus.Dispatch<List<RoleViewModel>>();
    }

    public EditRole GetDetails(Guid guid)
    {
        return queryBus.Dispatch<EditRole, Guid>(guid);
    }

    // public List<RoleComboModel> GetForCombo()
    // {
    //     return queryBus.Dispatch<List<RoleComboModel>>();
    // }

    public void Delete(Guid guid)
    {
        var role = roleRepository.Load(guid);
        
        roleRepository.Delete(role);
        roleRepository.SaveChanges();
    }
}