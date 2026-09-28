using System.Text;
using AM.Domain.RoleAgg;
using AM.Domain.UserAgg;
using System.Security.Claims;
using PhoenixFramework.Identity;
using AM.Application.Contracts.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PhoenixFramework.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application.Command;

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

        if (user is null)
            throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        // var (verified, _) = passwordHasher.Check(user.Password, command.Password);
        //
        // if (!verified)
        //     throw new BusinessException("0", "نام کاربری یا کلمه عبور اشتباه است.");

        var (token, tokenExpirationUtc) = GenerateToken(user);

        return new UserViewModel
        {
            Id = user.Id,
            Fullname = user.Fullname,
            Username = user.Username,
            Token = token,
            TokenExpirationUtc = tokenExpirationUtc,
        };
    }

    private (string Token, DateTime ExpirationUtc) GenerateToken(User user)
    {
        var issuer = GetRequiredJwtSetting("Issuer");
        var audience = GetRequiredJwtSetting("Audience");
        var key = GetRequiredJwtSetting("Key");

        if (Encoding.UTF8.GetByteCount(key) < 32)
            throw new InvalidOperationException("Jwt:Key must be at least 32 bytes long.");

        var expiryMinutes = int.TryParse(configuration["Jwt:ExpiryMinutes"], out var configuredExpiryMinutes)
                            && configuredExpiryMinutes > 0
            ? configuredExpiryMinutes
            : 60;

        var expirationUtc = DateTime.UtcNow.AddMinutes(expiryMinutes);
        var claims = new[]
        {
            new Claim("id", user.Guid.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            new Claim("scope", "PhoenixCoreApi"),
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: expirationUtc,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256));

        return (new JwtSecurityTokenHandler().WriteToken(token), expirationUtc);
    }

    private string GetRequiredJwtSetting(string name) =>
        configuration[$"Jwt:{name}"] is { Length: > 0 } value
            ? value
            : throw new InvalidOperationException($"Jwt:{name} is not configured.");

    public void Handle(ChangePassword command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var user = userRepository.Load(actor, "Passwords");

        user.ChangePassword(passwordHasher.Hash(command.Password));
        
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