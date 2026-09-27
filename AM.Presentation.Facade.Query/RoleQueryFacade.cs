using Ex.Application.Contracts.Role;
using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.Role;
using Lab.Infrastructure.Query.Contracts.Role;

namespace Lab.Presentation.Facade.Query;

public class RoleQueryFacade(IQueryBus queryBus) : IRoleQueryFacade
{
    public List<RoleViewModel> GetList() => queryBus.Dispatch<List<RoleViewModel>>();

    public EditRole GetForEdit(Guid guid) => queryBus.Dispatch<EditRole, Guid>(guid);

    public List<RoleComboModel> GetForCombo() => queryBus.Dispatch<List<RoleComboModel>>();
}