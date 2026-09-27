using AM.Application.Contracts.Role;
using AM.Infrastructure.Query.Contract.Role;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Role;

public interface IRoleQueryFacade : IFacadeService
{
    List<RoleViewModel> GetList();
    EditRole GetForEdit(Guid guid);
    List<RoleComboModel> GetForCombo();
}