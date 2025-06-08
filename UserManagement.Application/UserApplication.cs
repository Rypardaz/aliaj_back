using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Identity;
using UserManagement.Domain.UserAgg;
using UserManagement.Application.Contracts.Contracts;
using UserManagement.Application.Contracts.Commands.User;
using UserManagement.Application.Contracts.SearchModels;
using UserManagement.Application.Contracts.ViewModels;
using UserManagement.Domain.ClassificationLevelAgg;
using UserManagement.Domain.CompanyAgg;
using UserManagement.Domain.OrganizationChartAgg;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Application;

public class UserApplication : IUserApplication
{
    private readonly IClaimHelper _claimHelper;
    private readonly IQueryBus _queryBus;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRoleRepository _roleRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IOrganizationChartRepository _organizationChartRepository;
    private readonly IClassificationLevelRepository _classificationLevelRepository;
    private readonly IConfiguration _configuration;

    public UserApplication(IUserRepository userRepository, IPasswordHasher passwordHasher, IQueryBus queryBus,
        IClaimHelper claimHelper, ICompanyRepository companyRepository,
        IOrganizationChartRepository organizationChartRepository, IRoleRepository roleRepository,
        IClassificationLevelRepository classificationLevelRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _queryBus = queryBus;
        _claimHelper = claimHelper;
        _companyRepository = companyRepository;
        _organizationChartRepository = organizationChartRepository;
        _roleRepository = roleRepository;
        _classificationLevelRepository = classificationLevelRepository;
        _configuration = configuration;
    }

    public UserViewModel Login(Login command)
    {
        var user = _userRepository.GetByUsername(command.Username);

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
        var actor = _claimHelper.GetCurrentUserGuid();
        var user = _userRepository.Load(actor, "Passwords");

        var passwordLifetimeDays = int.Parse(_configuration["PasswordLifetimeDays"]);
        var forbiddenOldPasswordsCount = int.Parse(_configuration["ForbiddenOldPasswordsCount"]);
        user.SetPassword(actor, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount, _passwordHasher);

        _userRepository.Update(user);
        _userRepository.SaveChanges();
    }

    public void Create(CreateUser command)
    {
        var creator = _claimHelper.GetCurrentUserGuid();

        var roleIds = _roleRepository.GetIdBatchBy(command.RoleGuids);

        if (_userRepository.Exists(x => x.Username == command.Username))
            throw new BusinessException("0", "کاربر با این نام کاربری قبلا ثبت شده است.");

        var user = new User(creator, roleIds, command.Username, command.NationalCode, command.Mobile, command.Fullname, command.EmployeeCode);

        var passwordLifetimeDays = int.Parse(_configuration["PasswordLifetimeDays"]);
        var forbiddenOldPasswordsCount = int.Parse(_configuration["ForbiddenOldPasswordsCount"]);
        user.SetPassword(creator, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount, _passwordHasher);

        _userRepository.Create(user);
        _userRepository.SaveChanges();
    }

    public void Edit(EditUser command)
    {
        var actor = _claimHelper.GetCurrentUserGuid();
        var user = _userRepository.Load(command.Guid, "Passwords,Roles");
        var roleIds = _roleRepository.GetIdBatchBy(command.RoleGuids);

        if (_userRepository.Exists(x => x.Username == command.Username && x.Guid != command.Guid))
            throw new BusinessException("0", "کاربر با این نام کاربری قبلا ثبت شده است.");

        user.Edit(roleIds, command.Fullname, command.Username, command.NationalCode, command.Mobile, command.EmployeeCode);

        if (!string.IsNullOrWhiteSpace(command.Password))
        {
            var passwordLifetimeDays = int.Parse(_configuration["PasswordLifetimeDays"]);
            var forbiddenOldPasswordsCount = int.Parse(_configuration["ForbiddenOldPasswordsCount"]);
            user.SetPassword(actor, command.Password, passwordLifetimeDays, forbiddenOldPasswordsCount,
                _passwordHasher);
        }

        _userRepository.Update(user);
        _userRepository.SaveChanges();
    }

    public EditUser GetBy(Guid guid)
    {
        return _queryBus.Dispatch<EditUser, EditUserSearchModel>(new EditUserSearchModel(guid));
    }

    public List<UserViewModel> GetList()
    {
        return _queryBus.Dispatch<List<UserViewModel>>();
    }

    public void Delete(Guid guid)
    {
        var user = _userRepository.Load(guid);

        _userRepository.Delete(user);
        _userRepository.SaveChanges();
    }

    public void Lock(Guid guid)
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        var user = _userRepository.Load(guid);
        user.Lock(currentUserGuid);

        _userRepository.SaveChanges();
    }

    public void Unlock(Guid guid)
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        var user = _userRepository.Load(guid);
        user.ResetFailedLoginAttempts(currentUserGuid);

        _userRepository.SaveChanges();
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
        var user = _userRepository.Load(guid, "Sessions");
        user.CloseAllSessions(guid);

        _userRepository.SaveChanges();
    }
}