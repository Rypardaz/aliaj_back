using System.Linq;
using System.Threading.Tasks;
using PhoenixFramework.Dapper;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;
using System.Collections.Generic;
using UserManagement.Persistence;
using PhoenixFramework.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application.Query;
using UserManagement.Query.Contracts.User;
using UserManagement.Application.Contracts.ViewModels;
using UserManagement.Application.Contracts.SearchModels;
using UserManagement.Application.Contracts.Commands.User;

namespace UserManagement.Query;

public class UserQueryHandler :
    IQueryHandler<List<UserViewModel>>,
    IQueryHandler<EditUser, EditUserSearchModel>,
    IQueryHandler<List<UserComboModel>>,
    IQueryHandlerAsync<UserInformationViewModel>,
    IQueryHandlerAsync<List<UserSessionViewModel>>,
    IQueryHandlerAsync<UserActiveSessionViewModel>,
    IQueryHandlerAsync<List<UserSessionViewModel>, UserSessionSearchModel>
{
    private const string UserSpName = "spGetUserFor";
    private readonly BaseDapperRepository _repository;
    private readonly UserManagementQueryContext _context;

    private readonly IClaimHelper _claimHelper;
    private readonly IConfiguration _configuration;

    public UserQueryHandler(BaseDapperRepository repository, IClaimHelper claimHelper,
        UserManagementQueryContext context, IConfiguration configuration)
    {
        _repository = repository;
        _claimHelper = claimHelper;
        _context = context;
        _configuration = configuration;
    }

    List<UserViewModel> IQueryHandler<List<UserViewModel>>.Handle()
        => _repository.SelectFromSp<UserViewModel>(UserSpName, new { Type = QueryOutputs.List });

    public EditUser Handle(EditUserSearchModel searchModel)
    {
        return _context.Users
               .Include(x => x.Roles)
               .Select(x => new EditUser
               {
                   Guid = x.Guid,
                   Username = x.Username,
                   NationalCode = x.NationalCode,
                   Fullname = x.Fullname,
                   Mobile = x.Mobile,
                   EmployeeCode = x.EmployeeCode,
                   RoleGuids = x.Roles.Select(x => x.Role.Guid).ToList()
               }).AsNoTracking()
               .FirstOrDefault(x => x.Guid == searchModel.Guid);
    }

    List<UserComboModel> IQueryHandler<List<UserComboModel>>.Handle()
        => _repository.SelectFromSp<UserComboModel>(UserSpName, new { Type = QueryOutputs.Combo });

    public async Task<UserInformationViewModel> Handle()
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();

        var userInfo = await (from user in _context.Users
                              where user.Guid == currentUserGuid
                              select new
                              {
                                  user.Fullname,
                                  user.PasswordExpired
                              }).FirstOrDefaultAsync();

        return new UserInformationViewModel
        {
            NeedChangePassword = userInfo.PasswordExpired,
            Fullname = userInfo.Fullname
        };
    }

    async Task<UserActiveSessionViewModel> IQueryHandlerAsync<UserActiveSessionViewModel>.Handle()
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        var session = await _context.Users
            .Where(x => x.Guid == currentUserGuid)
            .SelectMany(x => x.Sessions)
            .Where(x => x.IsActive == EntityBase<long>.ActiveStates.Active)
            .Where(x => x.IsSuccessful)
            .OrderByDescending(x => x.Created)
            .FirstOrDefaultAsync();

        if (session is null) return new UserActiveSessionViewModel();

        return new UserActiveSessionViewModel
        {
            IsActive = !session.IsExpired()
        };
    }

    async Task<List<UserSessionViewModel>> IQueryHandlerAsync<List<UserSessionViewModel>>.Handle()
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        var numberOfUserSessions = int.Parse(_configuration["NumberOfUserSessionsToShow"]);

        return await _context.Users
            .Where(x => x.Guid == currentUserGuid)
            .Where(x => !x.PasswordExpired)
            .SelectMany(x => x.Sessions)
            .Select(x => new UserSessionViewModel
            {
                Guid = x.Guid,
                IsSuccessful = x.IsSuccessful,
                ClientIpAddress = x.ClientIpAddress,
                Created = x.Created.ToFarsiFull(),
                CreatedEng = x.Created
            }).OrderByDescending(x => x.CreatedEng)
            .Take(numberOfUserSessions)
            .ToListAsync();
    }

    public async Task<List<UserSessionViewModel>> Handle(UserSessionSearchModel searchModel)
    {
        searchModel.StartDate = searchModel.StartDatePer.ToGeorgianDateTime();
        searchModel.EndDate = searchModel.EndDatePer.ToGeorgianDateTime();

        var usersessions = await (from session in _context.UserSessions
                                  where session.Created.Date >= searchModel.StartDate.Value.Date
                                        && session.Created.Date <= searchModel.EndDate.Value.Date
                                  select (new UserSessionViewModel
                                  {
                                      Guid = session.Guid,
                                      UserGuid = session.UserGuid,
                                      IsSuccessful = session.IsSuccessful,
                                      IsSuccessfulTitle = session.IsSuccessful ? "ورود موفق" : "ورود ناموفق",
                                      ClientIpAddress = session.ClientIpAddress,
                                      Created = session.Created.ToFarsiFull(),
                                      CreatedEng = session.Created,
                                      Fullname = session.UserFullname,
                                      Username = session.Username,
                                      CompanyTitle = session.CompanyTitle,
                                      OrganizationChartTitle = session.OrganizationChartTitle,
                                      NationalCode = session.NationalCode,
                                  })).OrderByDescending(x => x.CreatedEng)
            .ToListAsync();

        if (searchModel.UserGuid != null)
            usersessions = usersessions
                .Where(x => x.UserGuid == searchModel.UserGuid)
                .OrderByDescending(x => x.CreatedEng)
                .ToList();

        if (searchModel.ClientIpAddress != "")
            usersessions = usersessions
                .Where(x => x.ClientIpAddress == searchModel.ClientIpAddress)
                .OrderByDescending(x => x.CreatedEng)
                .ToList();

        return usersessions;
    }
}