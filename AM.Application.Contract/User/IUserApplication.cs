namespace Ex.Application.Contracts.User;

public interface IUserApplication
{
    UserViewModel Login(Login command);
    void ChangePassword(ChangePassword command);
    void Create(CreateUser command);
    void Edit(EditUser command);
    EditUser GetBy(Guid guid);
    List<UserViewModel> GetList();
    void Delete(Guid guid);
    void Lock(Guid guid);
    void Unlock(Guid guid);
    void OpenSession(OpenSession command);
    void CloseSession(Guid guid);
}