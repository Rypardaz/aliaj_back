using Ex.Application.Contracts.User;
using Lab.Infrastructure.Query.Contracts.User;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.User;

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