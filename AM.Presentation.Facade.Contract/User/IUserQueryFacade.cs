using AM.Application.Contracts.User;
using AM.Infrastructure.Query.Contract.User;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.User;

public interface IUserQueryFacade : IFacadeService
{
    EditUser GetBy(Guid guid);
    List<UserViewModel> GetList();
    List<UserComboModel> GetForCombo(Guid guid);
    Task<List<UserSessionViewModel>> GetUserSessionsLog(UserSessionSearchModel searchModel);
    Task<UserActiveSessionViewModel> HasActiveSession();
    Task<List<UserSessionViewModel>> GetCurrentUserLastSessions();
    Task<UserInformationViewModel> GetUserInformation();
}