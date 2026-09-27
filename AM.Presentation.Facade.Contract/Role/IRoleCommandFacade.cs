using Ex.Application.Contracts.Role;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.Role;

public interface IRoleCommandFacade : IFacadeService
{
    void Create(CreateRole command);
    void Edit(EditRole command);
    void Delete(Guid guid);
}