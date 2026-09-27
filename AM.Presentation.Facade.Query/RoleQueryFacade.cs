using AM.Application.Contracts.Role;
using AM.Infrastructure.Query.Contract.Role;
using AM.Presentation.Facade.Contract.Role;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class RoleQueryFacade(IQueryBus queryBus) : IRoleQueryFacade
{
    public List<RoleViewModel> GetList() => queryBus.Dispatch<List<RoleViewModel>>();

    public EditRole GetForEdit(Guid guid) => queryBus.Dispatch<EditRole, Guid>(guid);

    public List<RoleComboModel> GetForCombo() => queryBus.Dispatch<List<RoleComboModel>>();
}