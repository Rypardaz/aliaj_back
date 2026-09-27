using Ex.Application.Contracts.Role;
using Lab.Infrastructure.Query.Contracts.Role;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.Role;

public interface IRoleQueryFacade : IFacadeService
{
    List<RoleViewModel> GetList();
    EditRole GetForEdit(Guid guid);
    List<RoleComboModel> GetForCombo();
}