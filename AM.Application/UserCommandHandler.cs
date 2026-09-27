using AM.Application.Contracts.User;
using AM.Domain.RoleAgg;
using AM.Domain.UserAgg;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Identity;

namespace AM.Application;

public class UserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IClaimHelper claimHelper,
    IRoleRepository roleRepository,
    IConfiguration configuration) :
    ICommandHandler<Login, UserViewModel>,
    ICommandHandler<ChangePassword>,
    ICommandHandler<CreateUser>,
    ICommandHandler<EditUser>,
    ICommandHandler<DeleteUser>,
    ICommandHandler<LockUser>,
    ICommandHandler<UnlockUser>,
    ICommandHandler<OpenSession>,
    ICommandHandler<CloseSession>
{
    public UserViewModel Handle(Login command)
    {
        var user = userRepository.GetByUsername(command.Username);

        if (user == null)
            throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        var (verified, _) = passwordHasher.Check(user.Passwords[0].Password, command.Password);

        if (!verified)
            throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        return new UserViewModel
        {
            Id = user.Id,
            Fullname = user.Fullname,
            Username = user.Username,
        };
    }

    public void Handle(ChangePassword command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(actor, "Passwords");

        var passwordLifetimeDays = int.Parse(configuration["PasswordLifetimeDays"]);
        var forbiddenOldPasswordsCount = int.Parse(configuration["ForbiddenOldPasswordsCount"]);
        user.SetPassword(actor, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount, passwordHasher);

        userRepository.Update(user);
    }

    public void Handle(CreateUser command)
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
    }

    public void Handle(EditUser command)
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
    }

    public void Handle(DeleteUser command)
    {
        var user = userRepository.Load(command.Guid);

        userRepository.Delete(user);
    }

    public void Handle(LockUser command)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(command.Guid);
        user.Lock(currentUserGuid);
    }

    public void Handle(UnlockUser command)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(command.Guid);
        user.ResetFailedLoginAttempts(currentUserGuid);
    }

    public void Handle(OpenSession command)
    {
        //var tokenExpiryTime = int.Parse(_configuration["TokenExpiryTime"]);
        //var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        //var user = _userRepository.Load(command.Guid, "Sessions,Comapny,OrganiztionChart");
        //user.OpenSession(currentUserGuid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
        //    user.OrganizationChart.Title, command.IsSuccessful, command.ClientIpAddress, tokenExpiryTime);

        //_userRepository.Update(user);
        //_userRepository.SaveChanges();
    }

    public void Handle(CloseSession command)
    {
        var user = userRepository.Load(command.Guid, "Sessions");
        user.CloseAllSessions(command.Guid);
    }
}