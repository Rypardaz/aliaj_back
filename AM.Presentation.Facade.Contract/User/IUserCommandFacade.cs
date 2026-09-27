using Ex.Application.Contracts.User;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.User;

public interface IUserCommandFacade : IFacadeService
{
    UserViewModel Login(Login command);
    void ChangePassword(ChangePassword command);
    void Create(CreateUser command);
    void Edit(EditUser command);
    void Delete(Guid guid);
    void Lock(Guid guid);
    void Unlock(Guid guid);
    void OpenSession(OpenSession command);
    void CloseSession(Guid guid);
}