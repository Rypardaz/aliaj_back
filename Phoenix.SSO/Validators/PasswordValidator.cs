using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;
using UserManagement.Domain.UserAgg;
using UserManagement.Persistence;

namespace Phoenix.SSO.Validators;

public class PasswordValidator : IPasswordValidator
{
    private readonly int _loginAttemptsCountLimit;

    private readonly UserManagementCommandContext _context;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConnectionStringBuilder _connectionStringBuilder;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public PasswordValidator(UserManagementCommandContext context, IPasswordHasher passwordHasher,
        IConnectionStringBuilder connectionStringBuilder, IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _connectionStringBuilder = connectionStringBuilder;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _loginAttemptsCountLimit = int.Parse(_configuration["LoginAttemptsCountLimit"]);
    }

    public PasswordValidationResult Validate(string username, string password)
    {
        // var dbContextOptionsBuilder = new DbContextOptionsBuilder<UserManagementCommandContext>();
        // var dbName = context.Request.Raw["dbName"];
        // var connectionString = _connectionStringBuilder.Build(dbName);
        // dbContextOptionsBuilder.UseSqlServer(connectionString);
        // var identityContext = new UserManagementCommandContext(dbContextOptionsBuilder.Options);

        var result = new PasswordValidationResult();

        var user = _context
            .Users
            .Include(x => x.Passwords)
            .Include(x => x.Sessions
                .Where(x => x.IsSuccessful)
                .Where(x => x.IsActive == EntityBase<long>.ActiveStates.Active))
            .Include(u => u.Roles)
            .FirstOrDefault(x => x.Username == username && !x.IsRemoved);

        if (user is null)
            return result.Failed("مشخصات ورود اشتباه است. لطفا دوباره تلاش کنید.");

        if (user.IsLocked == AuditableAggregateRootBase<int>.LockStates.Lock)
            return result.Failed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");

        //if (LoginAttemptsCountReached(user))
        //{
        //    user.Lock(user.Guid);
        //    _context.SaveChanges();

        //    return result.Failed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");
        //}

        var clientIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

        //if (user.Sessions.Any(x => !x.IsExpired()))
        //{
        //    user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
        //        user.OrganizationChart.Title, false, clientIpAddress);
        //    _context.SaveChanges();

        //    return result.Failed("کاربر با این مشخصات قبلا وارد سیستم شده است.");
        //}

        var userPassword = user.Passwords
            .First(x => x.IsActive == EntityBase<long>.ActiveStates.Active);

        var (verified, _) = _passwordHasher.Check(userPassword.Password, password);

        if (!verified)
        {
            //user.LoginFailed();
            //if (LoginAttemptsCountReached(user))
            //{
            //    user.Lock(user.Guid);
            //    _context.SaveChanges();
                
            //    return result.Failed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");
            //}

            //user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
            //    user.OrganizationChart.Title, false, clientIpAddress);
            _context.SaveChanges();

            return result.Failed("مشخصات ورود اشتباه است. لطفا دوباره تلاش کنید.");
        }

        var tokenExpiryTime = int.Parse(_configuration["TokenExpiryTime"]);
        //user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
        //    user.OrganizationChart.Title, true, clientIpAddress, tokenExpiryTime);

        //var firstLogin = _context.Users
        //    .Where(x => x.Guid == user.Guid)
        //    .SelectMany(x => x.Sessions)
        //    .Any(x => x.IsSuccessful) == false;

        //var shouldChangePassword = firstLogin || userPassword.IsExpired();

        //if (shouldChangePassword)
        //    user.ShouldChangePassword();
        //else
        //    user.PasswordRenewed();

        user.ResetFailedLoginAttempts(user.Guid);
        _context.SaveChanges();

        // context.Result = new GrantValidationResult(user.Id.ToString(), "Bearer", DateTime.Now,
        //     new List<Claim>
        //     {
        //         new("id", user.Guid.ToString()),
        //         new(ClaimTypes.Role, user.UserGroup.Guid.ToString()),
        //         new("dbName", dbName),
        //         new("systemId", user.UserGroup.SystemId.ToString()),
        //         new("organizationChartGuid", user.OrganizationChart.Guid.ToString())
        //     });

        return result.Success();
    }

    private bool LoginAttemptsCountReached(User user)
    {
        return user.FailedLoginAttempts >= _loginAttemptsCountLimit;
    }
}