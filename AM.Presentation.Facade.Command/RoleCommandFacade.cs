using AM.Application.Contracts.Role;
using AM.Presentation.Facade.Contract.Role;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class RoleCommandFacade(ICommandBus commandBus) : IRoleCommandFacade
{
    public void Create(CreateRole command) => commandBus.Dispatch(command);

    public void Edit(EditRole command) => commandBus.Dispatch(command);

    public void Delete(Guid guid) => commandBus.Dispatch(new DeleteRole(guid));
}