using Ex.Application.Contracts.User;
using Ex.Domain.RoleAgg;
using Ex.Domain.UserAgg;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Identity;

namespace Ex.Application;

public class UserApplication(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IQueryBus queryBus,
    IClaimHelper claimHelper,
    IRoleRepository roleRepository,
    IConfiguration configuration)
    : IUserApplication
{
    public UserViewModel Login(Login command)
    {
        var user = userRepository.GetByUsername(command.Username);

        if (user == null)
            throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        //var (verified, _) = _passwordHasher.Check(user.Password, command.Password);

        //if (!verified)
        //    throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        return new UserViewModel
        {
            Id = user.Id,
            Fullname = user.Fullname,
            Username = user.Username,
        };
    }

    public void ChangePassword(ChangePassword command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(actor, "Passwords");

        var passwordLifetimeDays = int.Parse(configuration["PasswordLifetimeDays"]);
        var forbiddenOldPasswordsCount = int.Parse(configuration["ForbiddenOldPasswordsCount"]);
        user.SetPassword(actor, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount, passwordHasher);

        userRepository.Update(user);
        userRepository.SaveChanges();
    }

    public void Create(CreateUser command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        var roleIds = roleRepository.GetIdBatchBy(command.RoleGuids);

        if (userRepository.Exists(x => x.Username == command.Username))
            throw new BusinessException("0", "کاربر با این نام کاربری قبلا ثبت شده است.");

        var user = new User(creator, roleIds, command.SalonIds, command.Username, command.NationalCode, command.Mobile,
            command.Fullname, command.EmployeeCode);

        var passwordLifetimeDays = int.Parse(configuration["PasswordLifetimeDays"]);
        var forbiddenOldPasswordsCount = int.Parse(configuration["ForbiddenOldPasswordsCount"]);
        user.SetPassword(creator, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount, passwordHasher);

        userRepository.Create(user);
        userRepository.SaveChanges();
    }

    public void Edit(EditUser command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(command.Guid, "Passwords,Roles,Salons");
        var roleIds = roleRepository.GetIdBatchBy(command.RoleGuids);

        if (userRepository.Exists(x => x.Username == command.Username && x.Guid != command.Guid))
            throw new BusinessException("0", "کاربر با این نام کاربری قبلا ثبت شده است.");

        user.Edit(roleIds, command.SalonIds, command.Fullname, command.Username, command.NationalCode, command.Mobile,
            command.EmployeeCode);

        if (!string.IsNullOrWhiteSpace(command.Password))
        {
            var passwordLifetimeDays = int.Parse(configuration["PasswordLifetimeDays"]);
            var forbiddenOldPasswordsCount = int.Parse(configuration["ForbiddenOldPasswordsCount"]);
            user.SetPassword(actor, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount,
                passwordHasher);
        }

        userRepository.Update(user);
        userRepository.SaveChanges();
    }

    public EditUser GetBy(Guid guid)
    {
        return queryBus.Dispatch<EditUser, EditUserSearchModel>(new EditUserSearchModel(guid));
    }

    public List<UserViewModel> GetList()
    {
        return queryBus.Dispatch<List<UserViewModel>>();
    }

    public void Delete(Guid guid)
    {
        var user = userRepository.Load(guid);

        userRepository.Delete(user);
        userRepository.SaveChanges();
    }

    public void Lock(Guid guid)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(guid);
        user.Lock(currentUserGuid);

        userRepository.SaveChanges();
    }

    public void Unlock(Guid guid)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(guid);
        user.ResetFailedLoginAttempts(currentUserGuid);

        userRepository.SaveChanges();
    }

    public void OpenSession(OpenSession command)
    {
        //var tokenExpiryTime = int.Parse(_configuration["TokenExpiryTime"]);
        //var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        //var user = _userRepository.Load(command.Guid, "Sessions,Comapny,OrganiztionChart");
        //user.OpenSession(currentUserGuid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
        //    user.OrganizationChart.Title, command.IsSuccessful, command.ClientIpAddress, tokenExpiryTime);

        //_userRepository.Update(user);
        //_userRepository.SaveChanges();
    }

    public void CloseSession(Guid guid)
    {
        var user = userRepository.Load(guid, "Sessions");
        user.CloseAllSessions(guid);

        userRepository.SaveChanges();
    }
}