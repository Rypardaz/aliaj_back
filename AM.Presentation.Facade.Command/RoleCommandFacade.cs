using Ex.Application.Contracts.Role;
using PhoenixFramework.Application.Command;
using Lab.Presentation.Facade.Contract.Role;

namespace Lab.Presentation.Facade.Command;

public class RoleCommandFacade(ICommandBus commandBus) : IRoleCommandFacade
{
    public void Create(CreateRole command) => commandBus.Dispatch(command);

    public void Edit(EditRole command) => commandBus.Dispatch(command);

    public void Delete(Guid guid) => commandBus.Dispatch(new DeleteRole(guid));
}