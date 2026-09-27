using AM.Application.Contracts.User;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Application;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;

namespace AM.Infrastructure.Query;

public class UserQueryHandler(
    BaseDapperRepository repository,
    IClaimHelper claimHelper,
    AliajQueryContext context,
    IConfiguration configuration) :
    IQueryHandler<List<UserViewModel>>,
    IQueryHandler<EditUser, EditUserSearchModel>,
    IQueryHandler<List<UserComboModel>>,
    IQueryHandlerAsync<UserInformationViewModel>,
    IQueryHandlerAsync<List<UserSessionViewModel>>,
    IQueryHandlerAsync<UserActiveSessionViewModel>,
    IQueryHandlerAsync<List<UserSessionViewModel>, UserSessionSearchModel>
{
    private const string UserSpName = "spGetUserFor";

    List<UserViewModel> IQueryHandler<List<UserViewModel>>.Handle()
        => repository.SelectFromSp<UserViewModel>(UserSpName, new { Type = QueryOutputs.List });

    public EditUser Handle(EditUserSearchModel searchModel)
    {
        return context.Users
            .Include(x => x.Roles)
            .Select(x => new EditUser
            {
                Guid = x.Guid,
                Username = x.Username,
                NationalCode = x.NationalCode,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                EmployeeCode = x.EmployeeCode,
                RoleGuids = x.Roles.Select(x => x.Role.Guid).ToList(),
                SalonIds = x.Salons.Select(x => x.SalonId).ToList()
            }).AsNoTracking()
            .FirstOrDefault(x => x.Guid == searchModel.Guid);
    }

    List<UserComboModel> IQueryHandler<List<UserComboModel>>.Handle()
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        return repository.SelectFromSp<UserComboModel>(UserSpName,
            new { Type = QueryOutputs.Combo, UserGuid = currentUserGuid });
    }

    public async Task<UserInformationViewModel> Handle()
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();

        var userInfo = await (from user in context.Users
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
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var session = await context.Users
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
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var numberOfUserSessions = int.Parse(configuration["NumberOfUserSessionsToShow"]);

        return await context.Users
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

        var usersessions = await (from session in context.UserSessions
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