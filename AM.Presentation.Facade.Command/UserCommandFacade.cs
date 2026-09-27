using AM.Application.Contracts.User;
using AM.Presentation.Facade.Contract.User;
using PhoenixFramework.Application.Command;

namespace AM.Presentation.Facade.Command;

public class UserCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus) : IUserCommandFacade
{
    public UserViewModel Login(Login command) => responsiveCommandBus.Dispatch<Login, UserViewModel>(command);

    public void ChangePassword(ChangePassword command) => commandBus.Dispatch(command);

    public void Create(CreateUser command) => commandBus.Dispatch(command);

    public void Edit(EditUser command) => commandBus.Dispatch(command);

    public void Delete(Guid guid) => commandBus.Dispatch(new DeleteUser(guid));

    public void Lock(Guid guid) => commandBus.Dispatch(new LockUser(guid));

    public void Unlock(Guid guid) => commandBus.Dispatch(new UnlockUser(guid));

    public void OpenSession(OpenSession command) => commandBus.Dispatch(command);

    public void CloseSession(Guid guid) => commandBus.Dispatch(new CloseSession(guid));
}