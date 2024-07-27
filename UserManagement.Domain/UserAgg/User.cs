using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;
using UserManagement.Domain.CompanyAgg;
using UserManagement.Domain.OrganizationChartAgg;

namespace UserManagement.Domain.UserAgg;

public class User : AuditableAggregateRootBase<int>
{
    private readonly IList<UserClaim> _claims;
    private IList<UserRole> _roles;

    public string Username { get; private set; }
    public string NationalCode { get; private set; }
    public string Fullname { get; private set; }
    public string Mobile { get; private set; }
    public string EmployeeCode { get; private set; }
    public int FailedLoginAttempts { get; private set; }
    public bool PasswordExpired { get; private set; }
    public List<UserSession> Sessions { get; private set; }
    public List<UserPassword> Passwords { get; private set; }

    public IReadOnlyCollection<UserClaim> Claims => new ReadOnlyCollection<UserClaim>(_claims);
    public IReadOnlyCollection<UserRole> Roles => new ReadOnlyCollection<UserRole>(_roles);

    protected User()
    {
    }

    public User(Guid actor, IEnumerable<int> rolesIds, string username, string nationalCode, string mobile, string fullname, string employeeCode) : base(actor)
    {
        NationalCode = nationalCode;
        Username = username;
        Fullname = fullname;
        Mobile = mobile;
        EmployeeCode = employeeCode;
        FailedLoginAttempts = 0;

        _roles = rolesIds.Select(x => new UserRole(Id, x)).ToList();
        ShouldChangePassword();
    }

    public void Edit(IEnumerable<int> rolesIds, string fullname, string username, string nationalCode, string mobile,
        string employeeCode)
    {
        NationalCode = nationalCode;
        EmployeeCode = employeeCode;

        _roles = rolesIds.Select(x => new UserRole(Id, x)).ToList();

        if (!string.IsNullOrEmpty(fullname)) Fullname = fullname;
        if (!string.IsNullOrEmpty(username)) Username = username;
        if (!string.IsNullOrEmpty(mobile)) Mobile = mobile;
    }

    public void OpenSession(Guid actor, string nationalCode, string userFullname, string username, string companytitle,
        string organizationChartTitle, bool isSuccessful, string clientIpAddress, int? tokenExpireTime = null)
    {
        //var session = new UserSession(actor, nationalCode, userFullname, username, companytitle,
        //    organizationChartTitle, isSuccessful, clientIpAddress, tokenExpireTime);
        //Sessions ??= new List<UserSession>();
        //Sessions.Add(session);
    }

    public void LoginFailed()
    {
        FailedLoginAttempts += 1;
    }

    public void SetPassword(Guid actor, string password, int passwordLifetimeDays, int forbiddenOldPasswordsCount,
        IPasswordHasher passwordHasher)
    {
        if (Passwords is not null)
        {
            foreach (var item in Passwords.OrderByDescending(x => x.Created).Take(forbiddenOldPasswordsCount))
            {
                var (verified, _) = passwordHasher.Check(item.Password, password);
                if (verified)
                    throw new BusinessException("0",
                        "از این کلمه رمز قبلا استفاده شده است. امکان درج کلمه رمز تکراری وجود ندارد.");

                item.Deactivate();
            }
        }
        else
            Passwords = new List<UserPassword>();

        var hash = passwordHasher.Hash(password);
        var expireDate = DateTime.Now.AddDays(passwordLifetimeDays).Date;
        var newPassword = new UserPassword(actor, Id, hash, expireDate);
        Passwords.Add(newPassword);

        if (actor != Guid)
            ShouldChangePassword();
        else
            PasswordRenewed();
    }

    public void ShouldChangePassword()
    {
        PasswordExpired = true;
    }

    public void PasswordRenewed()
    {
        PasswordExpired = false;
    }

    public void CloseAllSessions(Guid actor)
    {
        foreach (var session in Sessions) session.Deactivate();
    }

    public void ResetFailedLoginAttempts(Guid actor)
    {
        Unlock(actor);
        FailedLoginAttempts = 0;
    }
}